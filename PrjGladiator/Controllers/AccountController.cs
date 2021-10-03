using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PrjGladiator.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace PrjGladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly AppDBContext _context;

        public AccountController(AppDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User _account)
        {
            if (_account != null && _account.Email != null && _account.Password != null)
            {
                User accountCustomer = await GetAccount(_account.Email, _account.Password);

                if (accountCustomer != null)
                {
                    return accountCustomer;
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest("invalid");
            }
        }

        private async Task<User> GetAccount(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

    }
}
