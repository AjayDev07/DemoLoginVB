using Microsoft.EntityFrameworkCore;
using Mousetrackfunctionality.Models;

namespace Mousetrackfunctionality.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>Options):base(Options)
        {
                
        }
        public DbSet<MouseActivity>MouseActivities { get; set; }
    }
}
