using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DivyangPortalWeb.Models
{
    public class ContributeViewModel
    {
        public long UserId { get; set; }
        public string TechnologyId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Contents { get; set; }
    }
}