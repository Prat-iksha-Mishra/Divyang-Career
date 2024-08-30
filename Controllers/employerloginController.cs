using DivyangPortalWeb.Model.Application;
using DivyangPortalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Controllers
{
    public class employerloginController : Controller
    {
        // GET: employerlogin
        public ActionResult employerlogin()
        {
            return View();
        }
        public async Task<ActionResult> LogIn(EmployerSignUp Model)
        {
            if (ModelState.IsValidField(Model.EmployerDetails.Emails) && ModelState.IsValidField(Model.EmployerDetails.Passwords))
            {
                var res = await ApiClientFactory.Instance.LogIn(Model.EmployerDetails.Emails, Model.EmployerDetails.Passwords);
                if (res.Data != null)
                {
                    if (res.Data.UserType == "Employer")
                    {
                        Session["EmployeeEmail"] = res.Data.Email;
                        Session["EmployeeUserName"] = res.Data.UserName;
                        Session["EmployeeId"] = res.Data.EmployeeId;
                        return RedirectToAction("Dashboard", "Dashboard", new { area = "Employee" });
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Dashboard", new { area = "Employee" });
                    }
                }
                else
                {
                    TempData["EmployerLogIn"] = "Invalid Email or Password";
                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
            else
            {
                TempData["EmployerLogIn"] = "Invalid Email or Password";
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        public async Task<ActionResult> Signup(EmployerSignUp Model)
        {
            if (ModelState.IsValid)
            {
                if (Model.UserTypes == "Employer")
                {
                    SignUp models = new SignUp();
                    models.Firstname = Model.Firstnames;
                    models.Lastname = Model.Lastnames;
                    models.Username = Model.Usernames;
                    models.Email = Model.Emails;
                    models.Password = Model.Passwords;
                    models.PhoneNumber = Model.PhoneNumbers;
                    models.CountryCode = Model.CountryCodes;
                    models.UserType = Model.UserTypes;
                    var res = await ApiClientFactory.Instance.SaveSignUp(models);
                    Session["EmployeeEmail"] = Model.Emails;
                    Session["EmployeeUserName"] = Model.Usernames;
                    return RedirectToAction("Dashboard", "Dashboard", new { area = "Employee" });
                }
                else
                {
                    return RedirectToAction("employerlogin", "employerlogin");
                }
            }
            else
            {
                return RedirectToAction("employerlogin", "employerlogin");
            }
        }
        //Here Check Email Is Exists Or Not Start Here
        public async Task<JsonResult> CheckEmail(string Emails, string UserTypes)
        {
            bool ifEmailExist = true;
            CheckEmail ch = new CheckEmail();
            ch.Email = Emails.ToString();
            if (UserTypes == "Employer")
            {
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
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        //Here Check Email Is Exists Or Not End Here
        //Here Check UserName Is Exists Or Not Start Here
        public async Task<JsonResult> CheckUser(string UserNames, string UserTypes)
        {
            bool ifEmailExist = true;
            if (UserTypes == "Employer")
            {
                CheckUserName ch = new CheckUserName();
                ch.UserName = UserNames.ToString();
                var var = await ApiClientFactory.Instance.CheckUsernameEmployer(ch);
                try
                {
                    if (var.ReturnMessage == "UserNameExists")
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
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

        }
        //Here Check UserName Is Exists Or Not End Here
    }
}