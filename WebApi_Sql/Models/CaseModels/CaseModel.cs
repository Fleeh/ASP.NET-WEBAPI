using WebApi_Sql.Models.UserModels;

namespace WebApi_Sql.Models.CaseModels
{
    public class CaseModel
    {
        

       

        public CaseModel(int id, string product, int amount, DateTime created, DateTime modified, string status, UserModel user)
        {
            Id = id;
            Product = product;
            Amount = amount;
            Created = created;
            Modified = modified;
            Status = status;
            User = user;
        }

        

        public int Id { get; set; }
        public string Product { get; set; }
        public int Amount { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Status { get; set; }

        public UserModel User { get; set; }
    }
}