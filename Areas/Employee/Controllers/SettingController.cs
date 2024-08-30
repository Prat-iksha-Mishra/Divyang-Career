using DivyangPortalWeb.Areas.Employee.Models;
using DivyangPortalWeb.Model.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Areas.Employee.Controllers
{
    public class SettingController : Controller
    {
        // GET: Employee/Setting
        public ActionResult Setting()
        {
            ChangePassword ch = new ChangePassword();
            ch.CurrentPassword = "dhghsgdsfdfs";
            var model = new ChangePassword
            {
                CurrentPassword = "fffffffffffffff", // This is just for demonstration; do not expose the actual password.
                                                 // Populate other properties as needed
            };
            return View(model);
        }
        public async Task<ActionResult> CheangePassword(ChangePassword Model)
        {
            if (ModelState.IsValid)
            {
                Model.Email = Session["EmployeeEmail"].ToString();
                var res = await ApiClientFactory.Instance.ChangeEmployerPassword(Model);
                if (res.ReturnMessage == "Fail")
                {
                    TempData["ChangeEmployeePassword"] = "Invalid current password";
                    return Redirect(Request.UrlReferrer.ToString());
                }
                else
                {
                    TempData["ChangeEmployeePassword"] = "Password change successfully";
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