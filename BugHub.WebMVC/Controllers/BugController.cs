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
    public class BugController : Controller
    {
        // GET: Bug
        [Authorize]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BugService(userId);
            var model = service.GetBugs();

            return View(model);
        }

        //Get
        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BugService(userId);

            List<Employee> employees = service.GetEmployeeList().ToList();

            var query = from e in employees
                                select new SelectListItem()
                                {
                                  Value = e.EmployeeId.ToString(),
                                    Text = e.LastName,
                                    
                                };
            ViewBag.EmployeeId = query;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BugCreate model)
        {
            if (ModelState.IsValid) return View(model);
            
            var service = CreateBugService();

            if (service.CreateBug(model))
            {
                TempData["SaveResult"] = "Your Bug ticket was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "A Bug ticket could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBugService();
            var model = svc.GetBugById(id);

            return View(model);
        }
        private BugService CreateBugService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BugService(userId);
            return service;
        }
    }
}