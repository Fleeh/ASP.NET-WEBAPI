namespace WebApi_Sql.Models.UserModels
{
    public class UserUpdateModel
    {
        public UserUpdateModel(int id, string firstName, string lastName, string email, string password, string addressLine, string zipCode, string city)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            AddressLine = addressLine;
            ZipCode = zipCode;
            City = city;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string AddressLine { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        
    }
}
