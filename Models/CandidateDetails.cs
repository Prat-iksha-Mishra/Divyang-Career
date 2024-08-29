using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DivyangPortalWeb.Models
{
    public class CandidateDetails
    {
        public string CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter email", AllowEmptyStrings = false)]
        [Display(Name = "Account or Email")]
        public string Email { get; set; }
        public string UserType { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter password", AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}