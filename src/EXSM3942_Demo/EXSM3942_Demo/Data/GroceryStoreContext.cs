using EXSM3942_Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo.Data
{
    public class GroceryStoreContext : DbContext
    {
        public GroceryStoreContext() { }
        // This version of the construtor is used less frequently for customizing how the context is initialized.
        //public GroceryStoreContext(DbContextOptions<GroceryStoreContext> options) : base(options) { }

        // Each of these DbSets represents every record in their associated table. 
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        // Configures the context.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // If the context is not already configured:
            if (!optionsBuilder.IsConfigured)
            {
                // Specify the connection to the database.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=exsm3942_grocerystore", new MySqlServerVersion(new Version(10, 4, 24)));
            }
        }
        // Setup instructions for creating a model object.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                // Setup instructions for ProductCategory.
                entity.ToTable("product_category");
                entity.HasKey(model => model.ID);

                entity.Property(model => model.ID)
                    .HasColumnName("id")
                    .HasColumnType("int(10)")
                    .ValueGeneratedOnAdd();
                entity.Property(model => model.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(30)")
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");
                entity.Property(model => model.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(50)")
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");
                entity
                    .HasData(new ProductCategory[] {
                        new ProductCategory() { ID = -1, Name = "Dairy", Description = "Milk, cheese and stuff." },
                        new ProductCategory() { ID = -2, Name = "Deli", Description = "Meats and stuff." },
                        new ProductCategory() { ID = -3, Name = "Garden", Description = "Lettuce, tomatoes and stuff." }
                    });
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");
                entity.HasKey(model => model.ID);

                // Setup instructions for Product.
                entity.HasIndex(model => model.CategoryID).HasName($"FK_{nameof(Product)}_{nameof(ProductCategory)}");

                entity.Property(model => model.ID)
                    .HasColumnName("id")
                    .HasColumnType("int(10)")
                    .ValueGeneratedOnAdd();
                entity.Property(model => model.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(30)")
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");
                entity.Property(model => model.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(50)")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");
                entity.Property(model => model.CategoryID)
                    .HasColumnName("category_id")
                    .HasColumnType("int(10)")
                    .IsRequired();
                entity
                    .HasOne(x => x.ProductCategory)
                    .WithMany(y => y.Products)
                    .HasForeignKey(x => x.CategoryID)
                    .HasConstraintName($"FK_{nameof(Product)}_{nameof(ProductCategory)}")
                    .OnDelete(DeleteBehavior.Restrict);

                string[] beverages = new string[] { "Milk", "Coffee", "Cola", "Water", "Honey" };
                string[] sizes = new string[] { "0.5L", "1L", "2L", "3L", "4L" };
                Random random = new Random();
                string size, beverage;
                entity
                    .HasData(new Product[] {
                        new Product() { ID = -1, Name = "Milk 1%, 4L", Description = "A 4L bottle of 1% milk.", CategoryID = -1 },
                        new Product() { ID = -2, Name = "Salami, Slice", Description = "A slice of salami.", CategoryID = -2 },
                        new Product() { ID = -3, Name = "Lettuce", Description = "A head of lettuce.", CategoryID = -3 },
                        new Product() { ID = -4, Name = $"{beverage=beverages[random.Next(0,5)]}, {size=sizes[random.Next(0,5)]}", Description = $"A {size} bottle of {beverage}.", CategoryID = -1}
                    }); 
            });
            
        }
    }
}
