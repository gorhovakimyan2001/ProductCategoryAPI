using Microsoft.EntityFrameworkCore;
using ProductCategory.Domain.Entities;

namespace ProductCategory.Infrastrucuture
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
    : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProduct> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct > ()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<CategoryProduct>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductsCategories)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<CategoryProduct>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductsCategories)
                .HasForeignKey(pc => pc.CategoryId);
        }
    }
}
