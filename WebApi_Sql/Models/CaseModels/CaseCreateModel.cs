namespace WebApi_Sql.Models.CaseModels
{
    public class CaseCreateModel
    {
        public CaseCreateModel(string product, int amount, int userId, string status = "Unknown")
        {
            var currentDateTime = DateTime.Now;

            Product = product;
            Amount = amount;
            Created = currentDateTime;
            Modified = currentDateTime;
            UserId = userId;
            Status = status;

        }

        public string Product { get; set; }
        public int Amount { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
    }
}

