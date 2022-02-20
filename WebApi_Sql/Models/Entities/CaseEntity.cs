using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi_Sql.Models.Entities;

namespace WebApi.Models.Entities
{
    public class CaseEntity
    {
        public CaseEntity(string product, int amount, DateTime created, DateTime modified, string status, int userId)
        {
            Product = product;
            Amount = amount;
            Created = created;
            Modified = modified;
            Status = status;
            UserId = userId;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Product { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public int Amount { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; }

        public int UserId { get; set; }

        public UserEntity User { get; set; }
        
    }
}

