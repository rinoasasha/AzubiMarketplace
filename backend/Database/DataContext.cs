using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using backend.Models;
using Microsoft.AspNetCore.Identity;

namespace backend;

public class DataContext : IdentityDbContext<User, UserRole, Guid>
{
    public DbSet<AzubiProfile> AzubiProfiles { get; set; }
    public DbSet<ABBProfile> ABBProfiles { get; set; }
    public DbSet<AzubiRequest> AzubiRequests { get; set; }
    public DbSet<ABBApplication> ABBApplications { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
}