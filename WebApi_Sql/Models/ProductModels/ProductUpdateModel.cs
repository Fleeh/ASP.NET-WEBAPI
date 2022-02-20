namespace WebApi_Sql.Models.ProductModels
{
    public class ProductUpdateModel
    {
        public ProductUpdateModel(int articlenumber, string name, string description, decimal price)
        {
            Articlenumber = articlenumber;
            Name = name;
            Description = description;
            Price = price;
        }

        public int Articlenumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}


