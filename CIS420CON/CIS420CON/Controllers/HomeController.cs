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
        public PartialViewResult getLoginList()
        {
            var students = _db.Students.FirstOrDefault();
            return PartialView("_LoginPartial", new LoginViewModel());
        }
        public PartialViewResult getRegisterList()
        {
            var students = _db.Students.FirstOrDefault();
            return PartialView("_RegisterPartial", new RegisterViewModel());
        }

    }
}