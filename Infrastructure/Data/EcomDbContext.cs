using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EcomDbContext : DbContext
    {
        public EcomDbContext(DbContextOptions<EcomDbContext> options) : base(options) { }


        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            // Configure the Relationship between Entities Product and ProductType

            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductType)
                .WithMany()
                .HasForeignKey(p => p.ProductTypeId);

            // Configure the Relationship between Entities Product and ProductBrand
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductBrand)
                .WithMany()
                .HasForeignKey(p => p.ProductBrandId);


            base.OnModelCreating(modelBuilder);


        }

    }


}
