using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS420CON.Models.ViewModels
{
    public class ListUserViewModel
    {
        public IList<ApplicationUser> Users { get; set; }
        public IList<string> Roles { get; set; }
    }
}