using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using backend.Models;

namespace backend;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<AzubiProfile> AzubiProfiles { get; set; }
    public DbSet<ABBProfile> ABBProfiles { get; set; }
    public DbSet<AzubiRequest> AzubiRequests { get; set; }
    public DbSet<ABBApplication> ABBApplications { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
}