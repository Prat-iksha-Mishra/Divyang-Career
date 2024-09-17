using DivyangPortalWeb.Model.Application;
using DivyangPortalWeb.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DivyangPortalWeb.Controllers
{
    public class AccountController : Controller
    {

        #region Google SignIn


        public class TokenResponse
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; }

            [JsonProperty("refresh_token")]
            public string RefreshToken { get; set; }

            [JsonProperty("id_token")]
            public string IdToken { get; set; }
        }

        public class UserInfo
        {
            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("picture")]
            public string Picture { get; set; }
        }


        private string GoogleClientId = ConfigurationManager.AppSettings["googleClientId"];
        private string GoogleClientSecret = ConfigurationManager.AppSettings["googleClientSecret"];
        private string Google_RedirectUri = ConfigurationManager.AppSettings["google_RedirectUri"];



        public ActionResult GoogleLogin()
        {
            string authorizationEndpoint = "https://accounts.google.com/o/oauth2/auth";
            string responseType = "code";
            string scope = "https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile";

            // Construct the full URL to Google's OAuth2 authorization endpoint
            string url = $"{authorizationEndpoint}?response_type={responseType}&client_id={GoogleClientId}&redirect_uri={Google_RedirectUri}&scope={scope}&state=xyz&access_type=offline";

            // Redirect the user to the Google OAuth2 login page
            return Redirect(url);
        }


        public async Task<ActionResult> GoogleLoginCallback(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return RedirectToAction("Login");
            }

            // Exchange the authorization code for access tokens
            var tokenResponse = await ExchangeCodeForTokensAsync(code);

            if (tokenResponse != null)
            {
                // Use the access token to retrieve user information from Google's APIs
                var userInfo = await GetUserInfoAsync(tokenResponse.AccessToken);
                if (userInfo != null && userInfo.Email != null)
                {
                    CheckEmail checkEmail = new CheckEmail();
                    checkEmail.Email = userInfo.Email.ToString();
                    var res = await ApiClientFactory.Instance.CheckUserExistOrNot2(checkEmail);
                    if (res.ReturnMessage == "Employer" || res.ReturnMessage == "Candidate")
                    {
                        // Authenticate the user in your system (e.g., create a session or sign in the user)
                        Session["EmployeeEmail"] = userInfo.Email;
                        Session["EmployeeUserName"] = userInfo.Name;
                        return RedirectToAction("Dashboard", "Dashboard", new { area = "Employee" });
                    }
                    else 
                    {
                        TempData["CheckLogIn"] = "Invalid Email or Password";
                        TempData["ShowLoginPopup"] = "true"; // Indicate that the popup should be shown again
                        return Redirect(Request.UrlReferrer.ToString());
                    }
                }
            }
            TempData["CheckLogIn"] = "Invalid Email or Password";
            TempData["ShowLoginPopup"] = "true"; // Indicate that the popup should be shown again
            return Redirect(Request.UrlReferrer.ToString());
        }

        private async Task<TokenResponse> ExchangeCodeForTokensAsync(string code)
        {
            using (var client = new HttpClient())
            {
                var tokenRequest = new FormUrlEncodedContent(new Dictionary<string, string>
    {
        { "code", code },
        { "client_id", GoogleClientId },
        { "client_secret", GoogleClientSecret },
        { "redirect_uri", Google_RedirectUri },
        { "grant_type", "authorization_code" }
    });

                var response = await client.PostAsync("https://oauth2.googleapis.com/token", tokenRequest);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TokenResponse>(jsonResponse);
                }
            }

            return null;
        }

        private async Task<UserInfo> GetUserInfoAsync(string accessToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await client.GetStringAsync("https://www.googleapis.com/oauth2/v1/userinfo");
                return JsonConvert.DeserializeObject<UserInfo>(response);
            }
        }


        #endregion


        #region LinkedIn SignIN

        private string ClientId = ConfigurationManager.AppSettings["linkedIn_ClientId"];
        private string ClientSecret = ConfigurationManager.AppSettings["linkedIn_ClientSecret"];
        private string RedirectUri = ConfigurationManager.AppSettings["linkedIn_RedirectUri"];
        private string State = ConfigurationManager.AppSettings["linkedIn_State"];  // A random state string for CSRF protection



        public ActionResult LinkedSignIn()
        {
            string authorizationUrl = "https://www.linkedin.com/oauth/v2/authorization";
            string scope = "email profile openid";  // Adjust scopes based on your requirements

            string authUrl = $"{authorizationUrl}?response_type=code&client_id={ClientId}&redirect_uri={RedirectUri}&state={State}&scope={scope}";

            return Redirect(authUrl);
        }
        public async Task<ActionResult> LinkedInCallback(string code, string state)
        {
            if (string.IsNullOrEmpty(code))
            {
                // Handle error - code is missing
                return View("Login");
            }

            string tokenUrl = "https://www.linkedin.com/oauth/v2/accessToken";

            using (var httpClient = new HttpClient())
            {
                var tokenRequest = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "grant_type", "authorization_code" },
                    { "code", code },
                    { "redirect_uri", RedirectUri },
                    { "client_id", ClientId },
                    { "client_secret", ClientSecret }
                });

                HttpResponseMessage tokenResponse = await httpClient.PostAsync(tokenUrl, tokenRequest);
                string tokenResponseContent = await tokenResponse.Content.ReadAsStringAsync();

                var tokenData = JObject.Parse(tokenResponseContent);
                string accessToken = tokenData["access_token"].ToString();

                // Use the access token to fetch user information
                string userProfileUrl = "https://api.linkedin.com/v2/userinfo";
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                HttpResponseMessage userProfileResponse = await httpClient.GetAsync(userProfileUrl);
                string userProfileContent = await userProfileResponse.Content.ReadAsStringAsync();

                var userProfileData = JObject.Parse(userProfileContent);

                if (userProfileData != null)
                {
                    string email = userProfileData["email"]?.ToString();
                    CheckEmail checkEmail = new CheckEmail();
                    checkEmail.Email = email.ToString();
                    var res = await ApiClientFactory.Instance.CheckUserExistOrNot2(checkEmail);
                    if (res.ReturnMessage == "Employer" || res.ReturnMessage == "Candidate")
                    {
                        string userEmail = userProfileData["email"]?.ToString(); // Adjust based on LinkedIn API fields
                        string userName = userProfileData["name"]?.ToString() + " " + userProfileData["localizedLastName"]?.ToString();
                        // Store user data in session (consider encryption for sensitive data)
                        Session["EmployeeEmail"] = userEmail;
                        Session["EmployeeUserName"] = userName;
                        return RedirectToAction("Dashboard", "Dashboard", new { area = "Employee" });
                    }
                    else
                    {
                        TempData["CheckLogIn"] = "Invalid Email or Password";
                        TempData["ShowLoginPopup"] = "true"; // Indicate that the popup should be shown again
                        return Redirect(Request.UrlReferrer.ToString());
                    }
                }
                else
                {
                    TempData["CheckLogIn"] = "Invalid Email or Password";
                    TempData["ShowLoginPopup"] = "true"; // Indicate that the popup should be shown again
                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
        }

        #endregion


        #region FaceBook SignIn 

        public class MetaTokenResponse
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            [JsonProperty("token_type")]
            public string TokenType { get; set; }

            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; }
        }

        public class MetaUserInfo
        {
            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        private string FacebookAppId = "facebook_AppId";
        private string FacebookAppSecret = "facebook_AppSecret";
        private string FaceBook_RedirectUri = "faceBook_RedirectUri";



        public ActionResult FacebookLogin()
        {
            string authorizationEndpoint = "https://www.facebook.com/v14.0/dialog/oauth";
            string responseType = "code";
            string scope = "email";  // Add additional permissions as needed

            // Construct the full URL to Facebook's OAuth2 authorization endpoint
            string url = $"{authorizationEndpoint}?client_id={FacebookAppId}&redirect_uri={FaceBook_RedirectUri}&response_type={responseType}&scope={scope}&state=xyz";

            // Redirect the user to the Facebook OAuth2 login page
            return Redirect(url);
        }

        public async Task<ActionResult> FacebookLoginCallback(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return RedirectToAction("Login");
            }

            // Exchange the authorization code for access token
            var tokenResponse = await ExchangeMetaCodeForTokensAsync(code);

            if (tokenResponse != null)
            {
                // Use the access token to retrieve user information from Facebook
                var userInfo = await GetMetaUserInfoAsync(tokenResponse.AccessToken);

                // Authenticate the user in your system (e.g., create a session or sign in the user)
                // ...

                Session["EmployeeEmail"] = userInfo.Email;
                Session["EmployeeUserName"] = userInfo.Name;
                return RedirectToAction("Dashboard", "Dashboard", new { area = "Employee" });
            }

            TempData["CheckLogIn"] = "Invalid Email or Password";
            TempData["ShowLoginPopup"] = "true"; // Indicate that the popup should be shown again
            return Redirect(Request.UrlReferrer.ToString());
        }

        private async Task<TokenResponse> ExchangeMetaCodeForTokensAsync(string code)
        {
            using (var client = new HttpClient())
            {
                var tokenRequest = new FormUrlEncodedContent(new Dictionary<string, string>
    {
        { "client_id", FacebookAppId },
        { "client_secret", FacebookAppSecret },
        { "redirect_uri", RedirectUri },
        { "code", code }
    });

                var response = await client.PostAsync("https://graph.facebook.com/v14.0/oauth/access_token", tokenRequest);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TokenResponse>(jsonResponse);
                }
            }

            return null;
        }

        private async Task<UserInfo> GetMetaUserInfoAsync(string accessToken)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync($"https://graph.facebook.com/me?fields=email,name&access_token={accessToken}");
                return JsonConvert.DeserializeObject<UserInfo>(response);
            }
        }

        #endregion
    }
}