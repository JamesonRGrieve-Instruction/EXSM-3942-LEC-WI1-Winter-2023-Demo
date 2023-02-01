using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo.Data.Models
{
    [Table("product_category")]
    public class ProductCategory
    {
        // Primary Key
        [Key]
        // AUTO_INCREMENT
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Name and Type
        [Column("id", TypeName = "int(10)")]
        public int ID { get; set; }

        // Name and Type
        [Column("name", TypeName = "varchar(30)")]
        // Length on C# Side
        [StringLength(30)]
        // NOT NULL
        [Required]
        public string Name { get; set; }

        // Name and Type
        [Column("description", TypeName = "varchar(50)")]
        // Length on C# Side
        [StringLength(50)]
        public string Description { get; set; }

        // Point the navigation properties at each other
        [InverseProperty(nameof(Models.Product.ProductCategory))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
