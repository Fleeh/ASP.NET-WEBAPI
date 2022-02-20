using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;
using WebApi_Sql.Filters;
using WebApi_Sql.Models.CaseModels;
using WebApi_Sql.Models.UserModels;

namespace WebApi_Sql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly SqlContext _context;

        public CasesController(SqlContext context)
        {
            _context = context;
        }




        // GET: api/Cases
        [HttpGet]
        [UseApiKey]

        public async Task<ActionResult<IEnumerable<CaseModel>>> GetCases()
        {
            var items = new List<CaseModel>();

            foreach (var item in await _context.Cases.Include(x => x.User).ToListAsync())
            {
                
                    items.Add(new CaseModel(
                        item.Id,
                        item.Product,
                        item.Amount,
                        item.Created,
                        item.Modified,
                        item.Status,
                        new UserModel(item.User.Id, item.User.FirstName, item.User.LastName, item.User.Email, item.User.AddressLine, item.User.ZipCode, item.User.City)
                    ));

            }

            return items;
        }





        // GET: api/Cases/5
        [HttpGet("{id}")]
        [UseApiKey]

        public async Task<ActionResult<CaseModel>> GetCaseEntity(int id)
        {
            var caseEntity = await _context.Cases.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);

            if (caseEntity == null)
            {
                return NotFound();
            }

            
                return new CaseModel(
                    caseEntity.Id,
                    caseEntity.Product,
                    caseEntity.Amount,
                    caseEntity.Created,
                    caseEntity.Modified,
                    caseEntity.Status,
                    new UserModel(caseEntity.User.Id, caseEntity.User.FirstName, caseEntity.User.LastName, caseEntity.User.Email, caseEntity.User.AddressLine, caseEntity.User.ZipCode, caseEntity.User.City)
                );
        }

        // PUT: api/Cases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [UseAdminApiKey]

        public async Task<IActionResult> PutCaseEntity(int id, CaseUpdateModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var caseEntity = await _context.Cases.FindAsync(model.Id);
            caseEntity.Modified = DateTime.Now;
            caseEntity.Status = model.Status;

            _context.Entry(caseEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseEntityExists(id))
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

        // POST: api/Cases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [UseAdminApiKey]

        public async Task<ActionResult<CaseModel>> PostCaseEntity(CaseCreateModel model)
        {
            if (!await _context.Users.AnyAsync(x => x.Id == model.UserId))
                return BadRequest();

            var caseEntity = new CaseEntity(model.Product, model.Amount, model.Created, model.Modified, model.Status, model.UserId);

            _context.Cases.Add(caseEntity);
            await _context.SaveChangesAsync();

            var _caseEntity = await _context.Cases.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == caseEntity.Id);

            return CreatedAtAction("GetCaseEntity", new { id = caseEntity.Id }, new CaseModel(
                    _caseEntity.Id,
                    _caseEntity.Product,
                    _caseEntity.Amount,
                    _caseEntity.Created,
                    _caseEntity.Modified,
                    _caseEntity.Status,
                    new UserModel(_caseEntity.User.Id, _caseEntity.User.FirstName, _caseEntity.User.LastName, _caseEntity.User.Email, _caseEntity.User.AddressLine, _caseEntity.User.ZipCode, _caseEntity.User.Email)
            ));
        }

        [HttpDelete("{id}")]
        [UseAdminApiKey]


        public async Task<IActionResult> DeleteCaseEntity(int id)
        {
            var caseEntity = await _context.Cases.FindAsync(id);
            if (caseEntity == null)
            {
                return NotFound();
            }

            _context.Cases.Remove(caseEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        private bool CaseEntityExists(int id)
        {
            return _context.Cases.Any(e => e.Id == id);
        }
    }
}