using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DivyangPortalWeb.Areas.Employee.Models;

namespace DivyangPortalWeb.Models
{
    public class SignUp
    {
        public List<Jobs> jobs { get; set; }
        public Jobs Job { get; set; }
        public DropdownValuesResponse DropdownValuesResponse { get; set; }
        public EmployerDetails EmployerDetails { get; set; }
        public CandidateDetails CandidateDetails { get; set; }
        public EmployerSignUp EmployerSignUp { get; set; }
        [Display(Name = "First name*")]
        [Required(ErrorMessage = "Enter first name")]
        [RegularExpression(@"[A-Za-z\s]{3,}", ErrorMessage = "First name can have alphabets & spaces with min size of 3.")]
        public string Firstname { get; set; }

        [Display(Name = "Last name")]
        [RegularExpression(@"[A-Za-z\s]{3,}", ErrorMessage = "Last name can have alphabets & spaces with min size of 3.")]
        public string Lastname { get; set; }

        [Display(Name = "User name*")]
        [Required(ErrorMessage = "Enter user name")]
        [RegularExpression(@"[a-zA-Z0-9]{3,}", ErrorMessage = "User name can have alphabets & spaces with min size of 3.")]
        [System.Web.Mvc.Remote("CheckUser", "SignUp", AdditionalFields = "UserType", ErrorMessage = "Username already exists!")]
        public string Username { get; set; }

        [Display(Name = "Email*")]
        [Required(ErrorMessage = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        [System.Web.Mvc.Remote("CheckEmail", "SignUp", AdditionalFields = "UserType", ErrorMessage = "Email already exists!")]
        public string Email { get; set; }

        [Display(Name = "Password*")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter password")]
        [RegularExpression(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$_-])(?=\S+$).{8,16}", ErrorMessage = "Password must contain: 8-16 characters at least 1 Uppercase and 1 Lowercase Alphabet, 1 Number and 1 Special Character")]
        public string Password { get; set; }

        [Display(Name = "PhoneNumber*")]
        [Required(ErrorMessage = "Enter phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage = "Phone number must contain 10 characters", MinimumLength = 10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number must be numeric")]
        public string PhoneNumber { get; set; }

        public string UserType { get; set; }
        public string CountryCode { get; set; }
    }
}