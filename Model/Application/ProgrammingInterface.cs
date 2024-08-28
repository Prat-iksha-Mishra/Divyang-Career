using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Text;
using System.Net.Http.Formatting;
using DivyangPortalWeb.Common;

namespace DivyangPortalWeb.Model.Application
{
    
    public partial class ProgrammingInterface
    {
        private readonly string t_BaseURL;
        private readonly HttpClient _httpClient;
        private Uri BaseEndpoint { get; set; }

        public ProgrammingInterface(Uri baseEndpoint)
        {
            if (baseEndpoint == null)
            {
                throw new ArgumentNullException("baseEndpoint");
            }
            BaseEndpoint = new Uri(ConfigurationManager.AppSettings["WebApiUrl"].ToString());
            _httpClient = new HttpClient();
            t_BaseURL = ConfigurationManager.AppSettings["WebApiUrl"].ToString();
        }

        //internal Task SaveUserHelp(ContactUS model)
        //{
        //    throw new NotImplementedException();
        //}

        private async Task<T> GetAsync<T>(Uri requestUrl)
        {
            addHeaders();
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }
        private async Task<T> GetAsync<T, t1>(Uri requestUrl, t1 id, string Key)
        {
            addHeaders();
            var response = await _httpClient.GetAsync(requestUrl + "?" + Key + "=" + id, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        private async Task<T> GetAsync<T, t1, t2>(Uri requestUrl, t1 id, t2 id1, string Key, string Key1)
        {
            addHeaders();
            var response = await _httpClient.GetAsync(requestUrl + "?" + Key + "=" + id + "&&" + Key1 + "=" + id1, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = "";
            try
            {
                data = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {

            }

            return JsonConvert.DeserializeObject<T>(data);

        }


        private async Task<T> GetAsync<T, t1, t2, t3>(Uri requestUrl, t1 id, t2 id1, t3 id2, string Key, string Key1, string key2)
        {
            addHeaders();
            var response = await _httpClient.GetAsync(requestUrl + "?" + Key + "=" + id + "&&" + Key1 + "=" + id1 + "&&" + key2 + "=" + id2, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        private async Task<T> GetAsync<T, t1, t2, t3, t4>(Uri requestUrl, t1 id, t2 id1, t3 id2, t4 id3, string Key, string Key1, string key2, string key3)
        {
            addHeaders();
            var response = await _httpClient.GetAsync(requestUrl + "?" + Key + "=" + id + "&&" + Key1 + "=" + id1 + "&&" + key2 + "=" + id2 + "&&" + key3 + "=" + id3, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        private async Task<T> GetAsync<T, t1, t2, t3, t4, t5>(Uri requestUrl, t1 id, t2 id1, t3 id2, t4 id3, t5 id4, string Key, string Key1, string key2, string key3, string key4)
        {
            addHeaders();
            var response = await _httpClient.GetAsync(requestUrl + "?" + Key + "=" + id + "&&" + Key1 + "=" + id1 + "&&" + key2 + "=" + id2 + "&&" + key3 + "=" + id3 + "&&" + key4 + "=" + id4, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }
        private async Task<T> GetAsync<T, t1, t2, t3, t4, t5, t6>(Uri requestUrl, t1 id, t2 id1, t3 id2, t4 id3, t5 id4, t6 id5, string Key, string Key1, string key2, string key3, string key4, string key5)
        {
            addHeaders();
            var response = await _httpClient.GetAsync(requestUrl + "?" + Key + "=" + id + "&&" + Key1 + "=" + id1 + "&&" + key2 + "=" + id2 + "&&" + key3 + "=" + id3 + "&&" + key4 + "=" + id4 + "&&" + key5 + "=" + id5, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>
        /// Common method for making POST calls
        /// </summary>
        private async Task<Message<T>> PostAsync<T>(Uri requestUrl, T content)
        {
            addHeaders();
            var response = await _httpClient.PostAsync(requestUrl.ToString(), content, new JsonMediaTypeFormatter());

            // var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Message<T>>(data);
        }
        private async Task<Message<T1>> PostAsync<T1, T2>(Uri requestUrl, T2 content)
        {
            var data = "";
            try
            {
                addHeaders();
                // HttpResponseMessage response = client.PostAsync<T>(uri, obj, new JsonMediaTypeFormatter()).Result;
                var response = await _httpClient.PostAsync(requestUrl.ToString(), content, new JsonMediaTypeFormatter());

                // var response = await _httpClient.PostAsync(requestUrl.ToString(),content, new JsonMediaTypeFormatter());
                response.EnsureSuccessStatusCode();
                data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Message<T1>>(data);
            }
            catch (Exception Ex)
            {


            }
            return JsonConvert.DeserializeObject<Message<T1>>(data);
        }

        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

        private void addHeaders()
        {
            _httpClient.DefaultRequestHeaders.Remove("XApiKey");
            _httpClient.DefaultRequestHeaders.Add("XApiKey", "2roHDLMRmu1WRr5YUj0sWoinp2u2TC8v");
        }


        public string CloseProjectMsg<T>(T id, string key, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.DeleteAsync(uri + "?" + key + "=" + id).Result;
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return "Delete Successfully";

                case HttpStatusCode.Forbidden:
                    return "Dependent child is exists please delete them first.";

                default:
                    {
                        return "Record is not deleted.";
                    }
            }
        }

        public bool Delete<T>(int id, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.DeleteAsync(String.Format("{0}/{1}", uri, id)).Result;
            return response.IsSuccessStatusCode;
        }

        public bool Delete<T>(T id, string key, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.DeleteAsync(uri + "?" + key + "=" + id).Result;
            return response.IsSuccessStatusCode;
        }

        public bool Delete<T, t1>(t1 id, string key, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.DeleteAsync(uri + "?" + key + "=" + id).Result;
            return response.IsSuccessStatusCode;
        }

        public string DeleteReturnMsg<T>(T id, string key, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.DeleteAsync(uri + "?" + key + "=" + id).Result;
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return "Delete Successfully";

                case HttpStatusCode.Forbidden:
                    return "Dependent child is exists please delete them first.";

                default:
                    {
                        return "Record is not deleted.";
                    }
            }
        }

        public string DeleteReturnMsgi<T>(T id, string key, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.DeleteAsync(uri + "?" + key + "=" + id).Result;
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return "BlackListed Successfully";

                case HttpStatusCode.Forbidden:
                    return "Dependent child is exists please delete them first.";

                default:
                    {
                        return "Record is not deleted.";
                    }
            }
        }

        public bool ExistsPost<T>(T obj, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.PostAsync<T>(uri, obj, new JsonMediaTypeFormatter()).Result;

            return response.IsSuccessStatusCode;
        }

        public string ExistsPostReturnMsg<T>(T obj, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.PostAsync<T>(uri, obj, new JsonMediaTypeFormatter()).Result;
            switch (response.StatusCode)
            {
                case HttpStatusCode.Conflict:
                    return "Reocrd is exists.";

                case HttpStatusCode.OK:
                    return "Updated Successfully";

                case HttpStatusCode.Created:
                    return "Create Successfully";

                default:
                    {
                        return "Not Indentified.";
                    }
            }
        }

        public IEnumerable<T> Get<T>(string uri)
        {
            IEnumerable<T> list = null;
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                list = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
            }
            client.Dispose();
            return list;
        }

        public T Get<T>(int id, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.GetAsync(uri + "/" + id).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<T>().Result;
        }

        public T Get<T, t1>(t1 id, string Key, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };

            HttpResponseMessage response = client.GetAsync(uri + "?" + Key + "=" + id).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<T>().Result;
        }

        public T Get<T, t1, t2>(t1 id, t2 id1, string Key, string Key1, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.GetAsync(uri + "?" + Key + "=" + id + "&&" + Key1 + "=" + id1).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<T>().Result;
        }

        public T Get<T, t1, t2, t3>(t1 id, t2 id1, t3 id2, string Key, string Key1, string Key2, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.GetAsync(uri + "?" + Key + "=" + id + "&&" + Key1 + "=" + id1 + "&&" + Key2 + "=" + id2).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<T>().Result;
        }

        public T Get<T, t1, t2, t3, t4>(t1 id, t2 id1, t3 id2, t4 id3, string Key, string Key1, string Key2, string Key3, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.GetAsync(uri + "?" + Key + "=" + id + "&&" + Key1 + "=" + id1 + "&&" + Key2 + "=" + id2 + "&&" + Key3 + "=" + id3).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<T>().Result;
        }

        public T Get<T, t1, t2, t3, t4, t5>(t1 id, t2 id1, t3 id2, t4 id3, t5 id4, string Key, string Key1, string Key2, string Key3, string Key4, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.GetAsync(uri + "?" + Key + "=" + id + "&&" + Key1 + "=" + id1 + "&&" + Key2 + "=" + id2 + "&&" + Key3 + "=" + id3 + "&&" + Key4 + "=" + id4).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<T>().Result;
        }

        public T Get<T, t1, t2, t3, t4, t5, t6>(t1 id, t2 id1, t3 id2, t4 id3, t5 id4, t6 id5, string Key, string Key1, string Key2, string Key3, string Key4, string Key5, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.GetAsync(uri + "?" + Key + "=" + id + "&&" + Key1 + "=" + id1 + "&&" + Key2 + "=" + id2 + "&&" + Key3 + "=" + id3 + "&&" + Key4 + "=" + id4 + "&&" + Key5 + "=" + id5).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<T>().Result;
        }

        public T Get<T, t1, t2, t3, t4, t5, t6, t7>(t1 id, t2 id1, t3 id2, t4 id3, t5 id4, t6 id5, t7 id6, string Key, string Key1, string Key2, string Key3, string Key4, string Key5, string Key6, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.GetAsync(uri + "?" + Key + "=" + id + "&&" + Key1 + "=" + id1 + "&&" + Key2 + "=" + id2 + "&&" + Key3 + "=" + id3 + "&&" + Key4 + "=" + id4 + "&&" + Key5 + "=" + id5 + "&&" + Key6 + "=" + id6).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<T>().Result;
        }

        public T Get<T, t1, t2, t3, t4, t5, t6, t7, t8>(t1 id, t2 id1, t3 id2, t4 id3, t5 id4, t6 id5, t7 id6, t8 id7, string Key, string Key1, string Key2, string Key3, string Key4, string Key5, string Key6, string Key7, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.GetAsync(uri + "?" + Key + "=" + id + "&&" + Key1 + "=" + id1 + "&&" + Key2 + "=" + id2 + "&&" + Key3 + "=" + id3 + "&&" + Key4 + "=" + id4 + "&&" + Key5 + "=" + id5 + "&&" + Key6 + "=" + id6 + "&&" + Key7 + "=" + id7).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<T>().Result;
        }

        public T Get<T, t1, t2, t3, t4, t5, t6, t7, t8, t9>(t1 id, t2 id1, t3 id2, t4 id3, t5 id4, t6 id5, t7 id6, t8 id7, t9 id8, string Key, string Key1, string Key2, string Key3, string Key4, string Key5, string Key6, string Key7, string Key8, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.GetAsync(uri + "?" + Key + "=" + id + "&&" + Key1 + "=" + id1 + "&&" + Key2 + "=" + id2 + "&&" + Key3 + "=" + id3 + "&&" + Key4 + "=" + id4 + "&&" + Key5 + "=" + id5 + "&&" + Key6 + "=" + id6 + "&&" + Key7 + "=" + id7 + "&&" + Key8 + "=" + id8).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<T>().Result;
        }

        public T Get<T, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10>(t1 id, t2 id1, t3 id2, t4 id3, t5 id4, t6 id5, t7 id6, t8 id7, t9 id8, t10 id9, string Key, string Key1, string Key2, string Key3, string Key4, string Key5, string Key6, string Key7, string Key8, string Key9, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.GetAsync(uri + "?" + Key + "=" + id + "&&" + Key1 + "=" + id1 + "&&" + Key2 + "=" + id2 + "&&" + Key3 + "=" + id3 + "&&" + Key4 + "=" + id4 + "&&" + Key5 + "=" + id5 + "&&" + Key6 + "=" + id6 + "&&" + Key7 + "=" + id7 + "&&" + Key8 + "=" + id8 + "&&" + Key9 + "=" + id9).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<T>().Result;
        }

        public T GetId<T>(long id, long id1, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.GetAsync(uri + "/" + id + "/" + id1).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<T>().Result;
        }

        public IEnumerable<T> GetList<T, t1, t2, t3, t4>(t1 id, t2 id1, t3 id2, t4 id3, string Key, string Key1, string Key2, string Key3, string uri)
        {
            IEnumerable<T> list = null;
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.GetAsync(uri + "?" + Key + "=" + id + "&&" + Key1 + "=" + id1 + "&&" + Key2 + "=" + id2 + "&&" + Key3 + "=" + id3).Result;
            if (response.IsSuccessStatusCode)
            {
                list = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
            }
            client.Dispose();
            return list;
        }

        public IEnumerable<T> GetList<T, t1, t2>(t1 id, t2 id1, string Key, string Key1, string uri)
        {
            IEnumerable<T> list = null;
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.GetAsync(uri + "?" + Key + "=" + id + "&&" + Key1 + "=" + id1).Result;
            if (response.IsSuccessStatusCode)
            {
                list = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
            }
            client.Dispose();
            return list;
        }

        public T GetList<T>(string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.GetAsync(uri).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<T>().Result;
        }

        public bool NewDelete<T, t1, t2>(t1 id, t2 id1, string Key, string Key1, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.DeleteAsync(uri + "?" + Key + "=" + id + "&&" + Key1 + "=" + id1).Result;
            return response.IsSuccessStatusCode;
        }

        public bool Post<T>(T obj, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.PostAsync<T>(uri, obj, new JsonMediaTypeFormatter()).Result;
            return response.IsSuccessStatusCode;
        }

        public t1 Post<T, t1>(T obj, t1 tobj, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.PostAsync<T>(uri, obj, new JsonMediaTypeFormatter()).Result;
            return response.Content.ReadAsAsync<t1>().Result;
        }

        public T Post1<T, U>(U Posted, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.PostAsync<U>(uri, Posted, new JsonMediaTypeFormatter()).Result;
            client.Dispose();
            return response.Content.ReadAsAsync<T>().Result;
        }

        public bool Post1(string str, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.PostAsync<string>(uri, str, new JsonMediaTypeFormatter()).Result;
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PostAsync<T>(T obj, string uri)
        {
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(30);
            client.BaseAddress = new Uri(t_BaseURL);
            HttpResponseMessage response = new HttpResponseMessage();
            await client.PostAsync<T>(uri, obj, new JsonMediaTypeFormatter()).ContinueWith(x => response = x.Result);
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public int PostReturnId<T>(T obj, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.PostAsync<T>(uri, obj, new JsonMediaTypeFormatter()).Result;
            string Id = Regex.Match(response.Headers.Location.AbsolutePath, @"\d+").Value;
            int ReturnId = Int32.Parse(Id);
            return ReturnId;
        }

        public string PostReturnMsg<T>(T obj, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.PostAsync<T>(uri, obj, new JsonMediaTypeFormatter()).Result;
            if (response.IsSuccessStatusCode)
                return response.ReasonPhrase;
            else
                return "Some Error Occurred";
        }

        public bool Put<T>(long id, T obj, string uri)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.PutAsync<T>(String.Format("{0}/{1}", uri, id), obj, new JsonMediaTypeFormatter()).Result;
            return response.IsSuccessStatusCode;
        }

        public bool Put<T>(int id, string key, string uri, T obj)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(t_BaseURL)
            };
            HttpResponseMessage response = client.PutAsync(uri + "?" + key + "=" + id, obj, new JsonMediaTypeFormatter()).Result;
            return response.IsSuccessStatusCode;
        }

    }
}