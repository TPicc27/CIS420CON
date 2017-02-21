using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS420CON.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        public string LastName { get; set; }
        
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public decimal GPA { get; set; }

        public string Standing { get; set; }

        public string HasGraduated { get; set; }

        public string CampusId { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}