using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DivyangPortalWeb.Areas.Candidate.Models
{
    public class CandidateEduationDetails
    {
        public int CandidateId { get; set; }
        public string HighestEducationAttained { get; set; }
        public string EducationQualification { get; set; }
        public string Specializations { get; set; }
        public string BoardUniversities { get; set; }
        public string Institute { get; set; }
    }
}