using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EXSM3942_Demo.Models;

public partial class DBFirstCarsContext : DbContext
{
    public DBFirstCarsContext()
    {
    }

    public DBFirstCarsContext(DbContextOptions<DBFirstCarsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dealership> Dealerships { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=react-api-assignment", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Dealership>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dealership");

            entity.HasIndex(e => e.Manufacturerid, "FK_Dealership_Manufacturer");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Manufacturerid)
                .HasColumnType("int(11)")
                .HasColumnName("manufacturerid");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("phonenumber");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Dealerships)
                .HasForeignKey(d => d.Manufacturerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dealership_Manufacturer");
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("manufacturer");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasData(new Manufacturer[] {
                   new Manufacturer() { Id = -1, Name = "Mitsubishi"},
                   new Manufacturer() { Id = -2, Name = "Daihatsu"},
                   new Manufacturer() { Id = -3, Name = "Citroen"}
            });
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("model");

            entity.HasIndex(e => e.Manufacturerid, "FK_Model_Manufacturer");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Manufacturerid)
                .HasColumnType("int(11)")
                .HasColumnName("manufacturerid");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Models)
                .HasForeignKey(d => d.Manufacturerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Model_Manufacturer");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Vin).HasName("PRIMARY");

            entity.ToTable("vehicle");

            entity.HasIndex(e => e.DealershipId, "FK_Vehicle_Dealership");

            entity.HasIndex(e => e.Modelid, "FK_Vehicle_Model");

            entity.Property(e => e.Vin)
                .HasMaxLength(17)
                .IsFixedLength()
                .HasColumnName("vin");
            entity.Property(e => e.DealershipId)
                .HasColumnType("int(11)")
                .HasColumnName("DealershipID");
            entity.Property(e => e.Modelid)
                .HasColumnType("int(11)")
                .HasColumnName("modelid");
            entity.Property(e => e.Trimlevel)
                .HasMaxLength(50)
                .HasColumnName("trimlevel");

            entity.HasOne(d => d.Dealership).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.DealershipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_Dealership");

            entity.HasOne(d => d.Model).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.Modelid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_Model");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
