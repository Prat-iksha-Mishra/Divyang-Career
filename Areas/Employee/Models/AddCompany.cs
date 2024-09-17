using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Areas.Employee.Models
{
    public class AddCompany
    {
        public int EmployerId { get; set; }
        [Display(Name = "Company name*")]
        [Required(ErrorMessage = "Enter company name")]
        public string CompanyName { get; set; }
        [Display(Name = "Company categories*")]
        [Required(ErrorMessage = "Select categories")]
        public string CompanyCategories { get; set; }

        [AllowHtml]
        [Display(Name = "About company*")]
        [Required(ErrorMessage = "Enter about company")]
        public string CompanyAboutUs { get; set; }

        [Display(Name = "Website*")]
        [RegularExpression(@"^(http(s)?://)?(www\.)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}(/.*)?$", ErrorMessage = "Enter valid website url ")]
        [Required(ErrorMessage = "Enter website ")]
        public string CompanyWebsite { get; set; }

        [Display(Name = "Phone Number*")]
        [Required(ErrorMessage = "Enter phone number ")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email*")]
        [RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]{2,}$", ErrorMessage = "Enter valid email id ")]
        [Required(ErrorMessage = "Enter email ")]
        public string CompanyEmail { get; set; }

        [Display(Name = "Founded in")]
        public string FoundedIn { get; set; }
        public string CompanySize { get; set; }
        public HttpPostedFileBase CompanyLogo { get; set; }
        public HttpPostedFileBase CompanyCoverImages { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkdinUrl { get; set; }
        public string FaceBookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public HttpPostedFileBase GalleryImage { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string CompanyFullAddress { get; set; }

        public IEnumerable<SelectListItem> CompanyCategoriesOptions { get; set; }
        public IEnumerable<SelectListItem> CompanySizeDropDown { get; set; }
        public IEnumerable<SelectListItem> StateDropDown { get; set; }
        public IEnumerable<SelectListItem> DistrictDropDown { get; set; }

        public string PhoneCountryCode { get; set; }
        public string CompanyLogoName { get; set; }
        public string CompanyCoverImagesName { get; set; }
        public string GalleryImageName { get; set; }
    }
}