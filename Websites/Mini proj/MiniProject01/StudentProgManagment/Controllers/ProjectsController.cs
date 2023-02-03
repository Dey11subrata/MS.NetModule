using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentProgManagment.Models;

namespace StudentProgManagment.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: ProjectsController
        public ActionResult Index()
        {
            int? id = HttpContext.Session.GetInt32("id");

            if (id > 0)
            {
                return View(Projects.GetProjectsByStudentId(id));
            }

            return RedirectToAction("Create", "Login");
        }

        // GET: ProjectsController/Details/5
        public ActionResult Details(int id)
        {
            int? sid = HttpContext.Session.GetInt32("id");

            if (sid > 0)
            {
                return View(Projects.GetProjectsById(id));
            }

            return RedirectToAction("Create", "Login");

            
        }

        // GET: ProjectsController/Create
        public ActionResult Create()
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id > 0)
            {
                return View();
            }

            return RedirectToAction("Create", "Login");
         
        }

        // POST: ProjectsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Projects project)
        {
            try
            {
                Projects.InsertProjects(project);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectsController/Edit/5
        public ActionResult Edit(int id)
        {
            int? sid = HttpContext.Session.GetInt32("id");

            if (sid > 0)
            {
                return View(Projects.GetProjectsById(id));
            }

            return RedirectToAction("Create", "Login");
            
        }

        // POST: ProjectsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, Projects project)
        {
            try
            {
                Projects.UpdateProject(project);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectsController/Delete/5
        public ActionResult Delete(int id)
        {
            int? sid = HttpContext.Session.GetInt32("id");

            if (sid > 0)
            {
                return View(Projects.GetProjectsById(id));
            }

            return RedirectToAction("Create", "Login");
            
        }

        // POST: ProjectsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int ProjectId, IFormCollection collection)
        {
            try
            {
                Projects.DeleteProject(ProjectId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
