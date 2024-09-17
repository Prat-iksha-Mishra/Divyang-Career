using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DivyangPortalWeb.Areas.Employee.Models
{
    public class DropdownValuesResponse
    {
        public List<DropDownValues> JobCategories { get; set; }
        public List<DropDownValues> JobType { get; set; }
        public List<DropDownValues> CareerLevel { get; set; }
        public List<DropDownValues> Experience { get; set; }
        public List<DropDownValues> Qualification { get; set; }
        public List<DropDownValues> PrefrenceGender { get; set; }
        public List<DropDownValues> SalaryPayBy { get; set; }
        public List<DropDownValues> Currency { get; set; }
        public List<DropDownValues> SalaryPaidPer { get; set; }
        public List<DropDownValues> Locations { get; set; }
        public List<DropDownValues> IsActive { get; set; }
        public List<DropDownValues> Status { get; set; }
        public List<DropDownValues> Company { get; set; }

    }

    public class DropdownCategory { public int Id { get; set; } public string Name { get; set; } public string Constant { get; set; } }
    public class DropdownJobType { public int Id { get; set; } public string Name { get; set; } public string Constant { get; set; } }
    public class DropdownCareerLevel { public int Id { get; set; } public string Name { get; set; } public string Constant { get; set; } }
    public class DropdownExperience { public int Id { get; set; } public string Name { get; set; } public string Constant { get; set; } }
    public class DropdownQualification { public int Id { get; set; } public string Name { get; set; } public string Constant { get; set; } }
    public class DropdownGender { public int Id { get; set; } public string Name { get; set; } public string Constant { get; set; } }
    public class DropdownSalaryPayBy { public int Id { get; set; } public string Name { get; set; } public string Constant { get; set; } }
    public class DropdownRangeCurrency { public int Id { get; set; } public string Name { get; set; } public string Constant { get; set; } }
    public class DropdownSalaryPaidPer { public int Id { get; set; } public string Name { get; set; } public string Constant { get; set; } }
    public class DropdownLocation { public int Id { get; set; } public string Name { get; set; } public string Constant { get; set; } }
    public class DropdownIsActive { public int Id { get; set; } public string Name { get; set; } public string Constant { get; set; } }
    public class DropdownIsStatus { public int Id { get; set; } public string Name { get; set; } public string Constant { get; set; } }
    public class DropdownCompany { public int Id { get; set; } public string Name { get; set; } public string Constant { get; set; } }

}