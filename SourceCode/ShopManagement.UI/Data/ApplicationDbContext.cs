using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShopManagement.UI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<District> Districts { get; set; }
        public DbSet<Upazila> Upazilas { get; set; }
        public DbSet<Store> Store { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ignore keyless entity types
            modelBuilder.Ignore<IdentityUserLogin<string>>();


            modelBuilder.Entity<Upazila>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);

                entity.HasOne(e => e.District)
                    .WithMany(d => d.Upazilas)
                    .HasForeignKey(e => e.DistrictId);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.RegionalStoreName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(e => e.TransitDistrict)
                    .WithMany(d => d.TransitStores)
                    .HasForeignKey(e => e.TransitDistrictId);

                entity.HasOne(e => e.NonTransitDistrict)
                    .WithMany(d => d.NonTransitStores)
                    .HasForeignKey(e => e.NonTransitDistrictId);

                entity.HasOne(e => e.Upazila)
                    .WithMany()
                    .HasForeignKey(e => e.UpazilaId)
                    .OnDelete(DeleteBehavior.SetNull); // Optional Upazila can be set to null on delete
            });

        }
    }
}
