using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Sql;
using WebApi_Sql.Filters;
using WebApi_Sql.Models.Entities;
using WebApi_Sql.Models.UserModels;
namespace _01_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SqlContext _context;

        public UserController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/User

        [HttpGet]
        [UseApiKey]


        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            var items = new List<UserModel>();

            foreach (var item in await _context.Users.ToListAsync())
                items.Add(new UserModel(item.Id, item.FirstName, item.LastName, item.Email, item.AddressLine, item.ZipCode, item.City));

            return items;
        }


        // GET: api/User/5

        [HttpGet("{id}")]
        [UseApiKey]


        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            var customerEntity = await _context.Users.FindAsync(id);

            if (customerEntity == null)
            {
                return NotFound();
            }
            return new UserModel(
                    customerEntity.Id, customerEntity.FirstName, customerEntity.LastName, customerEntity.Email, customerEntity.AddressLine, customerEntity.ZipCode, customerEntity.City);


                
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}")]
        [UseAdminApiKey]


        public async Task<IActionResult> PutUserEntity(int id, UserUpdateModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var userEntity = await _context.Users.FindAsync(model.Id);
            if (userEntity == null)
                return NotFound();

            userEntity.FirstName = model.FirstName;
            userEntity.LastName = model.LastName;
            userEntity.Email = model.Email;
            userEntity.Password = model.Password;
            userEntity.AddressLine = model.AddressLine;
            userEntity.ZipCode = model.ZipCode;
            userEntity.City = model.City;

            _context.Entry(userEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserEntityExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost]
        [UseAdminApiKey]

        public async Task<ActionResult<UserModel>> PostUserEntity(UserCreateModel model)
        {
            if (await _context.Users.AnyAsync(x => x.Email == model.Email))
                return Conflict("A customer with the same email address already exists.");

            var customerEntity = new UserEntity(model.FirstName, model.LastName, model.Email, model.Password, model.AddressLine, model.ZipCode, model.City);
            _context.Users.Add(customerEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = customerEntity.Id }, new UserModel(customerEntity.Id, customerEntity.FirstName, customerEntity.LastName, customerEntity.Email, customerEntity.AddressLine, customerEntity.ZipCode, customerEntity.City));
        }


        // DELETE: api/User/5

        [HttpDelete("{id}")]
        [UseAdminApiKey]

        public async Task<IActionResult> DeleteUserEntity(int id)
        {
            var userEntity = await _context.Users.FindAsync(id);
            if (userEntity == null)
            {
                return NotFound();
            }

            userEntity.FirstName = "";
            userEntity.LastName = "";
            userEntity.Email = "";
            userEntity.AddressLine = "";
            userEntity.ZipCode = "";
            userEntity.City = "";

            _context.Entry(userEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserEntityExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
