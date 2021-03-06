﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using CIS420CON.Models;
using CIS420CON.Models.ViewModels;

namespace CIS420CON.Controllers
{
    public class UserManagementController : Controller
    {
        readonly ApplicationDbContext _db = new ApplicationDbContext();


        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var users = _db.Users;
            var model = new List<SelectUserRolesViewModel>();
            foreach (var user in users)
            {
                var u = new SelectUserRolesViewModel(user);
                u.Id = user.Id;
                model.Add(u);
            }
            return View(model);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            var Db = new ApplicationDbContext();
            var user = Db.Users.FirstOrDefault(u => u.Id == id);
            var model = new EditUserViewModel(user);
            return View(model);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Db = new ApplicationDbContext();
                var user = Db.Users.First(u => u.UserName == model.UserName);

                //Didn't implement ability to modify FirstName or LastName, but this is how you would do it.
                //user.FirstName = model.FirstName;
                //user.LastName = model.LastName;

                user.Email = model.Email;

                Db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                await Db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

    }
}