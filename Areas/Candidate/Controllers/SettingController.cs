using DivyangPortalWeb.Areas.Candidate.Models;
using DivyangPortalWeb.Model.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Areas.Candidate.Controllers
{
    public class SettingController : Controller
    {
        // GET: Candidate/Setting
        public ActionResult Setting()
        {
            return View();
        }
        //Here Change Password Start Here
        public async Task<ActionResult> CheangeCandidatesPassword(ChangeCandidatePassword Model)
        {
            Model.Email = Session["CandidateEmail"].ToString();
            if (ModelState.IsValid)
            {
                var res = await ApiClientFactory.Instance.ChangeCandidatePassword(Model);
                if (res.ReturnMessage == "Fail")
                {
                    TempData["ChangeCandidatePassword"] = "Invalid current password";
                    return Redirect(Request.UrlReferrer.ToString());
                }
                else
                {
                    TempData["ChangeCandidatePassword"] = "Password change successfully";
                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
            else
            {
                return RedirectToAction("Setting", "Setting");
            }
        }
    }
}