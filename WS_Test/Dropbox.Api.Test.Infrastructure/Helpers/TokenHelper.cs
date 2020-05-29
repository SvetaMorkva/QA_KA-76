﻿using Dropbox.Api.Test.Infrastructure.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.Infrastructure.Helpers
{
    public class TokenHelper
    {

        private static string token = null;
        public static string GetToken()
        {
            if (token == null)
            {
                if (ConfigurationHelper.ShouldUseEnvVar)
                {
                    token = Environment.GetEnvironmentVariable(ConfigurationHelper.EnvTokenVarName);
                }
                else
                {
                    string email = ConfigurationHelper.Email;
                    string password = ConfigurationHelper.Password;

                    string oauth2Url = ConfigurationHelper.OAuth2Url;
                    string clientId = ConfigurationHelper.ClientId;
                    string redirectUri = ConfigurationHelper.RedirectUri;
                    string responseType = ConfigurationHelper.ResponseType;

                    string url = oauth2Url + "?client_id=" + clientId + "&redirect_uri=" + redirectUri + "&response_type=" + responseType;

                    var options = new ChromeOptions();
                    options.AddArgument("start-maximized");

                    var driver = new ChromeDriver(options);
                    driver.Navigate().GoToUrl(url);

                    _ = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(dr => dr.Url == url);

                    var loginPage = new LoginPage(driver);

                    string resultUrl = loginPage.Login(email, password).GetUrl();

                    string s = resultUrl.Substring(resultUrl.IndexOf('=') + 1);
                    string tok = "Bearer " + s.Remove(s.IndexOf('&'));


                    driver.Quit();

                    token = tok;
                }
            }

            return token;
        }
    }
}
