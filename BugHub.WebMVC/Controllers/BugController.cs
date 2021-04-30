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
        public ActionResult Create(BugCreate model)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service2 = new EmployeeService(userId);

            ViewData["EmployeeId"] = service2.GetEmployees().Select(e => new SelectListItem
            {
                Text = e.FirstName + "  " + e.LastName,
                Value = e.EmployeeId.ToString()
            });

            if (!ModelState.IsValid) return View(model);
            
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

        public ActionResult Edit(int id)
        {
            var service = CreateBugService();
            var detail = service.GetBugById(id);
            var model =
                new BugEdit
                {
                    BugId = detail.BugId,
                    BugTitle = detail.BugTitle,
                    BugDescription = detail.BugDescription,
                    BugStatus = detail.BugStatus,
                    BugPriority = detail.BugPriority,
                    BugType = detail.BugType
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BugEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.BugId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBugService();

            if (service.UpdateBug(model))
            {
                TempData["SaveResult"] = "Your Bug was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Bug could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBugService();
            var model = svc.GetBugById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBugService();

            service.DeleteBug(id);

            TempData["SaveResult"] = "Your Bug was deleted";

            return RedirectToAction("Index");
        }
    }
}