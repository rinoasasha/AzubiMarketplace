using System.Reflection;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Scalar.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using backend;
using backend.Config;
using backend.Models;

var builder = WebApplication.CreateBuilder(args);

var config = new AppConfig();
builder.Configuration.Bind(config);
builder.Services.AddSingleton(config);

builder.Services.AddDbContext<DataContext>(opt => opt.UseMySql(config.Database.ConnectionString, MySqlServerVersion.LatestSupportedServerVersion));

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddCookie(IdentityConstants.ApplicationScheme, opt =>
    {
        opt.Cookie.Name = "Manager.Auth";

        opt.Cookie.IsEssential = true;
        opt.ExpireTimeSpan = TimeSpan.FromHours(10);

        opt.Cookie.Domain = null;

        opt.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };
        opt.Events.OnRedirectToAccessDenied = context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return Task.CompletedTask;
        };
    })
    .AddOpenIdConnect("bosch", "Bosch", opt =>
    {
        opt.MetadataAddress = config.OAuth.MetaDataAddress;
        opt.GetClaimsFromUserInfoEndpoint = true;
        opt.ClientId = config.OAuth.ClientId;
        opt.ClientSecret = config.OAuth.ClientSecret;
        opt.AuthenticationMethod = OpenIdConnectRedirectBehavior.RedirectGet;
        opt.SignInScheme = IdentityConstants.ExternalScheme;
        opt.CallbackPath = "/api/v1/signin-oidc";
        foreach (var scope in config.OAuth.Scopes.Split(",").Select(x => x.Trim()))
            opt.Scope.Add(scope);
    }).AddCookie(IdentityConstants.ExternalScheme, opt => { opt.Cookie.Name = "Manager.External"; });

var ib = builder.Services.AddIdentityCore<User>(opt =>
{
    opt.SignIn.RequireConfirmedAccount = false;
    opt.User.RequireUniqueEmail = false;
    opt.User.AllowedUserNameCharacters =
        "@abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-.";
    opt.Password.RequireDigit = false;
    opt.Password.RequiredLength = 6;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireLowercase = false;

    opt.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier;
}).AddEntityFrameworkStores<DataContext>()
.AddRoles<UserRole>()
.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<User, UserRole>>()
.AddDefaultTokenProviders()
.AddSignInManager();

builder.Services.AddScoped<IRoleStore<UserRole>, RoleStore<UserRole, DataContext, Guid>>();
builder.Services.AddScoped<IUserStore<User>, UserStore<User, UserRole, DataContext, Guid>>();

builder.Services.AddCors(o => o.AddPolicy("Frontend", b =>
{
    b.WithOrigins("http://127.0.0.1:3000", "http://localhost:3000", "http://127.0.0.1:5173", "http://localhost:5173/")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
}));

// Add services to the container.
builder.Services.AddAutoMapper(opt=>opt.AddMaps(Assembly.GetExecutingAssembly()));

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dbContext.Database.Migrate();
    var startup = new Startup(scope.ServiceProvider.GetService<IServiceProvider>());
    startup.Initialize().Wait();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseCors("Frontend");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run("http://localhost:5000");