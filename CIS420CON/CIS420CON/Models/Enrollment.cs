using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS420CON.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public int StudnentId { get; set; }

        public int ProgramId { get; set; }


        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }

        public virtual Program Program { get; set; }
    }
}