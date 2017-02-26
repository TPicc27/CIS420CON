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
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
 
        // GET: Student
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,MiddleName,Address,City,State,ZipCode,Email,PhoneNumber,EnrollmentDate,GPA,Standing,HelpGraduated,CampusId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,MiddleName,Address,City,State,ZipCode,Email,PhoneNumber,EnrollmentDate, GPA, Standing,HelpGraduated,CampusId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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

        //GPA Report for 4.0
        public ActionResult GetGpaReport1(decimal gpaThreshold)
        {

            var students = db.Students.Where(s => s.GPA >= gpaThreshold).ToList();

            return View("Index", students);
        }
        
        //GPA Report for 3.75
        public ActionResult GetGpaReport2(decimal gpaThreshold)
        {

            var students = db.Students.Where(s => s.GPA >= gpaThreshold).ToList();

            return View("Index", students);
        }

        //GPA Report for 3.5
        public ActionResult GetGpaReport3(decimal gpaThreshold)
        {

            var students = db.Students.Where(s => s.GPA >= gpaThreshold).ToList();

            return View("Index", students);
        }

        //GPA Report for 3.25
        public ActionResult GetGpaReport4(decimal gpaThreshold)
        {

            var students = db.Students.Where(s => s.GPA >= gpaThreshold).ToList();

            return View("Index", students);
        }

        //GPA Report for 3.0
        public ActionResult GetGpaReport5(decimal gpaThreshold)
        {

            var students = db.Students.Where(s => s.GPA >= gpaThreshold).ToList();

            return View("Index", students);
        }

    }
}
