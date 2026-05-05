using backend.Models;
using Microsoft.AspNetCore.Identity;

namespace backend;

public sealed class Startup
{
    private readonly IServiceProvider _serviceProvider;
    public Startup(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Initialize()
    {
        await CreateUserRoles(_serviceProvider);
    }
    
    private async Task CreateUserRoles(IServiceProvider serviceProvider)
    {
        var RoleManager = serviceProvider.GetRequiredService<RoleManager<UserRole>>();
        var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();
        string[] userRoles = ["Admin", "Azubi", "ABB"];

        foreach (var role in userRoles)
        {
            var roleExist = await RoleManager.RoleExistsAsync(role);
            if (!roleExist)
            {
                await RoleManager.CreateAsync(new UserRole()
                {
                    Name =  role
                });
            }
        }
        
        // create initial admin user
        var adminUser = new User()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000000"),
            UserName = "admin",
            LocalUsername = "admin",
            Email = "oyk1fe@bosch.com",
            EmailConfirmed = true,
            FirstName = "ad",
            LastName = "min",
            PhoneNumber = "0888888888",
            PhoneNumberConfirmed =  false,
            TwoFactorEnabled = false,
            LockoutEnabled = false,
            AccessFailedCount = 0
        };
        
        var existingAdminUser = await UserManager.FindByIdAsync(adminUser.Id.ToString());
        if (existingAdminUser == null)
        {
            var createAdminUser = await UserManager.CreateAsync(adminUser, "123456");
            if (createAdminUser.Succeeded)
            {
                await UserManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}