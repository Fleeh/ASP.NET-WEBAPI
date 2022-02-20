using System.ComponentModel.DataAnnotations;
using WebApi_Sql.Models.Entities;

namespace WebApi_Sql.CategoryModels
{
    public class CategoryModel
    {
        public CategoryModel(int categoryId, string category)
        {
            CategoryId = categoryId;
            Category = category;
        }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        

        
    }
}
