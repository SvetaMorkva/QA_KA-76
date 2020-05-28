using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TestDropboxApi.DataModels;

namespace Dropbox.Api.Test.Infrastructure.PageObjects
{
    public class LoginPage : BasePage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        private const string PASSWORD = ".login-password .password-input";
        private const string EMAIL = ".login-email .autofocus";
        private const string LOGIN_BUTTON = ".signin-button .sign-in-text";


        [FindsBy(How = How.CssSelector, Using = EMAIL)]
        private IWebElement EmailField;
        [FindsBy(How = How.CssSelector, Using = PASSWORD)]
        private IWebElement PasswordField;
        [FindsBy(How = How.CssSelector, Using = LOGIN_BUTTON)]
        private IWebElement LoginButton;
        
        
        public BasePage Login(string email, string password)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(EmailField));
            EmailField.SendKeys(email);
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(PasswordField));
            PasswordField.SendKeys(password);
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(LoginButton));
            LoginButton.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementExists(By.Id("hplogo")));

            return new BasePage(driver);
        }
    }
}
