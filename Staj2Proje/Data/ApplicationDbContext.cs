using Microsoft.EntityFrameworkCore;
using Staj2Proje.Models; // Modellerin olduğu namespace

namespace Staj2Proje.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Fault> Faults { get; set; }
        public DbSet<Outage> Outages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoices");

                entity.HasKey(e=>e.Id);

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Amount)
                      .HasColumnType("decimal(18,2)"); 
            });
        }
    }
}
