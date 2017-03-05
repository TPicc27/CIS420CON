using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS420CON.Models.ViewModels
{
    public class AdvisorIndexViewModel
    {
        public IEnumerable<Student> NCStudentsList { get; set; }
        public IEnumerable<Event> AlertList { get; set; }
    }
}