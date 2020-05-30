﻿using System;
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
        public static string AuthorizationToken => Environment.GetEnvironmentVariable("token");
        public static string DefaultFilePath => ConfigurationManager.AppSettings["defaultFilePath"];
		 public static string EnvAccessToken => ConfigurationManager.AppSettings["envTokenVarName"];

    }
}
