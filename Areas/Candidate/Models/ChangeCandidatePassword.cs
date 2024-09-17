using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DivyangPortalWeb.Areas.Candidate.Models
{
    public class ChangeCandidatePassword
    {
        public string Email { get; set; }

        [Display(Name = "Current password*")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter current password")]
        public string CurrentPassword { get; set; }

        [Display(Name = "New password*")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter new password")]
        [RegularExpression(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$_-])(?=\S+$).{8,16}", ErrorMessage = "Password must contain: 8-16 characters at least 1 Uppercase and 1 Lowercase Alphabet, 1 Number and 1 Special Character")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm new password*")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Confirm password should match with new password.")]
        public string ConfirmPassword { get; set; }
    }
}