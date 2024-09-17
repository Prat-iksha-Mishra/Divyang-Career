using DivyangPortalWeb.Areas.Employee.Models;
using DivyangPortalWeb.Model.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Areas.Employee.Controllers
{
    public class CompaniesController : Controller
    {
        // GET: Employee/Companies
        public async Task<ActionResult> Companies()
        {
            string Email = Session["EmployeeEmail"].ToString();
            List<FinalCompany> customers = new List<FinalCompany>();
            var Data=  await ApiClientFactory.Instance.GetCompanyList(Email);
            customers = Data.Data;
            return View(customers);
        }
        public async Task<ActionResult> Companiesdetails(int Id)
        {
            FinalCompany Details = new FinalCompany();
            var res = await ApiClientFactory.Instance.GetCompanyDataForDetail(Id.ToString());
            Details = res.Data;
            if(res.Data== null)
            {
                return RedirectToAction("employerlogin", "employerlogin", new { area = "" });
            }
            else
            {
                return View(Details);
            }
        }

        public async Task<ActionResult> addnewcompany(int Id=0)
        {
            var model = new AddCompany();
            if (Id != 0)
            {
                // Fetch company data for editing
                var res = await ApiClientFactory.Instance.GetCompanyEdit(Id.ToString());
                // Fill model with company details
                model.EmployerId = res.Data.Id;
                model.CompanyName = res.Data.CompanyName;
                model.CompanyCategories = res.Data.CompanyCategories;
                model.CompanyAboutUs = res.Data.CompanyAboutUs;
                model.CompanyWebsite = res.Data.CompanyWebsite;
                model.PhoneNumber = res.Data.PhoneNumber;
                model.CompanyEmail = res.Data.CompanyEmail;
                model.FoundedIn = res.Data.FoundedIn;
                model.CompanySize = res.Data.CompanySize;
                model.TwitterUrl = res.Data.TwitterUrl;
                model.LinkdinUrl = res.Data.LinkdinUrl;
                model.FaceBookUrl = res.Data.FaceBookUrl;
                model.InstagramUrl = res.Data.InstagramUrl;
                model.State = res.Data.State;
                model.District = res.Data.District;
                model.CompanyFullAddress = res.Data.CompanyFullAddress;
                model.CompanyLogoName = res.Data.CompanyLogo;
                model.CompanyCoverImagesName = res.Data.CompanyCoverImages;
                model.GalleryImageName = res.Data.GalleryImage;
            }
           
            // Populate the common dropdowns (shared for both add and edit)
            await PopulateDropdowns(model);
            foreach (var item in model.CompanyCategoriesOptions)
            {
                Console.WriteLine($"Text: {item.Text}, Value: {item.Value}, Selected: {item.Selected}");
            }
            return View(model);
        }
        private async Task PopulateDropdowns(AddCompany model)
        {
            model.CompanyCategoriesOptions = await GetDropdownOptions(Convert.ToInt32(model.CompanyCategories)); // For editing, the selected category is passed
            model.CompanySizeDropDown = await GetCompanySizeDropDown();
            model.StateDropDown = await GetStateDropDown();
            if (!string.IsNullOrEmpty(model.District))
            {
                model.DistrictDropDown = await GetDistricDropdownOptions(model.State,model.District);
            }
            else
            {
                model.DistrictDropDown = new List<SelectListItem>
                {
                    new SelectListItem { Value = "", Text = "Select district", Selected = true, Disabled = true }  // Placeholder option
                };
            }
        }
        //Here Change Password Start Here
        [HttpPost]
        public async Task<ActionResult> AddCompany(AddCompany model, string submit_company)
        {
            string CompanyLogo = "", CompanyCoverImages="", GalleryImage="";
            if (ModelState.IsValidField("AddCompany"))
            {
                if (model.CompanyLogo != null)
                {
                    // Save the profile image
                    string name = "";
                    string fileName = Path.GetFileNameWithoutExtension(model.CompanyLogo.FileName);
                    string extension = Path.GetExtension(model.CompanyLogo.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    name = fileName;
                    fileName = Path.Combine(Server.MapPath("~/Areas/Employee/Images/CompanyImage/"), fileName);
                    model.CompanyLogo.SaveAs(fileName);
                    CompanyLogo = name;
                }
                if (model.CompanyCoverImages != null)
                {
                    // Save the profile image
                    string name1 = "";
                    string fileName1 = Path.GetFileNameWithoutExtension(model.CompanyCoverImages.FileName);
                    string extension = Path.GetExtension(model.CompanyCoverImages.FileName);
                    fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + extension;
                    name1 = fileName1;
                    fileName1 = Path.Combine(Server.MapPath("~/Areas/Employee/Images/CompanyImage/"), fileName1);
                    model.CompanyCoverImages.SaveAs(fileName1);
                    CompanyCoverImages = name1;
                }
                if (model.GalleryImage != null)
                {
                    // Save the profile image
                    string name2 = "";
                    string fileName2 = Path.GetFileNameWithoutExtension(model.GalleryImage.FileName);
                    string extension = Path.GetExtension(model.GalleryImage.FileName);
                    fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension;
                    name2 = fileName2;
                    fileName2 = Path.Combine(Server.MapPath("~/Areas/Employee/Images/CompanyImage/"), fileName2);
                    model.GalleryImage.SaveAs(fileName2);
                    GalleryImage = name2;
                }
                if (submit_company == "Submit")
                {
                    
                    FinalCompany FC = new FinalCompany();
                    FC.Id = 0;
                    FC.EmployerId = Session["EmployeeEmail"].ToString();
                    FC.CompanyName = model.CompanyName ?? string.Empty;
                    FC.CompanyCategories = model.CompanyCategories ?? string.Empty;
                    FC.CompanyAboutUs = model.CompanyAboutUs ?? string.Empty;
                    FC.CompanyWebsite = model.CompanyWebsite ?? string.Empty;
                    FC.PhoneNumber = model.PhoneNumber ?? string.Empty;
                    FC.CompanyEmail = model.CompanyEmail ?? string.Empty;
                    FC.FoundedIn = model.FoundedIn ?? string.Empty;
                    FC.CompanySize = model.CompanySize ?? string.Empty;
                    FC.CompanyLogo = CompanyLogo ?? string.Empty;
                    FC.CompanyCoverImages = CompanyCoverImages ?? string.Empty;
                    FC.TwitterUrl = model.TwitterUrl ?? string.Empty;
                    FC.LinkdinUrl = model.LinkdinUrl ?? string.Empty;
                    FC.FaceBookUrl = model.FaceBookUrl ?? string.Empty;
                    FC.InstagramUrl = model.InstagramUrl ?? string.Empty;
                    FC.GalleryImage = GalleryImage ?? string.Empty;
                    FC.State = model.State ?? string.Empty;
                    FC.District = model.District ?? string.Empty;
                    FC.CompanyFullAddress = model.CompanyFullAddress ?? string.Empty;
                    FC.PhoneCountryCode = model.PhoneCountryCode ?? string.Empty;
                    var res = await ApiClientFactory.Instance.AddCompay(FC);
                    if (res.ReturnMessage == "Error")
                    {
                        TempData["AddCompanyPopUp"] = "Error try again later";
                        return Redirect(Request.UrlReferrer.ToString());
                    }
                    else
                    {
                        TempData["AddCompanyPopUp"] = "Company add successfully";
                        return Redirect(Request.UrlReferrer.ToString());
                    }
                }
                else
                {
                    FinalCompany FC = new FinalCompany();
                    FC.Id = 0;
                    FC.EmployerId = model.EmployerId.ToString();
                    FC.CompanyName = model.CompanyName ?? string.Empty;
                    FC.CompanyCategories = model.CompanyCategories ?? string.Empty;
                    FC.CompanyAboutUs = model.CompanyAboutUs ?? string.Empty;
                    FC.CompanyWebsite = model.CompanyWebsite ?? string.Empty;
                    FC.PhoneNumber = model.PhoneNumber ?? string.Empty;
                    FC.CompanyEmail = model.CompanyEmail ?? string.Empty;
                    FC.FoundedIn = model.FoundedIn ?? string.Empty;
                    FC.CompanySize = model.CompanySize ?? string.Empty;
                    FC.CompanyLogo = CompanyLogo ?? string.Empty;
                    FC.CompanyCoverImages = CompanyCoverImages ?? string.Empty;
                    FC.TwitterUrl = model.TwitterUrl ?? string.Empty;
                    FC.LinkdinUrl = model.LinkdinUrl ?? string.Empty;
                    FC.FaceBookUrl = model.FaceBookUrl ?? string.Empty;
                    FC.InstagramUrl = model.InstagramUrl ?? string.Empty;
                    FC.GalleryImage = GalleryImage ?? string.Empty;
                    FC.State = model.State ?? string.Empty;
                    FC.District = model.District ?? string.Empty;
                    FC.CompanyFullAddress = model.CompanyFullAddress ?? string.Empty;
                    FC.PhoneCountryCode = model.PhoneCountryCode ?? string.Empty;
                    var res = await ApiClientFactory.Instance.UpdateCompay(FC);
                    if (res.ReturnMessage == "Error")
                    {
                        TempData["AddCompanyPopUp"] = "Error try again later";
                        return Redirect(Request.UrlReferrer.ToString());
                    }
                    else
                    {
                        TempData["AddCompanyPopUp"] = "Update successfully";
                        return Redirect(Request.UrlReferrer.ToString());
                    }
                }
            }
            else
            {
                TempData["AddCompanyPopUp"] = "fill mandatory fields";
                return Redirect(Request.UrlReferrer.ToString());
            }  
        }
        public async Task<IEnumerable<SelectListItem>> GetDropdownOptions(int selectedCategoryId = 0)
        {
            var categories = await ApiClientFactory.Instance.CompanyCategories();

            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.CategoriesName,
                Value = c.Id.ToString(),
                Selected = (c.Id == selectedCategoryId) // Only the matching category should be selected
            }).ToList();

            // Add a placeholder only if no category is selected (for adding new company)
            if (selectedCategoryId == 0)
            {
                selectList.Insert(0, new SelectListItem
                {
                    Value = "",
                    Text = "Select a category",
                    Selected = true,
                    Disabled = true
                });
            }
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetCompanySizeDropDown()
        {
            var categories = await ApiClientFactory.Instance.CompanySize();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.CompanySizes,  
                Value = c.Id.ToString()  
            });
            return (IEnumerable<SelectListItem>)selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetStateDropDown()
        {
            var categories = await ApiClientFactory.Instance.BindState();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.StateName,
                Value = c.Id.ToString()
            });
            return (IEnumerable<SelectListItem>)selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetDistricDropdownOptions(string StateId = "", string District = "")
        {
            var Distric = await ApiClientFactory.Instance.BindDistict(StateId);

            var selectList = Distric.Data.Select(c => new SelectListItem
            {
                Text = c.DistrictName,
                Value = c.Id.ToString(),
                Selected = (c.Id.ToString() == District) // Only the matching category should be selected
            }).ToList();
            return selectList;
        }
        public async Task<JsonResult> GetDistricByState(string StateId="")
        {
            var Distric = await ApiClientFactory.Instance.BindDistict(StateId);
            var selectList = Distric.Data.Select(c => new SelectListItem
            {
                Text = c.DistrictName,
                Value = c.Id.ToString()
            });

            return Json(selectList, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> DeleteCompany(string CompanyId)
        {
            var Distric = await ApiClientFactory.Instance.DeleteCompany(CompanyId);
            return Json(new { result = Distric, JsonRequestBehavior.AllowGet });
        }
    }
}