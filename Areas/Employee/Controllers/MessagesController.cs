using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Areas.Employee.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Employee/Messages
        public ActionResult Messages()
        {
            return View();
        }
    }
}