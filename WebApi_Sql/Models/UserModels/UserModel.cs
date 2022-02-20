using WebApi.Models.Entities;

namespace WebApi_Sql.Models.UserModels
{
    public class UserModel
    {
        public UserModel(int id, string firstName, string lastName, string email) // constructor for cases
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public UserModel(int id, string firstName, string lastName, string email, string addressLine, string zipCode, string city)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            AddressLine = addressLine;
            ZipCode = zipCode;
            City = city;
        }

       
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressLine { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }



        
    }
}