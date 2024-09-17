﻿using DivyangPortalWeb.Common;
using DivyangPortalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using DivyangPortalWeb.Areas.Employee.Models;

namespace DivyangPortalWeb.Model.Application
{
    public partial class ProgrammingInterface
    {
        public async Task<Message<int>> SaveSignUp(SignUp model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Employee/AddEmployee"));
            var res = await PostAsync<int, SignUp>(requestUrl, model);
            return res;

        }
        public async Task<Message<int>> SaveSignUpWithcandidate(SignUp model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/AddCandidate"));
            var res = await PostAsync<int, SignUp>(requestUrl, model);
            return res;

        }
        public async Task<Message<int>> CheckUsernameEmployer(CheckUserName model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Employee/CheckUserName"));
            var res = await PostAsync<int, CheckUserName>(requestUrl, model);
            return res;
        }
        public async Task<Message<int>> CheckEmailEmployer(CheckEmail model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Employee/CheckEmail"));
           var res = await PostAsync<int, CheckEmail>(requestUrl, model);
            return res;
        }
        public async Task<Message<EmployerDetails>> LogIn(string Email, string Password)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Employee/logindata"));
            var res = await GetAsync<Message<EmployerDetails>, string, string>(requestUrl, Email, Password, "Email", "Password");
            return res;
        }
        public async Task<Message<int>> ChangeEmployerPassword(Areas.Employee.Models.ChangePassword model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Employee/ChangeEmplyeePassword"));
            var res = await PostAsync<int, Areas.Employee.Models.ChangePassword>(requestUrl, model);
            return res;

        }
        public async Task<Message<EmployeeDetails>> GetEmployerDetails(string Email)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Employee/GetEmployerDetails"));
            var res = await GetAsync<Message<EmployeeDetails>, string>(requestUrl, Email,  "Email");
            return res;
        }
        public async Task<Message<int>> GetEmployerIdDetails(string Email)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Employee/GetEmployerIdDetails"));
            var res = await GetAsync<Message<int>, string>(requestUrl, Email, "Email");
            return res;
        }
        public async Task<Message<int>> UpdateEmployerDetails(EmployeeDetails2 model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Employee/UpdateEmployerDetails"));
            var res = await PostAsync<int, EmployeeDetails2>(requestUrl, model);
            return res;

        }
        public async Task<Message<int>> CheckUserExistOrNot(CheckEmail model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Employee/CheckTPAUser"));
            var res = await PostAsync<int, CheckEmail>(requestUrl, model);
            return res;
        }
        public async Task<Message<int>> CheckUserExistOrNot(CheckEmployeeId model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Employee/GetCurrentUserId"));
            var res = await PostAsync<int, CheckEmployeeId>(requestUrl, model);
            return res;
        }

        // For jobs
        public async Task<Message<int>> CreateJob(JobModelAsApi model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Job/AddJob"));
            var res = await PostAsync<int, JobModelAsApi>(requestUrl, model);
            return res;

        }
        public async Task<Message<int>> UpdateJob(JobModelAsApi model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Job/UpdateJobDetails"));
            var res = await PostAsync<int, JobModelAsApi>(requestUrl, model);
            return res;

        }
        public async Task<Message<int>> DeleteJob(string id)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Job/DeleteJobs"));
            var res = await PostAsync<int, string>(requestUrl, id);
            return res;

        }
        public async Task<Message<Jobs>> GetJobByItsId(string id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Job/GetJobById"));
            var res = await GetAsync<Message<Jobs>, string>(requestUrl, id, "id");
            return res;
        }
        public async Task<Message<Jobs>> GetJobByItsIdForCandidateDetails(string id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Job/GetJobById"));
            var res = await GetAsync<Message<Jobs>, string>(requestUrl, id, "id");
            return res;
        }

        public async Task<Message<List<Jobs>>> GetAllActiveJobsLists()
        {
            var message = new Message<List<Jobs>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Job/GetAllActiveJobs"));
            var res = await GetAsync<Message<List<Jobs>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<Jobs>>> GetAllJobsLists()
        {
            var message = new Message<List<Jobs>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Job/GetAllJobs"));
            var res = await GetAsync<Message<List<Jobs>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<AddCompany>>> GetAllCompany()
        {
            var message = new Message<List<AddCompany>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Job/GetAllCompany"));
            var res = await GetAsync<Message<List<AddCompany>>>(requestUrl);
            return res;
        }
        public async Task<Message<AddCompany>> GetCompanyByItsId(string id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/AddCompany/GetCompanyByItsId"));
            var res = await GetAsync<Message<AddCompany>, string>(requestUrl, id, "id");
            return res;
        }
        public async Task<Message<List<Jobs>>> GetSearchedJobsLists(string jobTitle)
        {
            var message = new Message<List<Jobs>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Job/JobSearchedByTitle"));
            var res = await GetAsync<Message<List<Jobs>>,string>(requestUrl, jobTitle, "jobTitle");
            return res;
        }
        public async Task<Message<List<DropDownValues>>> GetAllDropDownValues()
        {
            var message = new Message<List<DropDownValues>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Job/GetAllValues"));
            var res = await GetAsync<Message<List<DropDownValues>>>(requestUrl);
            return res;
        }
      

        ////--- this method is  used to login for admin
        //public async Task<Message<UserLogin>> Login(string EmailId, string password)
        //{
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        //        "/api/User/logindata"));
        //    var res = await GetAsync<Message<UserLogin>,string, string>(requestUrl, EmailId, password, "EmailId", "password");
        //    return res;
        //}


        ////public async Task<Message<Adduser>> Adduser(Adduser Model)
        ////{
        ////    var requesturl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        ////        "/api/User/AddUser"));
        ////    var res = await PostAsync<string, string>(requestUrl, Model);
        ////    return res;
        ////}

        ////  this method is user for add the user data from admin
        //public async Task<Message<int>> Adduser(Adduser Model)
        //{
        //    var message = new Message<int>();
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        //        "/api/SignUp/AddUser"));
        //    var res = await PostAsync<int, Adduser>(requestUrl, Model);
        //    return res;

        //}
        //public async Task<Message<List<User>>> GetUserLists()
        //{
        //    var message = new Message<List<User>>();
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        //        "/api/SignUp/GetAllUserData"));
        //    var res = await GetAsync<Message<List<User>>>(requestUrl);
        //    return res;
        //}
        //public async Task<Message<int>> AddLeads(AddLeads Model)
        //{
        //    var message = new Message<int>();
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        //        "/api/User/AddLeads"));
        //    var res = await PostAsync<int, AddLeads>(requestUrl, Model);
        //    return res;

        //}
        //public async Task<Message<List<AddLeads>>> GetLeadsDataForUser(string UploadBY)
        //{
        //    var message = new Message<List<AddLeads>>();
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        //        "/api/User/GetAllLeadDataForUSer"));
        //    var res = await GetAsync<Message<List<AddLeads>>, string>(requestUrl, UploadBY, "UploadBY");
        //    return res;
        //}

        //public async Task<Message<AddLeads>> EditLeads(int id)
        //{
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        //        "/api/SignUp/GetLeadByID"));
        //    var res = await GetAsync<Message<AddLeads>, int>(requestUrl, id, "id");
        //    return res;
        //}

        //--------------------------this is used for change user status -----------------------------------------
        //public async Task<Message<TotalRecord>> changestatus(int status, string UserId)
        //{
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        //        "/api/User/ChangeStatus"));
        //    var res = await GetAsync<Message<TotalRecord>, int, string>(requestUrl, status, UserId, "status", "UserId");
        //    return res;
        //}
        //--------------------------this is used for get total records-----------------------------------------
        //public async Task<Message<List<AddLeads>>> GetTop5LeadData()
        //{
        //    var message = new Message<List<AddLeads>>();
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        //        "/api/SignUp/GetTop5LeadData"));
        //    var res = await GetAsync<Message<List<AddLeads>>>(requestUrl);
        //    return res;
        //}
        ////--------------------------this is used for Action leads on daily baisis-----------------------------------------
        //public async Task<Message<TotalRecord>> LeadAction(int Id = 0, string selectAction = "", string Remark = "")
        //{
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        //        "/api/User/AddLeadAction"));
        //    var res = await GetAsync<Message<TotalRecord>, int,string,string>(requestUrl, Id, selectAction, Remark, "Id", "selectAction", "Remark");
        //    return res;
        //}
        //}
        ////--------------------------this is used for bind  leads-----------------------------------------
        //public async Task<Message<List<LeadsDetails>>> BindLeadData(string EmailId, int Id)
        //{
        //    var message = new Message<List<LeadsDetails>>();
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        //        "/api/SignUp/CheckLead"));
        //    var res = await GetAsync<Message<List<LeadsDetails>>, int,string>(requestUrl, Id,EmailId, "id","EmailId");
        //    return res;
        //}

        ////--------------------------this is used for delete User-----------------------------------------
        //public async Task<Message<User>> DeleteUserByID(int id)
        //{
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        //        "/api/SignUp/DeleteUserByID"));
        //    var res = await GetAsync<Message<User>, int>(requestUrl, id, "id");
        //    return res;
        //}
        ////--------------------------this is used for Get User Details-----------------------------------------
        //public async Task<Message<User>> UserDetails(int id)
        //{
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        //        "/api/SignUp/GetUserByID"));
        //    var res = await GetAsync<Message<User>, int>(requestUrl, id, "id");
        //    return res;
        //}
        ////--------------------------this is used for Edit User Details-----------------------------------------

        //public async Task<Message<User>> EditUser(int id)
        //{
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        //        "/api/SignUp/GetUserByID"));
        //    var res = await GetAsync<Message<User>, int>(requestUrl, id, "id");
        //    return res;
        //}
        ////--------------------------this is used for update USer-----------------------------------------
        //public async Task<Message<int>> UpdateUser(Adduser Model)
        //{
        //    var message = new Message<int>();
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        //        "/api/SignUp/UpdateUser"));
        //    var res = await PostAsync<int, Adduser>(requestUrl, Model);
        //    return res;

        //}

    }


}