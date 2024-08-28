using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Controllers
{
    public class JobsController : Controller
    {
        // GET: Jobs
        public ActionResult Index()
        {
            return View("~/Views/Jobs/Jobs.cshtml");
        }
        public ActionResult JobsDetails()
        {
            return View("~/Views/Jobs/JobsDetails.cshtml");
        }
        public ActionResult jobstiai()
        {
            return View("~/Views/Jobs/jobstiai.cshtml");
        }
    }
}