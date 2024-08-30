using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DivyangPortalWeb.Models
{
    public class EmployerDetails1
    {
        public string EmployeeIds { get; set; }
        public string FirstNames { get; set; }
        public string LastNames { get; set; }
        public string UserNames { get; set; }
        [Required(ErrorMessage = "Please enter email", AllowEmptyStrings = false)]
        [Display(Name = "Account or Email")]
        public string Emails { get; set; }
        public string UserTypes { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter password", AllowEmptyStrings = false)]
        public string Passwords { get; set; }
    }
}