using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DivyangPortalWeb.Areas.Employee.Models
{
    public class EmployeeDetails
    {
        public string EmployeeId { get; set; }
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Enter first name")]
        [RegularExpression(@"[A-Za-z\s]{3,}", ErrorMessage = "First name can have alphabets & spaces with min size of 3.")]
        public string Firstnames { get; set; }
        [Display(Name = "Last name")]
        public string Lastnames { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        [System.Web.Mvc.Remote("CheckEmail", "Setting", AdditionalFields = "EmployeeDetails.Email", ErrorMessage = "Email already exists!")]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        //[ValidateFileExtension(new string[] { ".jpg", ".jpeg", ".png" })]
        public HttpPostedFileBase ProfileImagePath { get; set; }
        public string ImageName { get; set; }
        public string CountryCode { get; set; }

    }
}