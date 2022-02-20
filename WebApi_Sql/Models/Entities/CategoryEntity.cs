using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Sql.Models.Entities
{
    [Index(nameof(Category), IsUnique = true)]
    public class CategoryEntity
    {
        public CategoryEntity(string category)
        {
            Category = category;
        }
       

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Category { get; set; }

      

      

        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}


