using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Data;

namespace WebApplicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly APIDbContext _context;
        public AccountController(APIDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Login()

       {
            var list = await _context.Logins.ToListAsync();
            return Ok();
        }
    }
}
