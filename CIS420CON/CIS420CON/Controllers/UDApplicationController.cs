using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CIS420CON.Models;

namespace CIS420CON.Controllers
{
    public class UDApplicationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UDApplication
        public ActionResult Index()
        {
            return View(db.UDApplications.ToList());
        }

        // GET: UDApplication/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UDApplication uDApplication = db.UDApplications.Find(id);
            if (uDApplication == null)
            {
                return HttpNotFound();
            }
            return View(uDApplication);
        }

        // GET: UDApplication/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UDApplication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,LastName,Email,Address1,Address2,City,State,ZipCode,HomePhone,CellPhone,CampusId,SelectProgram,Semester,CurrentCourses,PersonalQualties,HealthCare,Crimes,SchoolTrouble,HonorablyDischarge,DischargedEmployment,Harassment,DrugsOrAlcohol,DrugsOrAlcoholEssay,AccurateKnowledge")] UDApplication uDApplication)
        {
            if (ModelState.IsValid)
            {
                db.UDApplications.Add(uDApplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uDApplication);
        }

        // GET: UDApplication/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UDApplication uDApplication = db.UDApplications.Find(id);
            if (uDApplication == null)
            {
                return HttpNotFound();
            }
            return View(uDApplication);
        }

        // POST: UDApplication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,Email,Address1,Address2,City,State,ZipCode,HomePhone,CellPhone,CampusId,SelectProgram,Semester,CurrentCourses,PersonalQualties,HealthCare,Crimes,SchoolTrouble,HonorablyDischarge,DischargedEmployment,Harassment,DrugsOrAlcohol,DrugsOrAlcoholEssay,AccurateKnowledge")] UDApplication uDApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uDApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uDApplication);
        }

        // GET: UDApplication/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UDApplication uDApplication = db.UDApplications.Find(id);
            if (uDApplication == null)
            {
                return HttpNotFound();
            }
            return View(uDApplication);
        }

        // POST: UDApplication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UDApplication uDApplication = db.UDApplications.Find(id);
            db.UDApplications.Remove(uDApplication);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
