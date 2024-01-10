using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mousetrackfunctionality.Data;
using Mousetrackfunctionality.Models;

namespace Mousetrackfunctionality.Controllers
{
    public class MouseActivityController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MouseActivityController(ApplicationDbContext context)
        {
            _context = context;    
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.MouseActivities.ToListAsync());
        }
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,XCoordinate,YCoordinate,Timestamp")] MouseActivity mouseActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mouseActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mouseActivity);
        }
        private bool MouseActivityExists(int id)
        {
            return _context.MouseActivities.Any(e => e.Id == id);
        }

    }
}
