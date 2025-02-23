using Microsoft.EntityFrameworkCore;
using AdessoApi.Entities;
using AdessoApi.Data.Mappings;

namespace AdessoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GroupMap());
            modelBuilder.ApplyConfiguration(new TeamMap());
            modelBuilder.ApplyConfiguration(new CountryMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
