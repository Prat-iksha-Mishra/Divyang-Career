using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Controllers
{
    public class FounderNoteController : Controller
    {
        // GET: FounderNote
        public ActionResult FounderNote()
        {
            return View("~/Views/Home/FounderNote.cshtml");
        }
    }
}