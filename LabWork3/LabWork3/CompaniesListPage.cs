using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace LabWork3.Pages
{
    public class CompaniesListPage
    {
        private IWebDriver _driver;

        public const string COMPANIES_MENU_ID = "nav-secondary-companies";
        public const string ADD_COMPANY_BUTTON_CSS = "button[data-selenium-test='new-object-button']";
        public const string DOMAIN_NAME_CSS = "input[data-field='domain']";
        public const string COMPANY_NAME_CSS = "input[data-field='name']";
        public const string COMPANY_DESCRIPTION_CSS = "textarea[data-field='description']";
        public const string CREATE_COMPANY_BUTTON_CSS = "li[class='uiListItem private-list__item p-bottom-1']";
        public const string COMPANIES_TABLE_CLASSNAME = "ReactTable";


        [FindsBy(How = How.Id, Using = COMPANIES_MENU_ID)]
        public IWebElement openCompaniesListButton;

        [FindsBy(How = How.CssSelector, Using = ADD_COMPANY_BUTTON_CSS)]
        public IWebElement AddCompanyButton;

        [FindsBy(How = How.CssSelector, Using = DOMAIN_NAME_CSS)]
        public IWebElement domainName;

        [FindsBy(How = How.CssSelector, Using = COMPANY_NAME_CSS)]
        public IWebElement companyName;

        [FindsBy(How = How.CssSelector, Using = COMPANY_DESCRIPTION_CSS)]
        public IWebElement companyDescription;

        [FindsBy(How = How.CssSelector, Using = CREATE_COMPANY_BUTTON_CSS)]
        public IWebElement createCompanyButton;


        public CompaniesListPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public String GetCurrntUrl() => _driver.Url;

        public CompanyPage AddCompany(String domain, String name, String description = " ")
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(ADD_COMPANY_BUTTON_CSS)));
            AddCompanyButton.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(DOMAIN_NAME_CSS)));

            domainName.SendKeys(domain);
            companyName.SendKeys(name);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(COMPANY_DESCRIPTION_CSS)));
            companyDescription.SendKeys(description);

            createCompanyButton.Click();

            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector(CompanyPage.COMPANY_TITLE_CSS)));
            return new CompanyPage(_driver);
        }

    }
}
