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
            return View();
        }

        public ActionResult Advising()
        {
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

    }
}