using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public IWebElement ArticlesPage;

        [FindsBy(How = How.CssSelector, Using = "header li:nth-of-type(6) a")]
        public IWebElement JobsPage;

        [FindsBy(How = How.CssSelector, Using = "header li:nth-of-type(5) a")]
        public IWebElement SalariesPage;

        [FindsBy(How = How.ClassName, Using = "min-profile")]
        public IWebElement ProfilePage;

        [FindsBy(How = How.CssSelector, Using = ".right-part a")]
        public IWebElement LogInPage;

        [FindsBy(How = How.CssSelector, Using = ".footer-lang-switch a:nth-of-type(2)")]
        public IWebElement SwitchLink;

        public MainPage GoToArticlesPage()
        {
            ArticlesPage.Click();
            return this;
        }

        public MainPage GoToJobsPage()
        {
            JobsPage.Click();
            return this;
        }

        public MainPage GoToSalariesPage()
        {
            SalariesPage.Click();
            return this;
        }

        public MainPage GoToProfilePage()
        {
            ProfilePage.Click();
            return this;
        }

        public MainPage GoToLogInPage()
        {
            LogInPage.Click();
            return this;
        }

        public MainPage SwitchLanguageToEnglish()
        {
            if (SwitchLink.Text == "English")
                SwitchLink.Click();
            return this;
        }
    }
}
