using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using CIS420CON.Models;
using CIS420CON.Models.ViewModels;



namespace CIS420CON.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext _db = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ClinicalCompliance()
        {
            return View();
        }

        public ActionResult ProgramofStudy()
        {
            return View();
        }

        public ActionResult Alerts()
        {
            DateTime start = DateTime.Now,
                end = start.AddDays(7);

            var viewModel = new StudentIndexViewModel()
            {
                //select only events within 7 days of current date
                AlertList = _db.Events.Where(d => d.StartDate > start)
            };
            return View(viewModel);
        }

        public ActionResult Advising()
        {
            //currently just hard coded data, need to link student id to corresponding advisor id somehow
            ViewBag.FullName = "Joe Black";
            ViewBag.Title = "Undergraduate Advisor";
            ViewBag.Description = "Advises M-Z Lower Division Traditional Students";
            ViewBag.WhereWhen = "HSC Advising Center, Room102A, Mon, Thurs, Fri from 8:30am - 3:30pm";
            ViewBag.Email = "noemail@gmail.com";

            return View();
        }

        public ActionResult StudentCalendar()
        {
            return View();
        }

        public ActionResult StudentHome()
        {
            var viewModel = new HomeIndexViewModel()
            {
                StudentsList = _db.Students.Take(2),
                TodosList = _db.Events.Take(2)
            };
            return View(viewModel);
        }

        public PartialViewResult GetStudentsList()
        {
            var students = _db.Students.Take(2);
            return PartialView("StudentsPartial", students);
        }

        public PartialViewResult GetTodosList()
        {
            var todos = _db.Events.Take(2);

            return PartialView("TodosPartial", todos);
        }

        public PartialViewResult GetAlertList()
        {
            var alert = _db.Events.Take(2);
            //need to filter events somehow (upcoming events this week)
            return PartialView("_AlertsPartial", alert);
        }

    }
}