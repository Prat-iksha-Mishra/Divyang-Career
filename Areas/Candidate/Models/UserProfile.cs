using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Areas.Candidate.Models
{
    public class UserProfile
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Enter email")]
        [DataType(DataType.EmailAddress)]
        [System.Web.Mvc.Remote("CheckEmail", "Profile", AdditionalFields = "Email", ErrorMessage = "Email already exists!")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public HttpPostedFileBase ProfileImage { get; set; }
        public string GuardianName { get; set; }
        
        public string DBO { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string Gender { get; set; }
        public string PrimaryLanguage { get; set; }
        public string EmploymentStatus { get; set; }
        public string ProfileImageName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string Cities { get; set; }
        public string AddressType { get; set; }
        public string AddressSubType { get; set; }
        public string TerritoryTypes { get; set; }
        public string PinCode { get; set; }
        public string MaritalStatus { get; set; }
        public string Religions { get; set; }
        public string Castes { get; set; }
        public string UIDType { get; set; }
        public string UIDNumber { get; set; }
        public HttpPostedFileBase CV { get; set; }
        public string CVName { get; set; }
        //Education
        public string HighestEducationAttained { get; set; }
        public string EducationQualification { get; set; }
        public string Specializations { get; set; }
        public string BoardUniversities { get; set; }
        public string Institute { get; set; }
        public string Month { get; set; }
        public string Years { get; set; }
        public string GradePercentagePercentileType { get; set; }
        public string GradePercentagePercentileValue { get; set; }
        public string CourseNature { get; set; }
        public string MediumOfEducation { get; set; }
        public string CertificateName { get; set; }
        public string CertificateYear { get; set; }
        public string IssuedBy { get; set; }
        //Experience
        public string AvailableToJoinInDays { get; set; }
        public string CurrentEmployerSector { get; set; }
        public string ExperienceYears { get; set; }
        public string ExperienceMonths { get; set; }
        public string SkillName { get; set; }
        public string CurrentJobtitle { get; set; }
        public string CurrentCompanyname { get; set; }
        public string Pastjobtitle { get; set; }
        public string PastFrom { get; set; }
        public string PastTo { get; set; }
        public string Pastcompanyname { get; set; }
        public string DiscriptionNotes { get; set; }
        //DisablityInfo
        public string DisabilityType { get; set; }
        public string UDIDOption { get; set; }
        public string UDIDNumber { get; set; }
        public string DisabilityPercentage { get; set; }
        public string UDIDCardName { get; set; }
        public HttpPostedFileBase UDIDCard { get; set; }
        public IEnumerable<SelectListItem> PrimaryLanguageOptions { get; set; }
        public IEnumerable<SelectListItem> GenderOptions { get; set; }
        public IEnumerable<SelectListItem> EmploymentStatusOptions { get; set; }
        public IEnumerable<SelectListItem> StateDropDown { get; set; }
        public IEnumerable<SelectListItem> DistrictDropDown { get; set; }
        public IEnumerable<SelectListItem> SubDistrictDropDown { get; set; }
        public IEnumerable<SelectListItem> CitiesDropDown { get; set; }
        public IEnumerable<SelectListItem> AddressTypeDropDown { get; set; }
        public IEnumerable<SelectListItem> AddressSubTypeDropDown { get; set; }
        public IEnumerable<SelectListItem> TerritoryTypesDropDown { get; set; }
        public IEnumerable<SelectListItem> MaritalStatusDropDown { get; set; }
        public IEnumerable<SelectListItem> ReligionsDropDown { get; set; }
        public IEnumerable<SelectListItem> CastesDropDown { get; set; }
        public IEnumerable<SelectListItem> UIDTypeDropDown { get; set; }
        public IEnumerable<SelectListItem> HighestEducationAttainedDropDown { get; set; }
        public IEnumerable<SelectListItem> EducationQualificationDropDown { get; set; }
        public IEnumerable<SelectListItem> SpecializationsDropDown { get; set; }
        public IEnumerable<SelectListItem> BoardUniversitiesDropDown { get; set; }
        public IEnumerable<SelectListItem> MonthDropDown { get; set; }
        public IEnumerable<SelectListItem> GradeTypesDropDown { get; set; }
        public IEnumerable<SelectListItem> CourseNatureDropDown { get; set; }
        public IEnumerable<SelectListItem> MediumOfEducationDropDown { get; set; }
        public IEnumerable<SelectListItem> CurrentEmployerSectorDropDown { get; set; }
        public IEnumerable<SelectListItem> DisabilityTypeDropDown { get; set; }
        public IEnumerable<SelectListItem> UDIDOptionDropDown { get; set; }
    }
}