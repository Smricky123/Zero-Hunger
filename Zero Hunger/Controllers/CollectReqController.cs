using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class CollectReqController : Controller
    {
        private CRContext db = new CRContext();

        public ActionResult Index()
        {
            var collectRequests = db.CollectRequests.ToList();

            return View(collectRequests);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CollectReq collectRequest)
        {
            if (ModelState.IsValid)
            {
                collectRequest.RequestDate = DateTime.Now;

                db.CollectRequests.Add(collectRequest);
                db.SaveChanges();              
                return RedirectToAction("Index");
            }

            return View(collectRequest);
        }

        [HttpGet]
        public ActionResult Assign()
        {
            ViewBag.EmployeeList = new SelectList(db.Employees.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Assign(int id)
        {
            var collectReq = db.CollectRequests.Find(id);
            if (collectReq == null)
            {
                return HttpNotFound();
            }

            var employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            collectReq.CollectionDate = DateTime.Now;
            collectReq.EmployeeId = employee.Id;
            collectReq.Employee = employee;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult RemoveEmployee(int id)
        {
            var collectRequest = db.CollectRequests.Find(id);

            if (collectRequest == null)
            {
                return HttpNotFound();
            }

            collectRequest.EmployeeId = null;
            collectRequest.Employee = null;
            collectRequest.CollectionDate = null;
        
            
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}