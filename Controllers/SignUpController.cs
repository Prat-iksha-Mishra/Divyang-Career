using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DivyangPortalWeb.Model.Application;
using DivyangPortalWeb.Models;

namespace DivyangPortalWeb.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp Start Here
        public async Task<ActionResult> Signup(SignUp Model)
        {
            if (ModelState.IsValid)
            {
                if(Model.UserType == "Employer")
                {
                    var res = await ApiClientFactory.Instance.SaveSignUp(Model);
                    Session["EmployeeEmail"] = Model.Email;
                    Session["EmployeeUserName"] = Model.Username;
                    return RedirectToAction("Dashboard", "Dashboard", new { area = "Employee" });
                }
                else
                {
                    return RedirectToAction("employerlogin", "employerlogin");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        // GET: SignUp End Here
        //Here Check Email Is Exists Or Not Start Here
        public async Task<JsonResult> CheckEmail(string Email, string Type)
        {
            bool ifEmailExist = true;
            CheckEmail ch = new CheckEmail();
            ch.Email = Email.ToString();
            if (Type == "Employer")
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
        public async Task<JsonResult> CheckUser(string UserName, string Type)
        {
            bool ifEmailExist = true;
            if(Type== "Employer")
            {
                CheckUserName ch = new CheckUserName();
                ch.UserName = UserName.ToString();
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
        //Get Login Data Start Here
        public async Task<ActionResult> LogIn(SignUp Model)
        {
            if (ModelState.IsValidField(Model.EmployerDetails.Email) && ModelState.IsValidField(Model.EmployerDetails.Password))
            {
                var res = await ApiClientFactory.Instance.LogIn(Model.EmployerDetails.Email, Model.EmployerDetails.Password);
                if (res.Data != null)
                {
                    if(res.Data.UserType== "Employer")
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
                    TempData["CheckLogIn"] = "Invalid Email or Password";
                    TempData["ShowLoginPopup"] = "true"; // Indicate that the popup should be shown again
                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
            else
            {
                TempData["CheckLogIn"] = "Invalid Email or Password";
                TempData["ShowLoginPopup"] = "true"; // Indicate that the popup should be shown again
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        //Get Login Data End Here
    }
}