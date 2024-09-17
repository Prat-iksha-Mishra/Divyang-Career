using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Areas.Candidate.Controllers
{
    public class MyJobsController : Controller
    {
        // GET: Candidate/MyJobs
        public ActionResult MyJobs()
        {
            return View();
        }

        public ActionResult MyJobsDetails()
        {
            return View();
        }
    }
}