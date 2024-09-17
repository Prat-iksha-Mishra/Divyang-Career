using DivyangPortalWeb.Areas.Employee.Models;
using DivyangPortalWeb.Model.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Areas.Employee.Controllers
{
    public class DashboardJobsController : Controller
    {
        public async Task<ActionResult> DashboardJobs(string jobTitle, int? status, string order)
        {
            List<Jobs> jobList = new List<Jobs>();
            var response = await ApiClientFactory.Instance.GetAllJobsLists();

            if (response.IsSuccess)
            {
                jobList = response.Data;

                if (!string.IsNullOrEmpty(jobTitle))
                {
                    jobList = jobList.Where(x => x.JobTitle.Contains(jobTitle)).ToList();
                }

                if (status.HasValue)
                {
                    jobList = jobList.Where(x => x.Status == status.Value).ToList();
                }

                if (!string.IsNullOrEmpty(order))
                {
                    if (order == "Newest")
                    {
                        jobList = jobList.OrderByDescending(x => x.CreateDate).ToList();
                    }
                    else if (order == "Oldest")
                    {
                        jobList = jobList.OrderBy(x => x.CreateDate).ToList();
                    }
                }

                return View(jobList);
            }
            else
            {
                return View(jobList); // Return empty job list if the API call fails
            }
        }

        public ActionResult employersjobdetails()
        {
            return View();
        } 
        public ActionResult candidatedetails()
        {
            return View();
        }
    }
}