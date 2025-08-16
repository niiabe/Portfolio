using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure the Project entity
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Category).IsRequired().HasMaxLength(50);
                entity.Property(e => e.ImageUrl).HasMaxLength(255);
                entity.Property(e => e.ProjectLink).HasMaxLength(255);
                entity.Property(e => e.CreatedAt).IsRequired();
            });
        }
    }
}