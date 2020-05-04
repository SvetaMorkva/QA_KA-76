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
        
        // conversations -> templates
        [FindsBy(How = How.Id, Using = "nav-primary-conversations-branch")]
        public IWebElement conversationsPrimaryNav;

        [FindsBy(How = How.Id, Using = "nav-secondary-templates")]
        public IWebElement templatesSecondaryNav;

        // contacts -> contacts
        [FindsBy(How = How.Id, Using = "nav-primary-contacts-branch")]
        public IWebElement contactsPrimaryNav;

        [FindsBy(How = How.Id, Using = "nav-secondary-contacts")]
        public IWebElement contactsSecondaryNav;

        // sales -> tasks
        [FindsBy(How = How.Id, Using = "nav-primary-sales-branch")]
        public IWebElement salesPrimaryNav;

        [FindsBy(How = How.Id, Using = "nav-secondary-tasks")]
        public IWebElement tasksSecondaryNav;

        // settings
        [FindsBy(How = How.Id, Using = "navSetting")]
        public IWebElement settingsNav;


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
            wait.Until(ExpectedConditions.ElementToBeClickable(conversationsPrimaryNav));
            conversationsPrimaryNav.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(templatesSecondaryNav));
            templatesSecondaryNav.Click();
            return this;
        }

        public HomePage GoToContactsPage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(contactsPrimaryNav));
            contactsPrimaryNav.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(contactsSecondaryNav));
            contactsSecondaryNav.Click();
            return this;
        }

        public HomePage GoToTasksPage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(salesPrimaryNav));
            salesPrimaryNav.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(tasksSecondaryNav));
            tasksSecondaryNav.Click();
            return this;
        }

        public HomePage GoToSettingsPage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(settingsNav));
            settingsNav.Click();

            return this;
        }

    }
}