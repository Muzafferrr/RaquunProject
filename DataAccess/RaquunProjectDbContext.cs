using Microsoft.EntityFrameworkCore;
using RaquunProject.DataAccess.Entities;
using System.Security.Cryptography.X509Certificates;

namespace RaquunProject.DataAccess
{
    public class RaquunProjectDbContext : DbContext
    {
        public RaquunProjectDbContext(DbContextOptions<RaquunProjectDbContext> options) : base(options){ }
        public DbSet<City>? Cities { get; set; } = default!;
        public DbSet<Country>? Countries { get; set; } = default!;
        public DbSet<User>? Users { get; set; }
    }
}
