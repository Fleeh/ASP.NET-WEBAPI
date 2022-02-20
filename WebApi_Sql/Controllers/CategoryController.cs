using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Sql.CategoryModels;
using WebApi_Sql.Filters;
using WebApi_Sql.Models.Entities;

namespace WebApi_Sql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly SqlContext _context;

        public CategoryController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        [UseApiKey]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetCategories()
        {
            var items = new List<CategoryModel>();

            foreach (var item in await _context.Categories.ToListAsync())
                items.Add(new CategoryModel(item.CategoryId, item.Category));

            return items;
        }

        

        

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [UseApiKey]
        public async Task<ActionResult<CategoryModel>> PostCategoryEntity(CategoryCreateModel model)
        {
            if (await _context.Categories.AnyAsync(x => x.Category == model.Category))
                return Conflict("A customer with the same name already exists.");

            var customerEntity = new CategoryEntity(model.Category);
            _context.Categories.Add(customerEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryEntity", new { id = customerEntity.CategoryId }, new CategoryModel(customerEntity.CategoryId, customerEntity.Category));
        }

        // DELETE: api/Category/5


        [HttpDelete("{id}")]
        [UseAdminApiKey]
        public async Task<IActionResult> DeleteCategoryEntity(int id)
        {
            var categoryEntity = await _context.Categories.FindAsync(id);
            if (categoryEntity == null)
            {
                return NotFound();
            }

            categoryEntity.Category = "";
            

            _context.Entry(categoryEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
    }
}
