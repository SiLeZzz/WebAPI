using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebAPI.Models;

namespace WebAPI
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Settlement> Settlements { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Settlement>()
                .HasOne(e => e.Contract)
                .WithMany(e => e.Settlements)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
