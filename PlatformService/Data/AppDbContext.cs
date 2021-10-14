using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService
{
    public class AppDbContext : DbContext
    {
        public DbSet<Platform> Platforms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=platformsdb;Persist Security Info=True;User ID=sa;Password=pa55w0rd!;");
        }
    }
}