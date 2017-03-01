using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using CIS420CON.Models;


namespace CIS420CON.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentHome()
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
    }
}