﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DivyangPortalWeb.Areas.Candidate.Models
{
    public class CandidateDisablityInfoDetails
    {
        public int CandidateId { get; set; }
        public string DisabilityType { get; set; }
        public string UDIDOption { get; set; }
        public string UDIDNumber { get; set; }
        public string DisabilityPercentage { get; set; }
        public string UDIDCardName { get; set; }
    }
}