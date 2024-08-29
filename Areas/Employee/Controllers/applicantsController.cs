using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Areas.Employee.Controllers
{
    public class applicantsController : Controller
    {
        // GET: Employee/applicants
        public ActionResult applicants()
        {
            return View();
        }
    }
}