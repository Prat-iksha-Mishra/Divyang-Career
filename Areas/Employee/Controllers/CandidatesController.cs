using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Areas.Employee.Controllers
{
    public class CandidatesController : Controller
    {
        // GET: Employee/Candidates
        public ActionResult Candidates()
        {
            return View();
        }
    }
}