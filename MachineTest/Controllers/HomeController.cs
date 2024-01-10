using DAL.IRepository;
using DAL.Repository;
using MachineTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MachineTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginRepo _LoginRepo;


        public HomeController(ILogger<HomeController> logger, ILoginRepo loginRepo)
        {
            _logger = logger;
            _LoginRepo = loginRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]  
        public IActionResult Login(string email)
        {
            var ss = _LoginRepo.UserLogin(email);
            return Json(ss);
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var stu = _LoginRepo.GetAllStudent();
            return View(stu);
        }

        [HttpPost]
        public IActionResult Dashboard(string fname, string lname, string email)
        {
            var ss = _LoginRepo.AddPerson(fname, lname, email);
            return Json(ss);
        }


        [HttpPost]
		public IActionResult AddPerson(string fname,string lname, string email)
		{
			var ss = _LoginRepo.AddPerson(fname, lname, email);
			return Json(ss);
		}
	}
}