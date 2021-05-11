using BugHub.Data;
using BugHub.Models;
using BugHub.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugHub.WebMVC.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            var model = service.GetProjects();

            return View(model);
        }

        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(userId);

            List<Employee> employees = service.GetEmployeeList().ToList();

            ViewData["EmployeeId"] = service.GetEmployees().Select(e => new SelectListItem
            {
                Text = e.FirstName + "  " + e.LastName,
                Value = e.EmployeeId.ToString()
            });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectCreate model)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service2 = new EmployeeService(userId);

            ViewData["EmployeeId"] = service2.GetEmployees().Select(e => new SelectListItem
            {
                Text = e.FirstName + "  " + e.LastName,
                Value = e.EmployeeId.ToString()
            });

            if (!ModelState.IsValid) return View(model);

            var service = CreateProjectService();

            if (service.CreateProject(model))
            {
                TempData["SaveResult"] = "Your Project was Created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Project could not be Created.");

                return View(model);           

            
        }

        public ActionResult Details(int id)
        {
            var svc = CreateProjectService();
            var model = svc.GetProjectById(id);

            return View(model);
        }
        private ProjectService CreateProjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            return service;
        }
    }
}