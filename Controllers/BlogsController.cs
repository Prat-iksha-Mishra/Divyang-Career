using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Controllers
{
    public class BlogsController : Controller
    {
        // GET: Blogs
        public ActionResult Index()
        {
            return View("~/Views/Blogs/Blogs.cshtml");
        }

        public ActionResult Blogdetails()
        {
            return View("~/Views/Blogs/Blogdetails.cshtml");
        }
    }
}