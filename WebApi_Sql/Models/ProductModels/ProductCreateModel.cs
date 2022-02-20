namespace WebApi_Sql.Models.ProductModels
{
    public class ProductCreateModel
    {
        public ProductCreateModel()
        {

        }

        public ProductCreateModel(string name, string description, int categoryId, int price, string status)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
            Price = price;
            Status = status;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
    }
}
