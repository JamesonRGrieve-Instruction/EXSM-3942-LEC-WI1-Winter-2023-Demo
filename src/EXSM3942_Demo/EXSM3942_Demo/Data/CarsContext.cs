using EXSM3942_Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo.Data
{
    public class CarsContext : DbContext
    {
        public CarsContext() { }
        
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=exsm3942_assignment_week04", new MySqlServerVersion(new Version(10, 4, 24)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("manufacturer");
                entity.HasKey(model => model.ID);

                entity.Property(model => model.ID)
                    .HasColumnName("id")
                    .HasColumnType("int(10)")
                    .ValueGeneratedOnAdd();

                entity.Property(model => model.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(30)")
                    .HasMaxLength(30)
                    .IsRequired()
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasData(new Manufacturer[] {
                    new Manufacturer() { ID = -1, Name = "Ford" },
                    new Manufacturer() { ID = -2, Name = "Dodge" }
                });
            });
            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("model");
                entity.HasKey(model => model.ID);

                entity.Property(model => model.ID)
                    .HasColumnName("id")
                    .HasColumnType("int(10)")
                    .ValueGeneratedOnAdd();

                entity.Property(model => model.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(30)")
                    .HasMaxLength(30)
                    .IsRequired()
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(model => model.ManufacturerID)
                    .HasColumnName("manufacturer_id")
                    .HasColumnType("int(10)")
                    .IsRequired();

                entity
                    .HasOne(x => x.Manufacturer)
                    .WithMany(y => y.Models)
                    .HasForeignKey(x => x.ManufacturerID)
                    .HasConstraintName($"FK_{nameof(Data.Models.Model)}_{nameof(Manufacturer)}")
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(new Model[] {
                    new Model() { ID = -1, Name = "Mustang", ManufacturerID = -1 },
                    new Model() { ID = -2, Name = "Probe", ManufacturerID = -1 },
                    new Model() { ID = -3, Name = "Challenger", ManufacturerID = -2 },
                    new Model() { ID = -4, Name = "Stealth", ManufacturerID = -2 }
                });
            });
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicle");
                entity.HasKey(model => model.VIN);

                entity.Property(model => model.VIN)
                    .HasColumnName("vin")
                    .HasColumnType("char(17)")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(model => model.ModelYear)
                    .HasColumnName("model_year")
                    .HasColumnType("int(10)")
                    .IsRequired();

                entity.Property(model => model.Colour)
                    .HasColumnName("colour")
                    .HasColumnType("varchar(30)")
                    .HasMaxLength(30)
                    .IsRequired()
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(model => model.ModelID)
                   .HasColumnName("model_id")
                   .HasColumnType("int(10)")
                   .IsRequired();

                entity
                    .HasOne(x => x.Model)
                    .WithMany(y => y.Vehicles)
                    .HasForeignKey(x => x.ModelID)
                    .HasConstraintName($"FK_{nameof(Vehicle)}_{nameof(Data.Models.Model)}")
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(new Vehicle[] {
                    new Vehicle() { VIN = "1FABP2732GF171121", ModelYear = 2008, Colour = "Yellow", ModelID = -1 },
                    new Vehicle() { VIN = "1ZVBT22L6K5103610", ModelYear = 1994, Colour = "Blue", ModelID = -2 },
                    new Vehicle() { VIN = "2C3CDZGG0JH112887", ModelYear = 2012, Colour = "Red", ModelID = -3 },
                    new Vehicle() { VIN = "JB3BM64JXPY011653", ModelYear = 1993, Colour = "Silver", ModelID = -4 }
                });
            });
        }
    }
}
