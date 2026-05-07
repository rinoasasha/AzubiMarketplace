using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using backend.Models;
using Microsoft.AspNetCore.Identity;

namespace backend;

public class DataContext : IdentityDbContext<User, UserRole, Guid>
{
    public DbSet<AzubiRequest> AzubiRequests { get; set; }
    public DbSet<ABBResponse> AbbResponses { get; set; }
    public DbSet<UserChange> UserChanges { get; set; }
    public DbSet<RequestChange> RequestChanges { get; set; }
    public DbSet<ResponseChange> ResponseChanges { get; set; }
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
}