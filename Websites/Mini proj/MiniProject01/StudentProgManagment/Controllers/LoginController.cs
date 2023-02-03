using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentProgManagment.ViewModel;
using StudentProgManagment.Models;

namespace StudentProgManagment.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

    

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, LoginViewModel login)
        {
            try
            {
                if(login.UserName.Equals("admin")&& login.Password.Equals("admin"))
                {
                    HttpContext.Session.SetString("id", "admin");
                    return RedirectToAction("Index", "Admin");
                }

               int id = Students.validLogin(login);
                if(id>0)
                {
                    HttpContext.Session.SetInt32("id",id);
                    return RedirectToAction("Index", "Home");
                }
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

            return View();
        }

        public ActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Create", "Login");
        }

      
    }
}
