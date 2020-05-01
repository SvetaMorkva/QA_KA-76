using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace LabWork3.Pages
{
    public class CompanyPage
    {
        private IWebDriver _driver;

        public const string COMPANIES_MENU_ID = "nav-secondary-companies";
        public const string COMPANY_TITLE_CSS = "div[class='text-center']";
        public const string LOGIN_BUTTON_ID = "loginBtn";

        [FindsBy(How = How.Id, Using = COMPANIES_MENU_ID)]
        public IWebElement openCompaniesListButton;

        [FindsBy(How = How.Id, Using = LOGIN_BUTTON_ID)]
        public IWebElement signOut;

        public CompanyPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public String GetCurrntUrl() => _driver.Url;
    }
}
