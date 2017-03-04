using CIS420CON.Models;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;

[assembly: OwinStartupAttribute(typeof(CIS420CON.Startup))]
namespace CIS420CON
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("SuperAdmin"))
            {
                var role = new IdentityRole();
                role.Name = "SuperAdmin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "superadmin01@gmail.com";
                user.Email = "superadmin01@gmail.com";

                string userPWD = "card007";
                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "SuperAdmin");
                }

            }
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "admin01@gmail.com";
                user.Email = "admin01@gmail.com";

                string userPWD = "card008";
                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }

            }
            if (!roleManager.RoleExists("Advisors"))
            {
                var role = new IdentityRole();
                role.Name = "Advisors";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "advisors01@gmail.com";
                user.Email = "advisors01@gmail.com";

                string userPWD = "card009";
                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Advisors");
                }
            }
                if (!roleManager.RoleExists("Student"))
                {
                    var role = new IdentityRole();
                    role.Name = "Student";
                    roleManager.Create(role);

                    var user = new ApplicationUser();
                    user.UserName = "student01@gmail.com";
                    user.Email = "student01@gmail.com";

                    string userPWD = "card010";
                    var chkUser = UserManager.Create(user, userPWD);

                    if (chkUser.Succeeded)
                    {
                        var result1 = UserManager.AddToRole(user.Id, "Student");
                    }


                }
            }
    }
}
