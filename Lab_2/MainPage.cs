using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lab_2
{
    public class MainPage
    {
        private IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "header li:nth-of-type(4) a")]
        private IWebElement ArticlesPage;

        [FindsBy(How = How.CssSelector, Using = "header li:nth-of-type(6) a")]
        private IWebElement JobsPage;

        [FindsBy(How = How.CssSelector, Using = "header li:nth-of-type(5) a")]
        private IWebElement SalariesPage;

        [FindsBy(How = How.ClassName, Using = "min-profile")]
        private IWebElement ProfilePage;

        [FindsBy(How = How.CssSelector, Using = ".right-part a")]
        private IWebElement LogInPage;

        [FindsBy(How = How.CssSelector, Using = ".footer-lang-switch a:nth-of-type(2)")]
        private IWebElement SwitchLink;

        public MainPage GoToArticlesPage()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(ArticlesPage));
            ArticlesPage.Click();
            return this;
        }

        public MainPage GoToJobsPage()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(JobsPage));
            JobsPage.Click();
            return this;
        }

        public MainPage GoToSalariesPage()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(SalariesPage));
            SalariesPage.Click();
            return this;
        }

        public MainPage GoToProfilePage()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(ProfilePage));
            ProfilePage.Click();
            return this;
        }

        public MainPage GoToLogInPage()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(LogInPage));
            LogInPage.Click();
            return this;
        }

        public MainPage SwitchLanguageToEnglish()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(SwitchLink));
            if (SwitchLink.Text == "English")
                SwitchLink.Click();
            return this;
        }
    }
}
