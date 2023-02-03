using Microsoft.AspNetCore.Mvc;
using StudentProgManagment.Models;
using System.Diagnostics;

namespace StudentProgManagment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int? id = HttpContext.Session.GetInt32("id");
            if(id>0)
            {
                Students s = Students.GetStudentById(id);
                ViewBag.studentName = s.FullName;
                return View();
            }
            return RedirectToAction("Create", "Login");
          
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
    }
}