using System.ComponentModel.DataAnnotations;
using WebApi_Sql.CategoryModels;

namespace WebApi_Sql.Models.ProductModels
{
    public class ProductModel
    {
        public ProductModel(int articlenumber, string name, string description, decimal price, string status, CategoryModel category)
        {
            Articlenumber = articlenumber;
            Name = name;
            Description = description;
            Price = price;
            Status = status;
            Category = category;
        }

        public int Articlenumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }   
        public string Status { get; set; }

        public CategoryModel Category { get; set; }


    }
}
