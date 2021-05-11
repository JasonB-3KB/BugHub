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
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(userId);
            List<Employee> employees = service.GetEmployeeList().ToList();
            var model = service.GetEmployees();
            return View(model);
        }

        public ActionResult Create()
        {

            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreate model)
        {
            if (!ModelState.IsValid) return View(model);            

            var service = CreateEmployeeService();

            if (service.CreateEmployee(model))
            {
                TempData["SaveResult"] = "Employee Added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Employee could not be added.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeeById(id);

            return View(model);
        }
        private EmployeeService CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateEmployeeService();
            var detail = service.GetEmployeeById(id);

            var userId = Guid.Parse(User.Identity.GetUserId());
            var pservice = new ProjectService(userId);

            List<Project> projects = pservice.GetProjectList().ToList();

            ViewData["ProjectId"] = pservice.GetProjects().Select(e => new SelectListItem
            {
                Text = e.ProjectName,
                Value = e.ProjectId.ToString()
            });

            var model =
                new EmployeeEdit
                {
                    EmployeeId = detail.EmployeeId,
                    EmployeeEmail = detail.EmployeeEmail,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    ProjectId = detail.ProjectId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.EmployeeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateEmployeeService();

            if (service.UpdateEmployee(model))
            {
                TempData["SaveResult"] = "Employee was Updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Employee could not be Updated.");
            return View(model);
        }
    }
}