using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Sql.CategoryModels;
using WebApi_Sql.Filters;
using WebApi_Sql.Models.Entities;
using WebApi_Sql.Models.ProductModels;

namespace WebApi_Sql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly SqlContext _context;

        public ProductController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/ProductEntities
        [HttpGet]
        [UseApiKey]

        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProducts()
        {
            var items = new List<ProductModel>();

            foreach(var item in await _context.Products.Include(x => x.Category).ToListAsync())
            {
                
                    items.Add(new ProductModel(
                    item.Articlenumber,
                    item.Name,
                    item.Description,
                    item.Price,
                    item.Status,                  
                    new CategoryModel(item.Category.CategoryId, item.Category.Category)
                ));

            }

            return items;
        }

        // GET: api/ProductEntities/5
        [HttpGet("{id}")]
        [UseApiKey]

        public async Task<ActionResult<ProductModel>> GetProductsEntity(int id)
        {
            var caseEntity = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Articlenumber == id);

            if (caseEntity == null)
            {
                return NotFound();
            }


                    return new ProductModel(
                    caseEntity.Articlenumber,
                    caseEntity.Name,
                    caseEntity.Description,
                    caseEntity.Price,
                    caseEntity.Status,
                    new CategoryModel(caseEntity.Category.CategoryId, caseEntity.Category.Category)
            );
        }

        // PUT: api/ProductEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [UseAdminApiKey]

        public async Task<IActionResult> PutProductEntity(int id, ProductUpdateModel model)
        {
            if (id != model.Articlenumber)
            {
                return BadRequest();
            }

            var caseEntity = await _context.Cases.FindAsync(model.Articlenumber);
            caseEntity.Modified = DateTime.Now;
            

            _context.Entry(caseEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [UseAdminApiKey]

        public async Task<ActionResult<ProductModel>> PostProductEntity(ProductCreateModel model)
        {
            if (!await _context.Categories.AnyAsync(x => x.CategoryId == model.CategoryId))
                return BadRequest();

            var productEntity = new ProductEntity(model.Name, model.Description, model.Price, model.Status, model.CategoryId);

            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();

            var _productEntity = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Articlenumber == productEntity.Articlenumber);

            return CreatedAtAction("GetProductEntity", new { id = productEntity.Articlenumber }, new ProductModel(                   
                    _productEntity.Articlenumber,
                    _productEntity.Name,
                    _productEntity.Description,
                    _productEntity.Price,
                    _productEntity.Status,
                    new CategoryModel(_productEntity.Category.CategoryId, _productEntity.Category.Category)
            ));
        }

        // DELETE: api/ProductEntities/5
        [HttpDelete("{id}")]
        [UseAdminApiKey]

        public async Task<IActionResult> DeleteProductEntity(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }

            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductEntityExists(int id)
        {
            return _context.Products.Any(e => e.Articlenumber == id);
        }
    }
}
