
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;

namespace DivyangPortalWeb.Model.Application
{
    internal static class ApiClientFactory
    {
        private static Uri apiUri;
        private static Lazy<ProgrammingInterface> restClient = new Lazy<ProgrammingInterface>(
            () => new ProgrammingInterface(apiUri), LazyThreadSafetyMode.ExecutionAndPublication);

        static ApiClientFactory()
        {
            apiUri = new Uri(ConfigurationManager.AppSettings["WebApiUrl"].ToString());
        }

        public static ProgrammingInterface Instance
        {
            get
            {
                return restClient.Value;
            }
        }
    }
}