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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BugCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }


            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BugService(userId);

            service.CreateBug(model);

            return RedirectToAction("Index");
        }
    }
}