using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DivyangPortalWeb.Models
{
    public class EmployerSignUp
    {
        public EmployerDetails1 EmployerDetails { get; set; }
        [Display(Name = "First name*")]
        [Required(ErrorMessage = "Enter first name")]
        [RegularExpression(@"[A-Za-z\s]{3,}", ErrorMessage = "First name can have alphabets & spaces with min size of 3.")]
        public string Firstnames { get; set; }

        [Display(Name = "Last name")]
        [RegularExpression(@"[A-Za-z\s]{3,}", ErrorMessage = "Last name can have alphabets & spaces with min size of 3.")]
        public string Lastnames { get; set; }

        [Display(Name = "User name*")]
        [Required(ErrorMessage = "Enter user name")]
        [RegularExpression(@"[a-zA-Z0-9]{3,}", ErrorMessage = "User name can have alphabets & spaces with min size of 3.")]
        [System.Web.Mvc.Remote("CheckUser", "employerlogin", AdditionalFields = "UserTypes", ErrorMessage = "Username already exists!")]
        public string Usernames { get; set; }

        [Display(Name = "Email*")]
        [Required(ErrorMessage = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        [System.Web.Mvc.Remote("CheckEmail", "employerlogin", AdditionalFields = "UserTypes", ErrorMessage = "Email already exists!")]
        public string Emails { get; set; }

        [Display(Name = "Password*")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter password")]
        [RegularExpression(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$_-])(?=\S+$).{8,16}", ErrorMessage = "Password must contain: 8-16 characters at least 1 Uppercase and 1 Lowercase Alphabet, 1 Number and 1 Special Character")]
        public string Passwords { get; set; }

        [Display(Name = "PhoneNumber*")]
        [Required(ErrorMessage = "Enter phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage = "Phone number must contain 10 characters", MinimumLength = 10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number must be numeric")]
        public string PhoneNumbers { get; set; }

        public string UserTypes { get; set; }
        public string CountryCodes { get; set; }
    }
}