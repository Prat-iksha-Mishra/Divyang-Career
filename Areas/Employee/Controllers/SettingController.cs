using DivyangPortalWeb.Areas.Employee.Models;
using DivyangPortalWeb.Model.Application;
using DivyangPortalWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Areas.Employee.Controllers
{
    public class SettingController : Controller
    {
        // GET: Employee/Setting
        public async Task<ActionResult> Setting()
        {
            string Email = Session["EmployeeEmail"].ToString();
            var res = await ApiClientFactory.Instance.GetEmployerDetails(Email);
            var model = new ChangePassword
            {
                EmployeeDetails = new EmployeeDetails
                {
                    EmployeeId = res.Data.EmployeeId,
                    Firstnames = res.Data.Firstnames,
                    Lastnames = res.Data.Lastnames,
                    Email = res.Data.Email,
                    //ProfileImagePath = Convert. res.Data.ProfileImagePath,
                    PhoneNumber = res.Data.PhoneNumber,
                    ImageName= res.Data.ImageName
                }
            };
            return View(model);
        }
        //Here Change Password Start Here
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
        public async Task<ActionResult> UpdateEmployeDetails(ChangePassword Model)
        {
            //if (ModelState.IsValid)
            if(ModelState.IsValidField("ChangePassword.EmployeeDetails"))
            {
                if (Model.EmployeeDetails.ProfileImagePath != null)
                {
                    // Save the profile image
                    string name = "";
                    string fileName = Path.GetFileNameWithoutExtension(Model.EmployeeDetails.ProfileImagePath.FileName);
                    string extension = Path.GetExtension(Model.EmployeeDetails.ProfileImagePath.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    name = fileName;
                    fileName = Path.Combine(Server.MapPath("~/Areas/Employee/Images/ProfileImage/"), fileName);
                    Model.EmployeeDetails.ProfileImagePath.SaveAs(fileName);
                    Model.EmployeeDetails.ImageName = name;
                }
                EmployeeDetails2 ED = new EmployeeDetails2();
                ED.Firstnames = Model.EmployeeDetails.Firstnames;
                ED.EmployeeId = Model.EmployeeDetails.EmployeeId;
                ED.Lastnames = Model.EmployeeDetails.Lastnames ?? string.Empty;
                ED.Email = Model.EmployeeDetails.Email;
                ED.PhoneNumber = Model.EmployeeDetails.PhoneNumber ?? string.Empty;
                ED.CountryCode = Model.EmployeeDetails.CountryCode;
                ED.ImageName = Model.EmployeeDetails.ImageName ?? string.Empty;
                ED.ProfileImagePath = Model.EmployeeDetails.ImageName ?? string.Empty;
                var res = await ApiClientFactory.Instance.UpdateEmployerDetails(ED);
                if (res.ReturnMessage == "Success")
                {
                    Session["EmployeeEmail"] = ED.Email;
                    TempData["UpdateProfile"] = "Update profile successfully";
                    return Redirect(Request.UrlReferrer.ToString());
                }
                else
                {
                    TempData["UpdateProfile"] = "Try again later";
                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
            else
            {
                TempData["UpdateProfile"] = "Fill mandatory fields";
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        //Here Change Password End Here
        //Here Check Email Is Exists Or Not Start Here
        public async Task<JsonResult> CheckEmail(ChangePassword model)
        {
            bool ifEmailExist = true;
            CheckEmail ch = new CheckEmail();
            ch.Email = model.EmployeeDetails.Email.ToString();
            var var = await ApiClientFactory.Instance.CheckEmailEmployer(ch);
                try
                {
                    if (var.ReturnMessage == "Already")
                    {
                        ifEmailExist = true;
                    }
                    else
                    {
                        ifEmailExist = false;
                    }
                    return Json(!ifEmailExist, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
        }
        //Here Check Email Is Exists Or Not End Here
    }
}