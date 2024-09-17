using DivyangPortalWeb.Areas.Candidate.Models;
using DivyangPortalWeb.Model.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Areas.Candidate.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Candidate/Profile
        public async Task<ActionResult> Profile()
        {
            UserProfile User = new UserProfile();
            string Email = Session["CandidateEmail"].ToString();
            var res = await ApiClientFactory.Instance.GetCandidateDetails(Email);
            User.CandidateId = res.Data.CandidateId;
            User.FirstName = res.Data.FirstName;
            User.LastName = res.Data.LastName;
            User.UserName = res.Data.UserName;
            User.Email = res.Data.Email;
            User.PhoneNumber = res.Data.PhoneNumber;
            User.ProfileImageName = res.Data.ProfileImage ?? string.Empty;
            User.GuardianName = res.Data.GuardianName ?? string.Empty;
            User.DBO = res.Data.DBO;
            User.Description = res.Data.Description ?? string.Empty;
            User.Gender = res.Data.Gender ?? string.Empty;
            User.PrimaryLanguage = res.Data.PrimaryLanguage;
            User.EmploymentStatus = res.Data.EmploymentStatus ?? string.Empty;
            User.Address = res.Data.Address ?? string.Empty;
            User.State = res.Data.State;
            User.District = res.Data.District;
            User.SubDistrict = res.Data.SubDistrict;
            User.Cities = res.Data.Cities;
            User.AddressType = res.Data.AddressType;
            User.AddressSubType = res.Data.AddressSubType;
            User.TerritoryTypes = res.Data.TerritoryTypes;
            User.MaritalStatus = res.Data.MaritalStatus;
            User.Religions = res.Data.Religions;
            User.Castes = res.Data.Castes;
            User.UIDType = res.Data.UIDType;
            User.UIDNumber = res.Data.UIDNumber;
            User.PinCode = res.Data.PinCode;
            User.CVName = res.Data.CVName;
            User.HighestEducationAttained = res.Data.HighestEducationAttained;
            User.EducationQualification = res.Data.EducationQualification;
            User.Specializations = res.Data.Specializations;
            User.BoardUniversities = res.Data.BoardUniversities;
            User.Institute = res.Data.Institute;
            User.Month = res.Data.Month;
            User.Years = res.Data.Years;
            User.GradePercentagePercentileType = res.Data.GradePercentagePercentileType;
            User.GradePercentagePercentileValue = res.Data.GradePercentagePercentileValue;
            User.CourseNature = res.Data.CourseNature;
            User.MediumOfEducation = res.Data.MediumOfEducation;
            User.CertificateName = res.Data.CertificateName;
            User.CertificateYear = res.Data.CertificateYear;
            User.IssuedBy = res.Data.IssuedBy;
            User.AvailableToJoinInDays = res.Data.AvailableToJoinInDays;
            User.CurrentEmployerSector = res.Data.CurrentEmployerSector;
            User.ExperienceYears = res.Data.ExperienceYears;
            User.ExperienceMonths = res.Data.ExperienceMonths;
            User.SkillName = res.Data.SkillName;
            User.CurrentJobtitle = res.Data.CurrentJobtitle;
            User.CurrentCompanyname = res.Data.CurrentCompanyname;
            User.Pastjobtitle = res.Data.Pastjobtitle;
            User.PastFrom = res.Data.PastFrom;
            User.PastTo = res.Data.PastTo;
            User.Pastcompanyname = res.Data.Pastcompanyname;
            User.DiscriptionNotes = res.Data.DiscriptionNotes;
            User.DisabilityType = res.Data.DisabilityType;
            User.UDIDOption = res.Data.UDIDOption;
            User.DisabilityPercentage = res.Data.DisabilityPercentage;
            User.UDIDCardName = res.Data.UDIDCardName;
            User.UDIDNumber = res.Data.UDIDNumber;
            await PopulateDropdowns(User);
            return View(User);
        }
        private async Task PopulateDropdowns(UserProfile model)
        {
            model.PrimaryLanguageOptions = await GetPrimaryLanguageOptions(); // For editing, the selected category is passed
            model.GenderOptions = await GetGenderOptions();
            model.EmploymentStatusOptions = await GetEmploymentStatusOptions();
            model.StateDropDown = await GetStateDropDown();
            if (!string.IsNullOrEmpty(model.District))
            {
                model.DistrictDropDown = await GetDistricDropdownOptions(model.State, model.District);
            }
            else
            {
                model.DistrictDropDown = new List<SelectListItem>
                {
                    new SelectListItem { Value = "", Text = "Select district", Selected = true, Disabled = true }  // Placeholder option
                };
            }
           
            if (!string.IsNullOrEmpty(model.SubDistrict))
            {
                model.SubDistrictDropDown = await GetSubDistricDropdownOptions(model.State, model.District,model.SubDistrict);
            }
            else
            {
                model.SubDistrictDropDown = new List<SelectListItem>
                {
                    new SelectListItem { Value = "", Text = "Select subdistrict", Selected = true, Disabled = true }  // Placeholder option
                };
            }
            if (!string.IsNullOrEmpty(model.Cities))
            {
                model.CitiesDropDown = await GetCitiesDropdownOptions(model.State, model.District,model.SubDistrict,model.Cities);
            }
            else
            {
                model.CitiesDropDown = new List<SelectListItem>
                {
                    new SelectListItem { Value = "", Text = "Select cityvillage", Selected = true, Disabled = true }  // Placeholder option
                };
            }
            model.AddressTypeDropDown = await GetAddressTypeDropDown();
            model.AddressSubTypeDropDown = await GetAddressSubTypeDropDown(model.AddressSubType);
            model.TerritoryTypesDropDown = await GetTerritoryTypesDropDown();
            model.MaritalStatusDropDown = await GetMaritalStatusOptions();
            model.ReligionsDropDown = await GetReligionsOptions();
            model.CastesDropDown = await GetCastesDropDown();
            model.UIDTypeDropDown = await GetUIDTypeOptions();
            model.HighestEducationAttainedDropDown = await GetHighestEducationAttainedOptions();
            if (!string.IsNullOrEmpty(model.HighestEducationAttained))
            {
                model.EducationQualificationDropDown = await GetEducationQualificationFirst(model.HighestEducationAttained);
            }
            else
            {
                model.EducationQualificationDropDown = new List<SelectListItem>
                {
                    new SelectListItem { Value = "", Text = "Select education", Selected = true, Disabled = true }  // Placeholder option
                };
            }
            if (!string.IsNullOrEmpty(model.EducationQualification))
            {
                model.SpecializationsDropDown = await GetSpecializationsFirst(model.EducationQualification);
            }
            else
            {
                model.SpecializationsDropDown = new List<SelectListItem>
                {
                    new SelectListItem { Value = "", Text = "Select specialization", Selected = true, Disabled = true }  // Placeholder option
                };
            }
            model.BoardUniversitiesDropDown = await GetBoardUniversitiesOptions();
            model.MonthDropDown = await GetMounth();
            model.GradeTypesDropDown = await GetGradeTypesDropDown();
            model.CourseNatureDropDown = await GetCourseNatureDropDown();
            model.MediumOfEducationDropDown = await GetPrimaryLanguageOptions();
            model.CurrentEmployerSectorDropDown = await GetCurrentEmployerSector();
            model.DisabilityTypeDropDown = await GetDisabilityType();
            model.UDIDOptionDropDown = await GetUDIDOption();
        }
        public async Task<IEnumerable<SelectListItem>> GetUDIDOption()
        {
            var selectList = new List<SelectListItem>();
            selectList.Insert(0, new SelectListItem
            {
                Value = "",
                Text = "Select an option",
                Selected = true,
                Disabled = true
            });
            selectList.Add(new SelectListItem
            {
                Value = "1",
                Text = "Yes"
            });
            selectList.Add(new SelectListItem
            {
                Value = "2",
                Text = "No"
            });
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetPrimaryLanguageOptions(int selectedLanguageId = 0)
        {
            var categories = await ApiClientFactory.Instance.GetPrimaryLanguageOptions();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString() // Only the matching category should be selected
            }).ToList();
            // Add a placeholder only if no category is selected (for adding new company)
            if (selectedLanguageId == 0)
            {
                selectList.Insert(0, new SelectListItem
                {
                    Value = "",
                    Text = "Select a language",
                    Selected = true,
                    Disabled = true
                });
            }
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetGenderOptions()
        {
            var categories = await ApiClientFactory.Instance.GetGenderOptions();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Code.ToString() // Only the matching category should be selected
            });
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetEmploymentStatusOptions()
        {
            var categories = await ApiClientFactory.Instance.GetEmploymentStatusOptions();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString() // Only the matching category should be selected
            });
            return selectList;
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
        public async Task<IEnumerable<SelectListItem>> GetCitiesDropdownOptions(string StateId = "", string District = "", string SubDistrict = "", string Cities="")
        {
            var Citie = await ApiClientFactory.Instance.BindCities(StateId, District, SubDistrict);

            var selectList = Citie.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString(),
                Selected = (c.Id.ToString() == Cities) // Only the matching category should be selected
            }).ToList();
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetSubDistricDropdownOptions(string StateId = "", string District = "", string SubDistrict="")
        {
            var Distric = await ApiClientFactory.Instance.BindSubDistict(StateId, District);

            var selectList = Distric.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString(),
                Selected = (c.Id.ToString() == SubDistrict) // Only the matching category should be selected
            }).ToList();
            return selectList;
        }
        public async Task<JsonResult> GetDistricByState(string StateId = "")
        {
            var Distric = await ApiClientFactory.Instance.BindDistict(StateId);
            var selectList = Distric.Data.Select(c => new SelectListItem
            {
                Text = c.DistrictName,
                Value = c.Id.ToString()
            });

            return Json(selectList, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> GetSubDistricByStateDistrict(string DistrictId="",string StateId = "")
        {
            var Distric = await ApiClientFactory.Instance.BindSubDistict(StateId,DistrictId);
            var selectList = Distric.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            return Json(selectList, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> GetCitiesBySubDistrict(string DistrictId = "", string StateId = "", string SubDistrictId="")
        {
            var Distric = await ApiClientFactory.Instance.BindCities(StateId, DistrictId, SubDistrictId);
            var selectList = Distric.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            return Json(selectList, JsonRequestBehavior.AllowGet);
        }
        public async Task<IEnumerable<SelectListItem>> GetAddressTypeDropDown()
        {
            var categories = await ApiClientFactory.Instance.GetAddressType();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Code.ToString() // Only the matching category should be selected
            });
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetAddressSubTypeDropDown(string AddressSubType="")
        {
            var categories = await ApiClientFactory.Instance.GetAddressSubType();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Code.ToString(), // Only the matching category should be selected
                Selected = (c.Code.ToString() == AddressSubType)
            });
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetTerritoryTypesDropDown()
        {
            var categories = await ApiClientFactory.Instance.GetTerritoryTypes();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Code.ToString() // Only the matching category should be selected
            });
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetMaritalStatusOptions()
        {
            var categories = await ApiClientFactory.Instance.GetMaritalStatusOptions();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString() // Only the matching category should be selected
            });
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetReligionsOptions()
        {
            var categories = await ApiClientFactory.Instance.GetReligionsOptions();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString() // Only the matching category should be selected
            });
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetCastesDropDown()
        {
            var categories = await ApiClientFactory.Instance.GetCastes();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Code.ToString() // Only the matching category should be selected
            });
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetUIDTypeOptions()
        {
            var categories = await ApiClientFactory.Instance.GetUIDTypeOptions();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString() // Only the matching category should be selected
            });
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetHighestEducationAttainedOptions()
        {
            var categories = await ApiClientFactory.Instance.GetHighestEducationAttained();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString() // Only the matching category should be selected
            });
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetEducationQualificationFirst(string HighestEducationAttained = "")
        {
            var categories = await ApiClientFactory.Instance.GetEduaction(HighestEducationAttained);
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString() // Only the matching category should be selected
            });
            return selectList;
        }
        public async Task<JsonResult> GetEducationQualification(string HighestEducationAttained = "")
        {
            var Distric = await ApiClientFactory.Instance.GetEduaction(HighestEducationAttained);
            var selectList = Distric.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            return Json(selectList, JsonRequestBehavior.AllowGet);
        }
        public async Task<IEnumerable<SelectListItem>> GetSpecializationsFirst(string EducationId = "")
        {
            var categories = await ApiClientFactory.Instance.GetSpecializations(EducationId);
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString() // Only the matching category should be selected
            });
            return selectList;
        }
        public async Task<JsonResult> GetSpecializations(string EducationId = "")
        {
            var Distric = await ApiClientFactory.Instance.GetSpecializations(EducationId);
            var selectList = Distric.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            return Json(selectList, JsonRequestBehavior.AllowGet);
        }
        public async Task<IEnumerable<SelectListItem>> GetBoardUniversitiesOptions()
        {
            var categories = await ApiClientFactory.Instance.GetBoardUniversitiesDropDownOptions();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Name.ToString() // Only the matching category should be selected
            });
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetMounth()
        {
            var categories = await ApiClientFactory.Instance.GetMounthOptions();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString() // Only the matching category should be selected
            });
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetGradeTypesDropDown()
        {
            var categories = await ApiClientFactory.Instance.GetGradeTypesOptions();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString() // Only the matching category should be selected
            });
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetCourseNatureDropDown()
        {
            var categories = await ApiClientFactory.Instance.GetCourseNatureDropDown();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Code.ToString() // Only the matching category should be selected
            });
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetCurrentEmployerSector()
        {
            var categories = await ApiClientFactory.Instance.GetCurrentEmployerSectorOptions();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString() // Only the matching category should be selected
            });
            return selectList;
        }
        public async Task<IEnumerable<SelectListItem>> GetDisabilityType()
        {
            var categories = await ApiClientFactory.Instance.GetDisabilityType();
            var selectList = categories.Data.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString() // Only the matching category should be selected
            });
            return selectList;
        }
        public async Task<ActionResult> UpdateProfile(UserProfile User)
        {
            if (User.ProfileImage != null)
            {
                // Save the profile image
                string name = "";
                string fileName = Path.GetFileNameWithoutExtension(User.ProfileImage.FileName);
                string extension = Path.GetExtension(User.ProfileImage.FileName);
                fileName =  DateTime.Now.ToString("yymmssfff") + extension;
                name = fileName;
                fileName = Path.Combine(Server.MapPath("~/Areas/Candidate/Images/ProfileImage/"), fileName);
                User.ProfileImage.SaveAs(fileName);
                User.ProfileImageName = name;
            }
            if (User.CV != null)
            {
                // Save the profile image
                string name = "";
                string fileName = Path.GetFileNameWithoutExtension(User.CV.FileName);
                string extension = Path.GetExtension(User.CV.FileName);
                fileName = DateTime.Now.ToString("yymmssfff") + extension;
                name = fileName;
                fileName = Path.Combine(Server.MapPath("~/Areas/Candidate/Images/Resume/"), fileName);
                User.CV.SaveAs(fileName);
                User.CVName = name;
            }
            CandidateDetails Model = new CandidateDetails();
            Model.CandidateId = User.CandidateId;
            Model.FirstName = User.FirstName ?? string.Empty;
            Model.LastName = User.LastName ?? string.Empty;
            Model.UserName = User.UserName ?? string.Empty;
            Model.Email = User.Email ?? string.Empty;
            Model.PhoneNumber = User.PhoneNumber ?? string.Empty;
            Model.ProfileImage = User.ProfileImageName ?? string.Empty;
            Model.GuardianName = User.GuardianName ?? string.Empty;
            Model.DBO = User.DBO;
            Model.Description = User.Description ?? string.Empty;
            Model.Gender = User.Gender ?? string.Empty;
            Model.PrimaryLanguage = User.PrimaryLanguage ?? string.Empty;
            Model.EmploymentStatus = User.EmploymentStatus ?? string.Empty;
            Model.CountryCode = User.CountryCode ?? string.Empty;
            Model.Address = User.Address ?? string.Empty;
            Model.State = User.State ?? string.Empty;
            Model.District = User.District ?? string.Empty;
            Model.SubDistrict = User.SubDistrict ?? string.Empty;
            Model.Cities = User.Cities ?? string.Empty;
            Model.AddressType = User.AddressType ?? string.Empty;
            Model.AddressSubType = User.AddressSubType ?? string.Empty;
            Model.TerritoryTypes = User.TerritoryTypes ?? string.Empty;
            Model.MaritalStatus = User.MaritalStatus ?? string.Empty;
            Model.Religions = User.Religions ?? string.Empty;
            Model.Castes = User.Castes ?? string.Empty;
            Model.UIDType = User.UIDType ?? string.Empty;
            Model.UIDNumber = User.UIDNumber ?? string.Empty;
            Model.PinCode = User.PinCode ?? string.Empty;
            Model.CVName = User.CVName ?? string.Empty;
            var res = await ApiClientFactory.Instance.UpdateCandidateDetails(Model);
            if (res.ReturnMessage == "Error")
            {
                TempData["UpdateCandidatePopUp"] = "Error try again later";
                return Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                TempData["UpdateCandidatePopUp"] = "Update successfully";
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        public async Task<ActionResult> EducationUpdateProfile(UserProfile User)
        {
            CandidateEducationDetails Model = new CandidateEducationDetails();
            Model.CandidateId = User.CandidateId;
            Model.HighestEducationAttained = User.HighestEducationAttained ?? string.Empty;
            Model.EducationQualification = User.EducationQualification ?? string.Empty;
            Model.Specializations = User.Specializations ?? string.Empty;
            Model.BoardUniversities = User.BoardUniversities ?? string.Empty;
            Model.Institute = User.Institute ?? string.Empty;
            Model.Month = User.Month ?? string.Empty;
            Model.Years = User.Years ?? string.Empty;
            Model.GradePercentagePercentileType = User.GradePercentagePercentileType ?? string.Empty;
            Model.GradePercentagePercentileValue = User.GradePercentagePercentileValue ?? string.Empty;
            Model.CourseNature = User.CourseNature ?? string.Empty;
            Model.MediumOfEducation = User.MediumOfEducation ?? string.Empty;
            Model.CertificateName = User.CertificateName ?? string.Empty;
            Model.CertificateYear = User.CertificateYear ?? string.Empty;
            Model.IssuedBy = User.IssuedBy ?? string.Empty;
            var res = await ApiClientFactory.Instance.EducationUpdateCandidateDetails(Model);
            if (res.ReturnMessage == "Error")
            {
                TempData["UpdateCandidatePopUp"] = "Error try again later";
                return Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                TempData["UpdateCandidatePopUp"] = "Update successfully";
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        public async Task<ActionResult> ExperienceUpdateProfile(UserProfile User)
        {
            CandidateExperienceDetails Model = new CandidateExperienceDetails();
            Model.CandidateId = User.CandidateId;
            Model.AvailableToJoinInDays = User.AvailableToJoinInDays ?? string.Empty;
            Model.CurrentEmployerSector = User.CurrentEmployerSector ?? string.Empty;
            Model.ExperienceYears = User.ExperienceYears ?? string.Empty;
            Model.ExperienceMonths = User.ExperienceMonths ?? string.Empty;
            Model.SkillName = User.SkillName ?? string.Empty;
            Model.CurrentJobtitle = User.CurrentJobtitle ?? string.Empty;
            Model.CurrentCompanyname = User.CurrentCompanyname ?? string.Empty;
            Model.Pastjobtitle = User.Pastjobtitle ?? string.Empty;
            Model.PastFrom = User.PastFrom ?? string.Empty;
            Model.PastTo = User.PastTo ?? string.Empty;
            Model.Pastcompanyname = User.Pastcompanyname ?? string.Empty;
            Model.DiscriptionNotes = User.DiscriptionNotes ?? string.Empty;
            var res = await ApiClientFactory.Instance.ExperinceUpdateCandidateDetails(Model);
            if (res.ReturnMessage == "Error")
            {
                TempData["UpdateCandidatePopUp"] = "Error try again later";
                return Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                TempData["UpdateCandidatePopUp"] = "Update successfully";
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        public async Task<ActionResult> DisabilityUpdateProfile(UserProfile User)
        {
            if (User.UDIDCard != null)
            {
                // Save the profile image
                string name = "";
                string fileName = Path.GetFileNameWithoutExtension(User.UDIDCard.FileName);
                string extension = Path.GetExtension(User.UDIDCard.FileName);
                fileName = DateTime.Now.ToString("yymmssfff") + extension;
                name = fileName;
                fileName = Path.Combine(Server.MapPath("~/Areas/Candidate/Images/UDIDCard/"), fileName);
                User.UDIDCard.SaveAs(fileName);
                User.UDIDCardName = name;
            }
            CandidateDisablityInfoDetails Model = new CandidateDisablityInfoDetails();
            Model.CandidateId = User.CandidateId;
            Model.DisabilityType = User.DisabilityType ?? string.Empty;
            Model.UDIDOption = User.UDIDOption ?? string.Empty;
            Model.UDIDNumber = User.UDIDNumber ?? string.Empty;
            Model.DisabilityPercentage = User.DisabilityPercentage ?? string.Empty;
            Model.UDIDCardName = User.UDIDCardName ?? string.Empty;
            var res = await ApiClientFactory.Instance.DisabilityUpdateCandidateDetails(Model);
            if (res.ReturnMessage == "Error")
            {
                TempData["UpdateCandidatePopUp"] = "Error try again later";
                return Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                TempData["UpdateCandidatePopUp"] = "Update successfully";
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        //Here Check Email Is Exists Or Not Start Here
        public async Task<JsonResult> CheckEmail(UserProfile model)
        {
            bool ifEmailExist = true;
            DivyangPortalWeb.Models.CheckEmail ch = new DivyangPortalWeb.Models.CheckEmail();
            ch.Email = model.Email.ToString();
            ch.CurrentEmail = Session["CandidateEmail"].ToString();
            var var = await ApiClientFactory.Instance.CheckEmailCandidateUpdate(ch);
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