namespace WebApi_Sql.Models.UserModels
{
    public class UserCreateModel
    {
        public UserCreateModel(string firstName, string lastName, string email, string password, string addressLine, string zipCode, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            AddressLine = addressLine;
            ZipCode = zipCode;
            City = city;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AddressLine { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}