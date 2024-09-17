using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Areas.Candidate.Models
{
    public class CandidateDetails
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string ProfileImage { get; set; }
        public string GuardianName { get; set; }
        public string DBO { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string Gender { get; set; }
        public string PrimaryLanguage { get; set; }
        public string EmploymentStatus { get; set; }
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
        public string CVName { get; set; }
        public string HighestEducationAttained { get; set; } = string.Empty;
        public string EducationQualification { get; set; } = string.Empty;
        public string Specializations { get; set; } = string.Empty;
        public string BoardUniversities { get; set; } = string.Empty;
        public string Institute { get; set; } = string.Empty;
        public string Month { get; set; } = string.Empty;
        public string Years { get; set; } = string.Empty;
        public string GradePercentagePercentileType { get; set; } = string.Empty;
        public string GradePercentagePercentileValue { get; set; } = string.Empty;
        public string CourseNature { get; set; } = string.Empty;
        public string MediumOfEducation { get; set; } = string.Empty;
        public string CertificateName { get; set; } = string.Empty;
        public string CertificateYear { get; set; } = string.Empty;
        public string IssuedBy { get; set; } = string.Empty;
        public string AvailableToJoinInDays { get; set; } = string.Empty;
        public string CurrentEmployerSector { get; set; } = string.Empty;
        public string ExperienceYears { get; set; } = string.Empty;
        public string ExperienceMonths { get; set; } = string.Empty;
        public string SkillName { get; set; } = string.Empty;
        public string CurrentJobtitle { get; set; } = string.Empty;
        public string CurrentCompanyname { get; set; } = string.Empty;
        public string Pastjobtitle { get; set; } = string.Empty;
        public string PastFrom { get; set; } = string.Empty;
        public string PastTo { get; set; } = string.Empty;
        public string Pastcompanyname { get; set; } = string.Empty;
        public string DiscriptionNotes { get; set; } = string.Empty;
        public string DisabilityType { get; set; } = string.Empty;
        public string UDIDOption { get; set; } = string.Empty;
        public string UDIDNumber { get; set; } = string.Empty;
        public string DisabilityPercentage { get; set; } = string.Empty;
        public string UDIDCardName { get; set; } = string.Empty;
    }
}