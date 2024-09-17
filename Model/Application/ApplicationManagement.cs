using DivyangPortalWeb.Common;
using DivyangPortalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using DivyangPortalWeb.Areas.Employee.Models;
using DivyangPortalWeb.Areas.Candidate.Models;

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
        public async Task<Message<int>> CheckEmailEmployerUpdate(CheckEmail model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Employee/CheckEmailUpdate"));
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
        public async Task<Message<EmployeeDetails2>> GetEmployerDetails(string Email)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Employee/GetEmployerDetails"));
            var res = await GetAsync<Message<EmployeeDetails2>, string>(requestUrl, Email,  "Email");
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
        public async Task<Message<List<CompanyCategories>>> CompanyCategories()
        {
            var message = new Message<List<CompanyCategories>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/AddCompany/CompanyCategories"));
            var res = await GetAsync<Message<List<CompanyCategories>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<CompanySize>>> CompanySize()
        {
            var message = new Message<List<CompanySize>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/AddCompany/BindCompanySize"));
            var res = await GetAsync<Message<List<CompanySize>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<State>>> BindState()
        {
            var message = new Message<List<State>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/AddCompany/BindState"));
            var res = await GetAsync<Message<List<State>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<District>>> BindDistict(string StateId)
        {
            var message = new Message<List<District>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/AddCompany/BindDistrict"));
            var res = await GetAsync<Message<List<District>>,string>(requestUrl,StateId, "StateId");
            return res;
        }
        public async Task<Message<List<Cities>>> BindCities(string StateId, string District , string SubDistrict )
        {
            var message = new Message<List<Cities>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/BindCities"));
            var res = await GetAsync<Message<List<Cities>>, string, string, string>(requestUrl, StateId, District, SubDistrict, "StateId", "District", "SubDistrict");
            return res;
        }
        public async Task<Message<int>> AddCompay(Areas.Employee.Models.FinalCompany model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/AddCompany/AddNewCompany"));
            var res = await PostAsync<int, Areas.Employee.Models.FinalCompany>(requestUrl, model);
            return res;

        }
        public async Task<Message<List<FinalCompany>>> GetCompanyList(string Email)
        {
            var message = new Message<List<FinalCompany>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/AddCompany/GetCompanyForListPage"));
            var res = await GetAsync<Message<List<FinalCompany>>, string>(requestUrl, Email, "Email");
            return res;
        }
        public async Task<Message<int>> DeleteCompany(string CompanyId)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/AddCompany/DeleteCompany"));
            var res = await GetAsync<Message<int>, string>(requestUrl, CompanyId, "CompanyId");
            return res;
        }
        public async Task<Message<FinalCompany>> GetCompanyEdit(string Id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/AddCompany/GetCompanyForEdit"));
            var res = await GetAsync<Message<FinalCompany>, string>(requestUrl, Id, "Id");
            return res;
        }
        public async Task<Message<int>> UpdateCompay(Areas.Employee.Models.FinalCompany model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/AddCompany/UpdateNewCompany"));
            var res = await PostAsync<int, Areas.Employee.Models.FinalCompany>(requestUrl, model);
            return res;

        }
        public async Task<Message<FinalCompany>> GetCompanyDataForDetail(string Id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/AddCompany/GetAllCompanyDataForDetails"));
            var res = await GetAsync<Message<FinalCompany>, string>(requestUrl, Id, "Id");
            return res;
        }
        public async Task<Message<int>> ChangeCandidatePassword(Areas.Candidate.Models.ChangeCandidatePassword model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/ChangeCandidatePassword"));
            var res = await PostAsync<int, Areas.Candidate.Models.ChangeCandidatePassword>(requestUrl, model);
            return res;

        }
        public async Task<Message<Areas.Candidate.Models.CandidateDetails>> GetCandidateDetails(string Email)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetUserDetails"));
            var res = await GetAsync<Message<Areas.Candidate.Models.CandidateDetails>, string>(requestUrl, Email, "Email");
            return res;
        }
        public async Task<Message<int>> UpdateCandidateDetails(Areas.Candidate.Models.CandidateDetails model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/UpdateCandidateDetails"));
            var res = await PostAsync<int, Areas.Candidate.Models.CandidateDetails>(requestUrl, model);
            return res;

        }
        public async Task<Message<int>> EducationUpdateCandidateDetails(Areas.Candidate.Models.CandidateEducationDetails model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/EducationUpdateCandidateDetails"));
            var res = await PostAsync<int, Areas.Candidate.Models.CandidateEducationDetails>(requestUrl, model);
            return res;

        }
        public async Task<Message<int>> ExperinceUpdateCandidateDetails(Areas.Candidate.Models.CandidateExperienceDetails model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/ExperienceUpdateCandidateDetails"));
            var res = await PostAsync<int, Areas.Candidate.Models.CandidateExperienceDetails>(requestUrl, model);
            return res;

        }
        public async Task<Message<int>> DisabilityUpdateCandidateDetails(Areas.Candidate.Models.CandidateDisablityInfoDetails model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/DisabilityUpdateCandidateDetails"));
            var res = await PostAsync<int, Areas.Candidate.Models.CandidateDisablityInfoDetails>(requestUrl, model);
            return res;

        }
        public async Task<Message<List<Areas.Candidate.Models.Language>>> GetPrimaryLanguageOptions()
        {
            var message = new Message<List<Areas.Candidate.Models.Language>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetLanguage"));
            var res = await GetAsync<Message<List<Areas.Candidate.Models.Language>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<Areas.Candidate.Models.Gender>>> GetGenderOptions()
        {
            var message = new Message<List<Areas.Candidate.Models.Gender>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetGender"));
            var res = await GetAsync<Message<List<Areas.Candidate.Models.Gender>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<Areas.Candidate.Models.Language>>> GetEmploymentStatusOptions()
        {
            var message = new Message<List<Areas.Candidate.Models.Language>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetEmploymentStatus"));
            var res = await GetAsync<Message<List<Areas.Candidate.Models.Language>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<SubDistrict>>> BindSubDistict(string StateId, string DistrictId)
        {
            var message = new Message<List<SubDistrict>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/BindSubDistrict"));
            var res = await GetAsync<Message<List<SubDistrict>>, string, string>(requestUrl, StateId, DistrictId, "StateId", "DistrictId");
            return res;
        }
        public async Task<Message<List<Areas.Candidate.Models.Gender>>> GetAddressType()
        {
            var message = new Message<List<Areas.Candidate.Models.Gender>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetAddressType"));
            var res = await GetAsync<Message<List<Areas.Candidate.Models.Gender>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<Areas.Candidate.Models.Gender>>> GetAddressSubType()
        {
            var message = new Message<List<Areas.Candidate.Models.Gender>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetAddressSubType"));
            var res = await GetAsync<Message<List<Areas.Candidate.Models.Gender>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<Areas.Candidate.Models.Gender>>> GetTerritoryTypes()
        {
            var message = new Message<List<Areas.Candidate.Models.Gender>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetTerritoryTypes"));
            var res = await GetAsync<Message<List<Areas.Candidate.Models.Gender>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<Areas.Candidate.Models.Language>>> GetMaritalStatusOptions()
        {
            var message = new Message<List<Areas.Candidate.Models.Language>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetMaritalStatus"));
            var res = await GetAsync<Message<List<Areas.Candidate.Models.Language>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<Areas.Candidate.Models.Language>>> GetReligionsOptions()
        {
            var message = new Message<List<Areas.Candidate.Models.Language>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetReligions"));
            var res = await GetAsync<Message<List<Areas.Candidate.Models.Language>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<Areas.Candidate.Models.Gender>>> GetCastes()
        {
            var message = new Message<List<Areas.Candidate.Models.Gender>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetCastes"));
            var res = await GetAsync<Message<List<Areas.Candidate.Models.Gender>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<Areas.Candidate.Models.Language>>> GetUIDTypeOptions()
        {
            var message = new Message<List<Areas.Candidate.Models.Language>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetUIDType"));
            var res = await GetAsync<Message<List<Areas.Candidate.Models.Language>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<Areas.Candidate.Models.Language>>> GetHighestEducationAttained()
        {
            var message = new Message<List<Areas.Candidate.Models.Language>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetHighestEducationAttained"));
            var res = await GetAsync<Message<List<Areas.Candidate.Models.Language>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<Language>>> GetEduaction(string HighestEducationAttainedID)
        {
            var message = new Message<List<Language>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetEducation"));
            var res = await GetAsync<Message<List<Language>>, string>(requestUrl, HighestEducationAttainedID,  "HighestEducationAttainedID");
            return res;
        }
        public async Task<Message<List<Language>>> GetSpecializations(string EducationID)
        {
            var message = new Message<List<Language>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetSpecializations"));
            var res = await GetAsync<Message<List<Language>>, string>(requestUrl, EducationID, "EducationID");
            return res;
        }
        public async Task<Message<List<Areas.Candidate.Models.Language>>> GetBoardUniversitiesDropDownOptions()
        {
            var message = new Message<List<Areas.Candidate.Models.Language>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetBoardUniversities"));
            var res = await GetAsync<Message<List<Areas.Candidate.Models.Language>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<Areas.Candidate.Models.Language>>> GetMounthOptions()
        {
            var message = new Message<List<Areas.Candidate.Models.Language>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetMonth"));
            var res = await GetAsync<Message<List<Areas.Candidate.Models.Language>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<Areas.Candidate.Models.Language>>> GetGradeTypesOptions()
        {
            var message = new Message<List<Areas.Candidate.Models.Language>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetGradeTypesOptions"));
            var res = await GetAsync<Message<List<Areas.Candidate.Models.Language>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<Areas.Candidate.Models.Gender>>> GetCourseNatureDropDown()
        {
            var message = new Message<List<Areas.Candidate.Models.Gender>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetCourseNature"));
            var res = await GetAsync<Message<List<Areas.Candidate.Models.Gender>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<Areas.Candidate.Models.Language>>> GetCurrentEmployerSectorOptions()
        {
            var message = new Message<List<Areas.Candidate.Models.Language>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetCurrentEmployerSector"));
            var res = await GetAsync<Message<List<Areas.Candidate.Models.Language>>>(requestUrl);
            return res;
        }
        public async Task<Message<List<Areas.Candidate.Models.Language>>> GetDisabilityType()
        {
            var message = new Message<List<Areas.Candidate.Models.Language>>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/GetDisabilityType"));
            var res = await GetAsync<Message<List<Areas.Candidate.Models.Language>>>(requestUrl);
            return res;
        }
        public async Task<Message<int>> CheckEmailCandidateUpdate(CheckEmail model)
        {
            var message = new Message<int>();
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Candidate/CheckEmailUpdate"));
            var res = await PostAsync<int, CheckEmail>(requestUrl, model);
            return res;
        }
    }
}