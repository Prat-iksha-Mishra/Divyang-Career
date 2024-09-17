using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DivyangPortalWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View("~/Views/Home/Home.cshtml");
        }

        public ActionResult About()
        {
            return View("~/Views/Home/About.cshtml");
        }
        
        public ActionResult aboutteam()
        {
            return View("~/Views/Home/aboutteam.cshtml");
        }

        public ActionResult Contact()
        {
     
            return View("~/Views/Home/Contact.cshtml");
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            this.Response.Cache.SetExpires(System.DateTime.UtcNow.AddMinutes(-1));
            this.Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            this.Response.Cache.SetNoStore();
            return RedirectToAction("Index", "Home");
        }
    }
}