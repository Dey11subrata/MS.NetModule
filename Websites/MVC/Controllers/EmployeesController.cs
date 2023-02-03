using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        public ActionResult Index()
        {

            List<Employee> list = new List<Employee>();
            list.Add(new Employee { EmpNo = 002, Name = "Name2", Basic = 10000, DeptNo = 11 });
            list.Add(new Employee { EmpNo = 003, Name = "Name3", Basic = 10000, DeptNo = 20 });
            list.Add(new Employee { EmpNo = 004, Name = "Name4", Basic = 10000, DeptNo = 80 });
            list.Add(new Employee { EmpNo = 005, Name = "Name5", Basic = 10000, DeptNo = 1 });
            list.Add(new Employee { EmpNo = 006, Name = "Name6", Basic = 10000, DeptNo = 101 });
            list.Add(new Employee { EmpNo = 007, Name = "Name7", Basic = 10000, DeptNo = 114 });
            list.Add(new Employee { EmpNo = 008, Name = "Name8", Basic = 10000, DeptNo = 211 });
            return View(list);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id=0)
        {
            Employee obj = new Employee();
            obj.EmpNo = id;
            obj.Name = "Name";
            obj.DeptNo = 10;
            obj.Basic = 10000;
            return View(obj);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Employee obj)
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

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
           
            return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
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
