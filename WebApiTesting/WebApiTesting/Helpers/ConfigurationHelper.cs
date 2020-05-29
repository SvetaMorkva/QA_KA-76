using System;

namespace WebApiTesting.Helpers
{
    public class ConfigurationHelper
    {
        public static string ServiceUrl = "https://api.dropboxapi.com/2";
        public static string ContentServiceUrl = "https://content.dropboxapi.com/2";
        public static string AuthorizationToken = Environment.GetEnvironmentVariable("DROPBOX_ACCESS_TOKEN");
        public static string DefaultFilePath = "";

    }
}
