using EXSM3942_Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo.Data
{
    public class ClassRoomContext : DbContext
    {
        public ClassRoomContext() { }
        // This version of the construtor is used less frequently for customizing how the context is initialized.
        //public GroceryStoreContext(DbContextOptions<GroceryStoreContext> options) : base(options) { }

        // Each of these DbSets represents every record in their associated table. 
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<ClassRoom> ClassRooms { get; set; }

        // Configures the context.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // If the context is not already configured:
            if (!optionsBuilder.IsConfigured)
            {
                // Specify the connection to the database.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=exsm3942_classroom", new MySqlServerVersion(new Version(10, 4, 24)));
            }
        }
        // Setup instructions for creating a model object.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassRoom>(entity =>
            {
                entity.ToTable("classroom");
                entity.HasKey(model => model.ID);

                entity.Property(model => model.ID)
                    .HasColumnName("id")
                    .HasColumnType("int(10)")
                    .ValueGeneratedOnAdd();
                entity.Property(model => model.RoomNumber)
                    .HasColumnName("room_number")
                    .HasColumnType("int(10)")
                    .IsRequired();
                entity
                    .HasData(new ClassRoom[] {
                        new ClassRoom() { ID = -1, RoomNumber = 1001 },
                        new ClassRoom() { ID = -2, RoomNumber = 1002 },
                        new ClassRoom() { ID = -3, RoomNumber = 1003 }
                    });
            });
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");
                entity.HasKey(model => model.ID);

                // Setup instructions for Product.
                entity.HasIndex(model => model.ClassRoomID).HasName($"FK_{nameof(Student)}_{nameof(ClassRoom)}");

                entity.Property(model => model.ID)
                    .HasColumnName("id")
                    .HasColumnType("int(10)")
                    .ValueGeneratedOnAdd();
                entity.Property(model => model.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(30)")
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");
                entity.Property(model => model.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(30)")
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");
                entity.Property(model => model.ClassRoomID)
                    .HasColumnName("classroom_id")
                    .HasColumnType("int(10)")
                    .IsRequired();
                entity
                    .HasOne(x => x.ClassRoom)
                    .WithMany(y => y.Students)
                    .HasForeignKey(x => x.ClassRoomID)
                    .HasConstraintName($"FK_{nameof(Student)}_{nameof(ClassRoom)}")
                    .OnDelete(DeleteBehavior.Restrict);

                string[] fNames = new string[] { "Liam", "Noah", "Oliver", "Elijah", "James" };
                string[] lNames = new string[] { "Smith", "Johnson", "Williams", "Brown", "Jones" };
                Random rnd = new Random();
                int id = -1;
                List<Student> perms = new List<Student>();
                foreach (string fname in fNames) foreach (string lname in lNames) perms.Add(new Student() { ID = id--, FirstName = fname, LastName = lname, ClassRoomID = rnd.Next(-3,0) });
                entity
                    .HasData(perms);
            });
            
        }
    }
}
