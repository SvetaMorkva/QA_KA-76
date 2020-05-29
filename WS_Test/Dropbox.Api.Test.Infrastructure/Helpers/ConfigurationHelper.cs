using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDropboxApi.Helpers
{
    public class ConfigurationHelper
    {
        public static string ServiceUrl => ConfigurationManager.AppSettings["serviceUrl"];
        public static string ContentServiceUrl => ConfigurationManager.AppSettings["contentServiceUrl"];
        public static string AuthorizationToken => ConfigurationManager.AppSettings["token"];
        public static string DefaultFilePath => ConfigurationManager.AppSettings["defaultFilePath"];

        public static string Email => ConfigurationManager.AppSettings["email"];
        public static string Password => ConfigurationManager.AppSettings["password"];
        public static string OAuth2Url => ConfigurationManager.AppSettings["oauth2Url"];
        public static string ClientId => ConfigurationManager.AppSettings["clientId"];
        public static string RedirectUri => ConfigurationManager.AppSettings["redirectUri"];
        public static string ResponseType => ConfigurationManager.AppSettings["responseType"];
        public static bool ShouldUseEnvVar => Convert.ToBoolean(ConfigurationManager.AppSettings["shouldUseEnvVar"]);
        public static string EnvTokenVarName => ConfigurationManager.AppSettings["envTokenVarName"];
    }
}
