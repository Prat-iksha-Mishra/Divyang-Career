using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DivyangPortalWeb.Areas.Employee.Models
{
    public class JobModelAsApi
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string JobTitle { get; set; }
        public string JobCategories { get; set; }
        public string JobType { get; set; }
        public string Description { get; set; }
        public string CareerLevel { get; set; }
        public string Experience { get; set; }
        public string Qualification { get; set; }
        public string PrefrenceGender { get; set; }
        public string SalaryPayBy { get; set; }
        public string Currency { get; set; }
        public string MinSalary { get; set; }
        public string MaxSalary { get; set; }
        public string SalaryPaidPer { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string CoverImage { get; set; }
        public string GalleryImage { get; set; }
        public string IntroductionVideo { get; set; }
        public DateTime ApplyStartDate { get; set; }
        public DateTime ApplyLastDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int IsActive { get; set; }
        public int Status { get; set; }

    }
}