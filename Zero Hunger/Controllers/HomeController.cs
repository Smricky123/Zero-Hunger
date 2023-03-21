using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class HomeController : Controller
    {
        private CRContext db = new CRContext();

        public ActionResult Index()
        {
            var collectRequests = db.CollectRequests.Include("Employee").ToList();
            return View(collectRequests);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CollectReq collectRequest)
        {
            if (ModelState.IsValid)
            {
                db.CollectRequests.Add(collectRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(collectRequest);
        }

        public ActionResult Assign(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CollectReq collectRequest = db.CollectRequests.Find(id);

            if (collectRequest == null)
            {
                return HttpNotFound();
            }

            ViewBag.EmployeeList = new SelectList(db.Employees, "Id", "Name");
            return View(collectRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Assign(CollectReq collectRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collectRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeList = new SelectList(db.Employees, "Id", "Name", collectRequest.EmployeeId);
            return View(collectRequest);
        }
    }
}