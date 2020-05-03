using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lab2_pages.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private readonly string url = @"https://app.knackbusiness.com/login";

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement loginLineEdit;

        [FindsBy(How = How.CssSelector, Using = ".btn")]
        public IWebElement nextButton;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement passwordLineEdit;

        public String GetCurrntUrl() => _driver.Url;

        public LoginPage LoadLoginPage()
        {
            _driver.Navigate().GoToUrl(url);
            return this;
        }

        public DashBoard Login(string email, string password)
        {
            loginLineEdit.SendKeys(email);
            passwordLineEdit.SendKeys(password);
            System.Threading.Thread.Sleep(1000);
            nextButton.Click();
            return new DashBoard(_driver);
        }
    }
}
