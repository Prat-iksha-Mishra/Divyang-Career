using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Controllers
{
    public class SchemesController : Controller
    {
        // GET: Schemes
        public ActionResult Index()
        {
            return View("~/Views/Schemes/Schemes.cshtml");
        }

        public ActionResult SchemesDetails()
        {
            return View("~/Views/Schemes/SchemesDetails.cshtml");
        }
    }
}

