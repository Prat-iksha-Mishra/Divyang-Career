using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Areas.Employee.Controllers
{
    public class DashboardJobsController : Controller
    {
        // GET: Employee/DashboardJobs
        public ActionResult DashboardJobs()
        {
            return View();
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