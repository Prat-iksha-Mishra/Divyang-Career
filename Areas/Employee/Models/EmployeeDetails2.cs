using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DivyangPortalWeb.Areas.Employee.Models
{
    public class EmployeeDetails2
    {
        public string EmployeeId { get; set; }
        public string Firstnames { get; set; }
        public string Lastnames { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfileImagePath { get; set; }
        public string ImageName { get; set; }
        public string CountryCode { get; set; }
    }
}