using DivyangPortalWeb.Areas.Employee.Models;
using DivyangPortalWeb.Model.Application;
using DivyangPortalWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Areas.Employee.Controllers
{

    public class postjobsController : Controller
    {
        // GET: Employee/postjobs
        public async Task<ActionResult> PostJobs(Jobs model, string id)
        {
            // Initialize a new Jobs model to populate
            var modelToReturn = new Jobs();

            // Check if the job ID is provided and fetch job details
            if (!string.IsNullOrEmpty(id))
            {
                var res = await ApiClientFactory.Instance.GetJobByItsId(id);

                if (res == null || res.Data == null)
                {
                    // If job not found, return an error
                    return HttpNotFound();
                }

                // Map the fetched job details to the model
                modelToReturn = new Jobs
                {
                    Id = res.Data.Id,
                    JobTitle = res.Data.JobTitle,
                    EmployeeId = res.Data.EmployeeId,
                    JobCategories = res.Data.JobCategories,
                    JobType = res.Data.JobType,
                    Description = res.Data.Description,
                    CareerLevel = res.Data.CareerLevel,
                    Experience = res.Data.Experience,
                    Qualification = res.Data.Qualification,
                    PrefrenceGender = res.Data.PrefrenceGender,
                    SalaryPayBy = res.Data.SalaryPayBy,
                    Currency = res.Data.Currency,
                    MinSalary = res.Data.MinSalary,
                    MaxSalary = res.Data.MaxSalary,
                    SalaryPaidPer = res.Data.SalaryPaidPer,
                    CompanyName = res.Data.CompanyName,
                    Location = res.Data.Location,
                    CoverImage = res.Data.CoverImage,
                    GalleryImage = res.Data.GalleryImage,
                    IsActive = res.Data.IsActive,
                    Status = res.Data.Status,
                    ApplyStartDate = res.Data.ApplyStartDate,
                    ApplyLastDate = res.Data.ApplyLastDate,
                    UpdateDate = res.Data.UpdateDate,
                    CreateDate = DateTime.UtcNow,
                    IntroductionVideo = res.Data.IntroductionVideo,
                };
                // Combine the relative path with the stored image name to prepopulate the image in the view
                if (!string.IsNullOrEmpty(res.Data.CoverImage))
                {
                    // Assuming that GalleryImage only stores the filename, prepend the path to it
                    var imagePath = Url.Content($"~/Areas/Employee/Images/JobImages/{res.Data.GalleryImage}");
                    model.CoverImage = imagePath;  // Use the full URL path for prepopulating in the form
                }
                if (!string.IsNullOrEmpty(res.Data.GalleryImage))
                {
                    // Assuming that GalleryImage only stores the filename, prepend the path to it
                    var imagePath = Url.Content($"~/Areas/Employee/Images/JobImages/{res.Data.GalleryImage}");
                    model.CoverImage = imagePath;  // Use the full URL path for prepopulating in the form
                }
                // Prepopulate Introduction Video
                if (!string.IsNullOrEmpty(res.Data.IntroductionVideo))
                {
                    var videoPath = Url.Content($"~/Areas/Employee/Images/JobImages/{res.Data.IntroductionVideo}");
                    model.IntroductionVideo = videoPath;
                }
            }

            // Fetch dropdown values for the form
            var response = await ApiClientFactory.Instance.GetAllDropDownValues();
            var dropdownValuesResponse = new DropdownValuesResponse();

            // Check if dropdown values API call succeeded
            if (response.IsSuccess && response.Data != null)
            {
                // Populate and filter dropdown values based on the constants
                var allDropDownValues = response.Data;

                dropdownValuesResponse.JobCategories = allDropDownValues
                    .Where(x => x.Constant == "Category")
                    .ToList();

                dropdownValuesResponse.JobType = allDropDownValues
                    .Where(x => x.Constant == "JobType")
                    .ToList();

                dropdownValuesResponse.CareerLevel = allDropDownValues
                    .Where(x => x.Constant == "CareerLevel")
                    .ToList();

                dropdownValuesResponse.Experience = allDropDownValues
                    .Where(x => x.Constant == "Experience")
                    .ToList();

                dropdownValuesResponse.Qualification = allDropDownValues
                    .Where(x => x.Constant == "Qualification")
                    .ToList();

                dropdownValuesResponse.PrefrenceGender = allDropDownValues
                    .Where(x => x.Constant == "Gender")
                    .ToList();

                dropdownValuesResponse.SalaryPayBy = allDropDownValues
                    .Where(x => x.Constant == "SalaryPayBy")
                    .ToList();

                dropdownValuesResponse.Currency = allDropDownValues
                    .Where(x => x.Constant == "RangeCurrency")
                    .ToList();

                dropdownValuesResponse.SalaryPaidPer = allDropDownValues
                    .Where(x => x.Constant == "SalaryPaidPer")
                    .ToList();

                dropdownValuesResponse.Locations = allDropDownValues
                    .Where(x => x.Constant == "Location")
                    .ToList();

                dropdownValuesResponse.IsActive = allDropDownValues
                    .Where(x => x.Constant == "IsActive")
                    .ToList();
                dropdownValuesResponse.Status = allDropDownValues
                    .Where(x => x.Constant == "Status")
                    .ToList();
                dropdownValuesResponse.Company = allDropDownValues
                    .Where(x => x.Constant == "Company")
                    .ToList();

                // Assign the populated dropdown values to the model
                modelToReturn.DropdownValuesResponse = dropdownValuesResponse;
            }
            else
            {
                // Handle error if dropdown values fetching fails
                ModelState.AddModelError("", "Failed to load dropdown values.");
            }

            // Return the view with the populated model (job details and dropdown values)
            return View(modelToReturn);
        }



        [ValidateInput(false)]
        public async Task<ActionResult> CreateJob(Jobs modal)
        {
            modal.CoverImage = modal.CoverImage ?? "";
            modal.JobTitle = modal.JobTitle ?? "";
            modal.EmployeeId = Session["EmployeeEmail"].ToString();
            modal.JobCategories = modal.JobCategories ?? "";
            modal.JobType = modal.JobType ?? "";
            modal.Description = modal.Description ?? "";
            modal.CareerLevel = modal.CareerLevel ?? "";
            modal.Experience = modal.Experience ?? "";
            modal.Qualification = modal.Qualification ?? "";
            modal.PrefrenceGender = modal.PrefrenceGender ?? "";
            modal.SalaryPayBy = modal.SalaryPayBy ?? "";
            modal.Currency = modal.Currency ?? "";
            modal.MinSalary = modal.MinSalary ?? "";
            modal.MaxSalary = modal.MaxSalary ?? "";
            modal.SalaryPaidPer = modal.SalaryPaidPer ?? "";
            modal.CompanyName = modal.CompanyName ?? "";
            modal.Location = modal.Location ?? "";
            modal.GalleryImage = modal.GalleryImage ?? "";
            modal.IntroductionVideo = modal.IntroductionVideo ?? "";
            modal.ApplyLastDate = modal.ApplyLastDate == default(DateTime) ? DateTime.UtcNow : modal.ApplyLastDate;
            modal.ApplyStartDate = modal.ApplyStartDate == default(DateTime) ? DateTime.UtcNow : modal.ApplyStartDate;
            modal.CreateDate = modal.CreateDate == default(DateTime) ? DateTime.UtcNow : modal.CreateDate;
            modal.UpdateDate = modal.UpdateDate == default(DateTime) ? DateTime.UtcNow : modal.UpdateDate;

            // Save the CoverImage image
            if (modal.CoverImagePath != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(modal.CoverImagePath.FileName);
                string extension = Path.GetExtension(modal.CoverImagePath.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                modal.CoverImage = fileName;
                fileName = Path.Combine(Server.MapPath("~/Areas/Employee/Images/JobImages/"), fileName);
                modal.CoverImagePath.SaveAs(fileName);
            }
            // Save the Galleryimage
            if (modal.GalleryImagePath != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(modal.GalleryImagePath.FileName);
                string extension = Path.GetExtension(modal.GalleryImagePath.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                modal.GalleryImage = fileName;
                fileName = Path.Combine(Server.MapPath("~/Areas/Employee/Images/JobImages/"), fileName);
                modal.GalleryImagePath.SaveAs(fileName);
            }

            // Save the Intro videos 
            if (modal.IntroductionVideoPath != null && modal.IntroductionVideoPath.ContentLength > 0)
            {
                // Check the file extension to make sure it's a video file
                var allowedExtensions = new[] { ".mp4", ".avi", ".mkv", ".webm" };
                var fileExtension = Path.GetExtension(modal.IntroductionVideoPath.FileName).ToLower();

                if (allowedExtensions.Contains(fileExtension))
                {
                    // Define the path where the video will be saved
                    string fileName = Path.GetFileNameWithoutExtension(modal.IntroductionVideoPath.FileName);
                    string extension = Path.GetExtension(modal.IntroductionVideoPath.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    var path = Path.Combine(Server.MapPath("~/Areas/Employee/Images/JobImages/"), fileName);

                    // Save the video file to the server
                    modal.IntroductionVideoPath.SaveAs(path);

                    // Optionally, save the video path to the database or another location
                    modal.IntroductionVideo = fileName;
                }

            }
            JobModelAsApi jobFieldAsApi = new JobModelAsApi();
            jobFieldAsApi.Id = modal.Id;
            jobFieldAsApi.JobTitle = modal.JobTitle;
            jobFieldAsApi.EmployeeId = modal.EmployeeId;
            jobFieldAsApi.JobCategories = modal.JobType;
            jobFieldAsApi.JobType = modal.JobType;
            jobFieldAsApi.Description = modal.Description;
            jobFieldAsApi.CareerLevel = modal.CareerLevel;
            jobFieldAsApi.Experience = modal.Experience;
            jobFieldAsApi.Qualification = modal.Qualification;
            jobFieldAsApi.PrefrenceGender = modal.PrefrenceGender;
            jobFieldAsApi.SalaryPayBy = modal.SalaryPayBy;
            jobFieldAsApi.Currency = modal.Currency;
            jobFieldAsApi.MinSalary = modal.MinSalary;
            jobFieldAsApi.MaxSalary = modal.MaxSalary;
            jobFieldAsApi.SalaryPaidPer = modal.SalaryPaidPer;
            jobFieldAsApi.CompanyName = modal.CompanyName;
            jobFieldAsApi.Location = modal.Location;
            jobFieldAsApi.CoverImage = modal.CoverImage;
            jobFieldAsApi.GalleryImage = modal.GalleryImage;
            jobFieldAsApi.IntroductionVideo = modal.IntroductionVideo;
            jobFieldAsApi.ApplyLastDate = modal.ApplyLastDate;
            jobFieldAsApi.ApplyStartDate = modal.ApplyStartDate;
            jobFieldAsApi.CreateDate = modal.CreateDate;
            jobFieldAsApi.UpdateDate = modal.UpdateDate;
            jobFieldAsApi.IsActive = modal.IsActive;
            jobFieldAsApi.Status = modal.Status;

            if (modal.Id == default(int))
            {

                if (modal.IsActive != 0)
                {
                    if (ModelState.IsValid)
                    {
                        var res = await ApiClientFactory.Instance.CreateJob(jobFieldAsApi);
                        Session["EmployeeUserName"] = modal.EmployeeId;
                        TempData["Message"] = "Job has been added successfully";
                        return RedirectToAction("DashboardJobs", "DashboardJobs", new { area = "Employee" });
                    }
                }
                else
                {
                    var res = await ApiClientFactory.Instance.CreateJob(jobFieldAsApi);
                    TempData["Message"] = "Save as draft , Update and set job as active job to visible in the list";
                    return RedirectToAction("DashboardJobs", "DashboardJobs", new { area = "Employee" });
                }
            }
            else if (modal.Id != 0)
            {
                modal.CreateDate = modal.CreateDate == default(DateTime) ? DateTime.UtcNow : modal.CreateDate;
                modal.UpdateDate = modal.UpdateDate == default(DateTime) ? DateTime.UtcNow : modal.UpdateDate;
                var res = await ApiClientFactory.Instance.UpdateJob(jobFieldAsApi);
                TempData["Message"] = "Job has been updated successfully";
                return RedirectToAction("DashboardJobs", "DashboardJobs", new { area = "Employee" });
            }
            return RedirectToAction("Home", "Index", new { area = "Employee" });
        }


        [HttpPost]
        public async Task<ActionResult> DeleteJobs(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var res = await ApiClientFactory.Instance.DeleteJob(id);
                TempData["Message"] = "Job has been deleted successfully";
                return RedirectToAction("DashboardJobs", "DashboardJobs", new { area = "Employee" });
            }
            else
            {
                TempData["Message"] = "Job Doesn't Exist";
                return RedirectToAction("DashboardJobs", "DashboardJobs", new { area = "Employee" });
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> EditJobs(string id)
        {
            // Fetch the job details by ID
            var res = await ApiClientFactory.Instance.GetJobByItsId(id);

            if (res == null || res.Data == null)
            {
                // Handle the case where the job with the provided ID is not found
                return HttpNotFound();
            }

            // Initialize a new Jobs model with the data fetched from the API
            var model = new Jobs
            {
                Id = res.Data.Id,
                JobTitle = res.Data.JobTitle,
                EmployeeId = res.Data.EmployeeId,
                JobCategories = res.Data.JobCategories,
                JobType = res.Data.JobType,
                Description = res.Data.Description,
                CareerLevel = res.Data.CareerLevel,
                Experience = res.Data.Experience,
                Qualification = res.Data.Qualification,
                PrefrenceGender = res.Data.PrefrenceGender,
                SalaryPayBy = res.Data.SalaryPayBy,
                MinSalary = res.Data.MinSalary,
                MaxSalary = res.Data.MaxSalary,
                SalaryPaidPer = res.Data.SalaryPaidPer,
                CompanyName = res.Data.CompanyName,
                Location = res.Data.Location,
                CoverImage = res.Data.CoverImage,
                GalleryImage = res.Data.GalleryImage,
                IsActive = res.Data.IsActive,
                ApplyStartDate = res.Data.ApplyStartDate,
                ApplyLastDate = res.Data.ApplyLastDate,
                UpdateDate = res.Data.UpdateDate,
                CreateDate = DateTime.UtcNow,
                IntroductionVideo = res.Data.IntroductionVideo,
            };
            // Combine the relative path with the stored image name to prepopulate the image in the view
            if (!string.IsNullOrEmpty(res.Data.GalleryImage))
            {
                // Assuming that GalleryImage only stores the filename, prepend the path to it
                var imagePath = Url.Content($"~/Areas/Employee/Images/JobImages/{res.Data.GalleryImage}");
                model.GalleryImage = imagePath;  // Use the full URL path for prepopulating in the form
            }

            // Fetch dropdown values for the form
            var response = await ApiClientFactory.Instance.GetAllDropDownValues();
            var dropdownValuesResponse = new DropdownValuesResponse();

            // Check if the response indicates success
            if (response.IsSuccess && response.Data != null)
            {
                // Populate and filter each category from the dropdown values
                var allDropDownValues = response.Data; // Assuming response.Data is of type List<DropDownValues>

                dropdownValuesResponse.JobCategories = allDropDownValues
                    .Where(x => x.Constant == "Category")
                    .ToList();

                dropdownValuesResponse.JobType = allDropDownValues
                    .Where(x => x.Constant == "JobType")
                    .ToList();

                dropdownValuesResponse.CareerLevel = allDropDownValues
                    .Where(x => x.Constant == "CareerLevel")
                    .ToList();

                dropdownValuesResponse.Experience = allDropDownValues
                    .Where(x => x.Constant == "Experience")
                    .ToList();

                dropdownValuesResponse.Qualification = allDropDownValues
                    .Where(x => x.Constant == "Qualification")
                    .ToList();

                dropdownValuesResponse.PrefrenceGender = allDropDownValues
                    .Where(x => x.Constant == "Gender")
                    .ToList();

                dropdownValuesResponse.SalaryPayBy = allDropDownValues
                    .Where(x => x.Constant == "SalaryPayBy")
                    .ToList();

                dropdownValuesResponse.Currency = allDropDownValues
                    .Where(x => x.Constant == "RangeCurrency")
                    .ToList();

                dropdownValuesResponse.SalaryPaidPer = allDropDownValues
                    .Where(x => x.Constant == "SalaryPaidPer")
                    .ToList();

                dropdownValuesResponse.Locations = allDropDownValues
                    .Where(x => x.Constant == "Location")
                    .ToList();

                dropdownValuesResponse.IsActive = allDropDownValues
                    .Where(x => x.Constant == "IsActive")
                    .ToList();

                // Assign the populated dropdown values to the model
                model.DropdownValuesResponse = dropdownValuesResponse;
            }
            else
            {
                // Handle error or no data returned in dropdown values
                ModelState.AddModelError("", "Failed to load dropdown values.");
            }

            // Return the view with the populated model
            return View(model);
        }
        [HttpGet]
        public DropdownValuesResponse DropdownValues()
        {
            var response = ApiClientFactory.Instance.GetAllDropDownValues().Result;
            var dropdownValuesResponse = new DropdownValuesResponse();

            if (response.IsSuccess)
            {
                var allDropDownValues = response.Data;

                dropdownValuesResponse.JobCategories = allDropDownValues
                    .Where(x => x.Constant == "Category")
                    .ToList();

                dropdownValuesResponse.JobType = allDropDownValues
                    .Where(x => x.Constant == "JobType")
                    .ToList();

                dropdownValuesResponse.CareerLevel = allDropDownValues
                    .Where(x => x.Constant == "CareerLevel")
                    .ToList();

                dropdownValuesResponse.Experience = allDropDownValues
                    .Where(x => x.Constant == "Experience")
                    .ToList();

                dropdownValuesResponse.Qualification = allDropDownValues
                    .Where(x => x.Constant == "Qualification")
                    .ToList();

                dropdownValuesResponse.PrefrenceGender = allDropDownValues
                    .Where(x => x.Constant == "Gender")
                    .ToList();

                dropdownValuesResponse.SalaryPayBy = allDropDownValues
                    .Where(x => x.Constant == "SalaryPayBy")
                    .ToList();

                dropdownValuesResponse.Currency = allDropDownValues
                    .Where(x => x.Constant == "RangeCurrency")
                    .ToList();

                dropdownValuesResponse.SalaryPaidPer = allDropDownValues
                    .Where(x => x.Constant == "SalaryPaidPer")
                    .ToList();

                dropdownValuesResponse.Locations = allDropDownValues
                    .Where(x => x.Constant == "Location")
                    .ToList();

                dropdownValuesResponse.IsActive = allDropDownValues
                    .Where(x => x.Constant == "IsActive")
                    .ToList();

                return dropdownValuesResponse;
            }

            return dropdownValuesResponse;
        }




    }
}
