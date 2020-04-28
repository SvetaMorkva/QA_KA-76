using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lab_2
{
    public class JobsPage
    {
        private IWebDriver _driver;

        public JobsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".sub li:nth-of-type(3) a")]
        private IWebElement SelectCompanies;

        [FindsBy(How = How.ClassName, Using = "job")]
        [FindsBy(How = How.CssSelector, Using = "input[class='company']")]
        private IWebElement TextBoxFindCompany;

        [FindsBy(How = How.ClassName, Using = "btn-search")]
        private IWebElement SearchButton;

        [FindsBy(How = How.CssSelector, Using = ".h2 a")]
        private IWebElement FirstCompanyHeader;

        [FindsBy(How = How.CssSelector, Using = "h1[class='g-h2']")]
        private IWebElement CompanyHeader;

        [FindsBy(How = How.ClassName, Using = "vt")]
        private IWebElement SearchJobName;

        [FindsBy(How = How.ClassName, Using = "company")]
        private IWebElement SearchCompanyName;


        public JobsPage SelectCompaniesPage()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(SelectCompanies));
            SelectCompanies.Click();
            return this;
        }

        public JobsPage TypeFindCompanyName(string CompanyName)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(TextBoxFindCompany));
            TextBoxFindCompany.SendKeys(CompanyName);
            return this;
        }

        public JobsPage PerformSearch()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(SearchButton));
            SearchButton.Click();
            return this;
        }

        public JobsPage ViewFirstCompany()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(FirstCompanyHeader));
            FirstCompanyHeader.Click();
            return this;
        }

        public string GetCompanyHeader() => CompanyHeader.Text;

        public string GetCompanyName() => SearchCompanyName.Text;

        public string GetJobName() => SearchJobName.Text;

        public JobsPage SelectJobCategory(string JobCategory)
        {
            IWebElement SelectJob = _driver.FindElement(By.XPath($"//select/option[text()='{JobCategory}']"));
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(SelectJob));
            SelectJob.Click();
            return this;
        }
    }
}
