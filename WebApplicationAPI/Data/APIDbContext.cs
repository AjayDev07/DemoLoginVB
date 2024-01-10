using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Data
{
    public class APIDbContext: DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext>Options):base(Options)
        {
                
        }
        public DbSet<Login>Logins { get; set; }
    }
}
