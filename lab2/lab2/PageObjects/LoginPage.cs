using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;


namespace Lab2.PageObjects

{

    public class LoginPage

    {
        private IWebDriver driver;

        private readonly string email = "olha.pashnieva@gmail.com";
        private readonly string password = "QALab123456";

        public readonly string loginUrl = "https://app.hubspot.com/login";

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement usernameField;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement passwordField;

        [FindsBy(How = How.Id, Using = "loginBtn")]
        public IWebElement loginButton;



        public LoginPage GoToPage()
        {
            driver.Navigate().GoToUrl(loginUrl);
            return this;
        }

        public LoginPage FillUsernameAndPassword()
        {
            usernameField.SendKeys(email);
            passwordField.SendKeys(password);
            return this;
        }

        public LoginPage SubmitLoginInfo()
        {
            loginButton.Click();
            return this;
        }

    }
}