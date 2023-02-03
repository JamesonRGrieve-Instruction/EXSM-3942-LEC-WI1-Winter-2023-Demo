﻿// <auto-generated />
using EXSM3942_Demo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EXSM3942Demo.Migrations
{
    [DbContext(typeof(GroceryStoreContext))]
    [Migration("20230203021710_RandomSeedData")]
    partial class RandomSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EXSM3942_Demo.Data.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10)")
                        .HasColumnName("id");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int(10)")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("description")
                        .UseCollation("utf8mb4_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Description"), "utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name")
                        .UseCollation("utf8mb4_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Name"), "utf8mb4");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID")
                        .HasDatabaseName("FK_Product_ProductCategory");

                    b.ToTable("product", (string)null);

                    b.HasData(
                        new
                        {
                            ID = -1,
                            CategoryID = -1,
                            Description = "A 4L bottle of 1% milk.",
                            Name = "Milk 1%, 4L"
                        },
                        new
                        {
                            ID = -2,
                            CategoryID = -2,
                            Description = "A slice of salami.",
                            Name = "Salami, Slice"
                        },
                        new
                        {
                            ID = -3,
                            CategoryID = -3,
                            Description = "A head of lettuce.",
                            Name = "Lettuce"
                        },
                        new
                        {
                            ID = -4,
                            CategoryID = -1,
                            Description = "A 2L bottle of Cola.",
                            Name = "Cola, 2L"
                        });
                });

            modelBuilder.Entity("EXSM3942_Demo.Data.Models.ProductCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10)")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("description")
                        .UseCollation("utf8mb4_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Description"), "utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name")
                        .UseCollation("utf8mb4_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Name"), "utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("product_category", (string)null);

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Description = "Milk, cheese and stuff.",
                            Name = "Dairy"
                        },
                        new
                        {
                            ID = -2,
                            Description = "Meats and stuff.",
                            Name = "Deli"
                        },
                        new
                        {
                            ID = -3,
                            Description = "Lettuce, tomatoes and stuff.",
                            Name = "Garden"
                        });
                });

            modelBuilder.Entity("EXSM3942_Demo.Data.Models.Product", b =>
                {
                    b.HasOne("EXSM3942_Demo.Data.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Product_ProductCategory");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("EXSM3942_Demo.Data.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
