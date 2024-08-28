using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Areas.Employee.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Employee/Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}