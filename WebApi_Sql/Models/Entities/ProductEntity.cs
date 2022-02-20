using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Sql.Models.Entities
{
    public class ProductEntity
    {
        public ProductEntity(string name, string description, decimal price, string status, int categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            Status = status;
            CategoryId = categoryId;
        }

        [Key]
        public int Articlenumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public string Status { get; set; }

        public int CategoryId { get; set; }
    
        public CategoryEntity Category { get; set; }
     

       







    }
}