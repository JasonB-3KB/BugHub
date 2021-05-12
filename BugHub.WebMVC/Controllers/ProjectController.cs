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

        public ActionResult Edit(int id)
        {
            var service = CreateProjectService();
            var detail = service.GetProjectById(id);

            var userId = Guid.Parse(User.Identity.GetUserId());
            var eservice = new EmployeeService(userId);

            List<Employee> employees = eservice.GetEmployeeList().ToList();

            ViewData["EmployeeId"] = eservice.GetEmployees().Select(e => new SelectListItem
            {
                Text = e.FirstName + " " + e.LastName,
                Value = e.EmployeeId.ToString()
            });

            var model =
                new ProjectEdit
                {
                    ProjectId = detail.ProjectId,
                    ProjectName = detail.ProjectName,
                    EmployeeId = detail.EmployeeId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProjectEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ProjectId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProjectService();

            if (service.UpdateProject(model))
            {
                TempData["SaveResult"] = "Your Project was Updated.";
                return RedirectToAction("index");
            }

            ModelState.AddModelError("", "Your Project could not be Updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProjectService();
            var model = svc.GetProjectById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProjectService();

            service.DeleteProject(id);

            TempData["SaveResult"] = "Your Project was Deleted.";

            return RedirectToAction("Index");
        }

        private ProjectService CreateProjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            return service;
        }
    }
}