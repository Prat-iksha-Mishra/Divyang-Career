using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Areas.Employee.Controllers
{
    public class CompaniesController : Controller
    {
        // GET: Employee/Companies
        public ActionResult Companies()
        {
            return View();
        }
        public ActionResult Companiesdetails()
        {
            return View();
        }

        public ActionResult addnewcompany()
        {
            return View();
        }
    }
}