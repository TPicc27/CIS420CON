using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using CIS420CON.Models;
using CIS420CON.Models.ViewModels;

namespace CIS420CON.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
 
        // GET: Student
        public ActionResult Index()
        {
            var students = db.Students.Select(s => new StudentIndexViewModel()
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                EnrollmentDate = s.EnrollmentDate
            });

            return View(students);
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
        [Authorize(Roles = "Advisors")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var student = new Student()
                {
                    Address = vm.Address,
                    City = vm.City,
                    EnrollmentDate = vm.EnrollmentDate,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    ZipCode = vm.ZipCode.ToString(),
                    State = vm.State
                };
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index", "Student");
            }

            return View(vm);
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

        [Authorize(Roles ="Advisors")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentIndexViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var student = db.Students.FirstOrDefault(s => s.Id == vm.Id);

                if (student != null)
                {
                    student.FirstName = vm.FirstName;
                    student.LastName = vm.LastName;
                    student.EnrollmentDate = vm.EnrollmentDate;
                }

                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
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

        [Authorize(Roles ="Advisor")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index", "Student");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult StudentReports()
        {
            return View();
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
