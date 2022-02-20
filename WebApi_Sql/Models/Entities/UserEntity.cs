using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.Entities;

namespace WebApi_Sql.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class UserEntity
    {
        public UserEntity(string firstName, string lastName, string email, string password, string addressLine, string zipCode, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            AddressLine = addressLine;
            ZipCode = zipCode;
            City = city;        
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string AddressLine { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ZipCode { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }


       

        public virtual ICollection<CaseEntity> Cases { get; set; }

        
    }
}
