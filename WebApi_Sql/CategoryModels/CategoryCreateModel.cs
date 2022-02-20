namespace WebApi_Sql.CategoryModels
{
    public class CategoryCreateModel
    {
        public CategoryCreateModel(string category)
        {
            Category = category;
            
           
        }


        public string Category { get; set; }

   
       

    }
}
