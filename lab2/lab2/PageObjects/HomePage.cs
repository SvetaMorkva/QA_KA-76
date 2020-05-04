using Lab2.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;


namespace lab2.PageObjects

{

    public class HomePage

    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public HomePage GoToPage()
        {
            // to go to the home page user needs to log in and he/she will
            // be redirected automatically
            LoginPage loginObj = new LoginPage(driver);
            loginObj.GoToPage();
            loginObj.FillUsernameAndPassword();
            loginObj.SubmitLoginInfo();
            return this;
        }

        public HomePage GoToTemplatesPage()
        {
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl("https://app.hubspot.com/templates/7600578");
            return this;
        }

        public HomePage GoToContactsPage()
        {
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl("https://app.hubspot.com/contacts/");
            return this;
        }

        public HomePage GoToTasksPage()
        {
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl("https://app.hubspot.com/contacts/7600578/tasks/");
            return this;
        }

        public HomePage GoToSettingsPage()
        {
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl("https://app.hubspot.com/settings");
            return this;
        }

    }
}