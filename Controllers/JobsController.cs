using DivyangPortalWeb.Areas.Employee.Models;
using DivyangPortalWeb.Model.Application;
using DivyangPortalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Controllers
{
    public class JobsController : Controller
    {
        public async Task<ActionResult> Jobs(string order, string key,string uniqueParam, string minSalary, string maxSalary, string rate) // Update 'key' to 'category'
        {
            var modelToReturn = new SignUp();
            var responseforjob = await ApiClientFactory.Instance.GetAllActiveJobsLists();
            List<Jobs> jobs = new List<Jobs>();

            if (responseforjob != null && responseforjob.Data != null)
            {
                jobs = responseforjob.Data.ToList();
            }

            // Apply order filtering
            if (!string.IsNullOrEmpty(order))
            {
                if (order == "Newest")
                {
                    jobs = jobs.OrderByDescending(x => x.CreateDate).ToList();
                }
                else if (order == "Oldest")
                {
                    jobs = jobs.OrderBy(x => x.CreateDate).ToList();
                }
            }

            // Apply category filtering based on the category key
            if (!string.IsNullOrEmpty(key) && uniqueParam == "Category")
            {
                jobs = jobs.Where(x => x.JobCategories.Contains(key)).ToList(); 
            }
            if (!string.IsNullOrEmpty(key) && uniqueParam == "Type")
            {
                jobs = jobs.Where(x => x.JobType.Contains(key)).ToList(); 
            }
            if (!string.IsNullOrEmpty(key) && uniqueParam == "Career")
            {
                jobs = jobs.Where(x => x.CareerLevel.Contains(key)).ToList(); 
            }
            if (!string.IsNullOrEmpty(key) && uniqueParam == "Experience")
            {
                jobs = jobs.Where(x => x.Experience.Contains(key)).ToList(); 
            }
            if (!string.IsNullOrEmpty(key) && uniqueParam == "Qualify")
            {
                jobs = jobs.Where(x => x.Qualification.Contains(key)).ToList(); 
            }
            if (!string.IsNullOrEmpty(key) && uniqueParam == "Gender")
            {
                jobs = jobs.Where(x => x.PrefrenceGender.Contains(key)).ToList();
            }
            // Apply salary filtering
            if (!string.IsNullOrEmpty(minSalary))
            {
                if (decimal.TryParse(minSalary, out var minSalaryValue))
                {
                    jobs = jobs.Where(x => Convert.ToInt32(x.MinSalary) >= minSalaryValue).ToList();
                }
            }

            if (!string.IsNullOrEmpty(maxSalary))
            {
                if (decimal.TryParse(maxSalary, out var maxSalaryValue))
                {
                    jobs = jobs.Where(x => Convert.ToInt32(x.MaxSalary) <= maxSalaryValue).ToList();
                }
            }

            if (!string.IsNullOrEmpty(rate))
            {
                jobs = jobs.Where(x => x.SalaryPaidPer == rate).ToList(); // Assuming SalaryRate is a property in Jobs
            }
            modelToReturn.jobs = jobs;
            var response = await ApiClientFactory.Instance.GetAllDropDownValues();
            var dropdownValuesResponse = new DropdownValuesResponse();


            // Check if dropdown values API call succeeded
            if (response.IsSuccess && response.Data != null)
            {
                // Populate and filter dropdown values based on the constants
                var allDropDownValues = response.Data;

                dropdownValuesResponse.JobCategories = allDropDownValues
                    .Where(x => x.Constant == "Category")
                    .ToList();

                dropdownValuesResponse.JobType = allDropDownValues
                    .Where(x => x.Constant == "JobType")
                    .ToList();

                dropdownValuesResponse.CareerLevel = allDropDownValues
                    .Where(x => x.Constant == "CareerLevel")
                    .ToList();

                dropdownValuesResponse.Experience = allDropDownValues
                    .Where(x => x.Constant == "Experience")
                    .ToList();

                dropdownValuesResponse.Qualification = allDropDownValues
                    .Where(x => x.Constant == "Qualification")
                    .ToList();

                dropdownValuesResponse.PrefrenceGender = allDropDownValues
                    .Where(x => x.Constant == "Gender")
                    .ToList();

                dropdownValuesResponse.SalaryPayBy = allDropDownValues
                    .Where(x => x.Constant == "SalaryPayBy")
                    .ToList();

                dropdownValuesResponse.Currency = allDropDownValues
                    .Where(x => x.Constant == "RangeCurrency")
                    .ToList();

                dropdownValuesResponse.SalaryPaidPer = allDropDownValues
                    .Where(x => x.Constant == "SalaryPaidPer")
                    .ToList();

                dropdownValuesResponse.Locations = allDropDownValues
                    .Where(x => x.Constant == "Location")
                    .ToList();

                dropdownValuesResponse.IsActive = allDropDownValues
                    .Where(x => x.Constant == "IsActive")
                    .ToList();
                dropdownValuesResponse.Status = allDropDownValues
                    .Where(x => x.Constant == "Status")
                    .ToList();
                dropdownValuesResponse.Company = allDropDownValues
                    .Where(x => x.Constant == "Company")
                    .ToList();

                // Assign the populated dropdown values to the model
                modelToReturn.DropdownValuesResponse = dropdownValuesResponse;
            }  // Create the wrapper model

            return View(modelToReturn);
        }

        public async Task<ActionResult> JobsDetails(string id)
        {
            // Fetch job details by its ID
            var responseforjob = await ApiClientFactory.Instance.GetJobByItsId(id);
            SignUp signUp = new SignUp();

            if (responseforjob != null && responseforjob.Data != null)
            {
                signUp.Job = responseforjob.Data;
            }
            //// Get the first EmployerId from the jobs collection
            //var employerId = signUp.Job.EmployeeId;

            //if (employerId != null)
            //{
            //    var companyResponse = await ApiClientFactory.Instance.GetCompanyByItsId(employerId);

            //    // Handle the companyResponse object appropriately
            //    Console.WriteLine(companyResponse);  // Assuming the response is already in string format
            //}

            // Return the job details to the view
            return View("~/Views/Jobs/JobsDetails.cshtml", signUp);
        }


    }
}