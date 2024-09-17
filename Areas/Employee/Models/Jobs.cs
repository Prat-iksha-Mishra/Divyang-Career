using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DivyangPortalWeb.Areas.Employee.Models
{
    public class Jobs
    {
        public DropdownValuesResponse DropdownValuesResponse { get; set; }
        public int Id { get; set; }
        public string EmployeeId { get; set; }

        [Display(Name = "Job name*")]
        [Required(ErrorMessage = "Enter job name")]
        [RegularExpression(@"[A-Za-z\s]{3,}", ErrorMessage = "Job name can have alphabets & spaces with min size of 3.")]
        public string JobTitle { get; set; }

        [Display(Name = "Job Categories*")]
        [Required(ErrorMessage = "Select Job Categories")]
        public string JobCategories { get; set; }

        [Display(Name = "Job Type*")]
        [Required(ErrorMessage = "Select Job type")]
        public string JobType { get; set; }

        [Display(Name = "Description*")]
        [Required(ErrorMessage = "Please Enter description")]
        public string Description { get; set; }

        public string CareerLevel { get; set; }
        public string Experience { get; set; }
        public string Qualification { get; set; } 
        public string PrefrenceGender { get; set; }

        public string SalaryPayBy { get; set; } 
        public string Currency { get; set; }

        [Display(Name = "Min Salary")]
        public string MinSalary { get; set; }

        [Display(Name = "Max Salary")]
        public string MaxSalary { get; set; } 

        public string SalaryPaidPer { get; set; }
        public string CompanyName { get; set; } 

        [Display(Name = "Location*")]
        [Required(ErrorMessage = "Please enter the location")]
        public string Location { get; set; } 

        public string CoverImage { get; set; } 
        public string GalleryImage { get; set; }
        public string IntroductionVideo { get; set; }

        [Display(Name = "Apply Start Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter the application start date")]
        public DateTime ApplyStartDate { get; set; }

        [Display(Name = "Apply Last Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter the application last date")]
        public DateTime ApplyLastDate { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Updated Date")]
        [DataType(DataType.Date)]
        public DateTime UpdateDate { get; set; }

        [Display(Name = "Active")]
        public int IsActive { get; set; }
        public int Status { get; set; }
        public HttpPostedFileBase CoverImagePath { get; set; }
        public HttpPostedFileBase GalleryImagePath { get; set; }
        public HttpPostedFileBase IntroductionVideoPath { get; set; }


    }

}