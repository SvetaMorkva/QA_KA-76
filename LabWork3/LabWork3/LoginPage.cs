using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

using System.Threading;

namespace LabWork3.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;

        public const string USER_NAME_TEXT_FIELD_ID = "username";
        public const string PASSWORD_TEXT_FIELD_ID = "password";
        public const string LOGIN_BUTTON_ID = "loginBtn";


        [FindsBy(How = How.Id, Using = USER_NAME_TEXT_FIELD_ID)]
        public IWebElement usernameField;
        [FindsBy(How = How.Id, Using = PASSWORD_TEXT_FIELD_ID)]
        public IWebElement passwordField;
        [FindsBy(How = How.Id, Using = LOGIN_BUTTON_ID)]
        public IWebElement loginButton;

        public String GetCurrntUrl() => _driver.Url;


        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public LoginPage LoadLoginPage()
        {
            _driver.Navigate().GoToUrl("https://app.hubspot.com/login");
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id(USER_NAME_TEXT_FIELD_ID)));
            return this;
        }

        public GreetinPage Login(String username, string password)
        {
            usernameField.Clear();
            usernameField.SendKeys(username);
            passwordField.Clear();
            passwordField.SendKeys(password);
            loginButton.Click();
            Thread.Sleep(10000);
            return new GreetinPage(_driver);
        }
    }
}
