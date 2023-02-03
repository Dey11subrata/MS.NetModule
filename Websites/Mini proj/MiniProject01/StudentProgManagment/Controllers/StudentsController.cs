using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentProgManagment.Models;
//using StudentProgManagment.ViewModel;

namespace StudentProgManagment.Controllers
{
    public class StudentsController : Controller
    {
        // GET: StudentsController
        public ActionResult Index()
        {
            return View(Students.GetAllStudent());
        }

        // GET: StudentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentsController/Create
        public ActionResult Create()
        {
            StudentsViewModel studentsViewModel = new StudentsViewModel();
            List<SelectListItem> city = City.getAllCity();

            studentsViewModel.City = city;

            return View(studentsViewModel);
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Students stud)
        {
            try
            {
                Students.InsertStudent(stud);
                return RedirectToAction("Create", "Login");
                //return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Edit/5
        public ActionResult Edit(int id)
        {
            int? sid = HttpContext.Session.GetInt32("id");
            StudentsViewModel stud = new StudentsViewModel();
            Students s = Students.GetStudentById(sid);

            List<SelectListItem> lst = City.getAllCity();

            stud.UserName = s.UserName;
            stud.StudentId = s.StudentId;
            stud.FullName= s.FullName;
            stud.Gender = s.Gender;
            stud.EmailId = s.EmailId;
            stud.CityId = s.CityId;
            stud.Password = s.Password;
            stud.Phone = s.Phone;
            stud.City= lst;

            return View(stud);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, Students students)
        {
            try
            {
                Students.UpdateStudent(students);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
