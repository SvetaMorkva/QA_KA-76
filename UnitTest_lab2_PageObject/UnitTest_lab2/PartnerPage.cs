using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using System.Threading;

namespace UnitTest_lab2
{
    public class PartnerPage
    {
        private IWebDriver _driver;
        public PartnerPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#block-topheaderinpartnerspage h1")]
        private IWebElement PageHeader;

        [FindsBy(How = How.CssSelector, Using = "img[alt = 'Creatio']")]
        private IWebElement Logo;

        [FindsBy(How = How.CssSelector, Using = "jdiv.hoverl_6R")]
        private IWebElement OpenChat;

        [FindsBy(How = How.CssSelector, Using = "#jivo_close_button")]
        private IWebElement CloseChat;

        [FindsBy(How = How.CssSelector, Using = "input[ type = text]")]
        private IWebElement SearchForm;

        [FindsBy(How = How.CssSelector, Using = ".startSearch-btn")]
        private IWebElement SearchButtom;

        [FindsBy(How = How.CssSelector, Using = "#mp-catalog-item-1 div")]
        private IWebElement Item1;

        [FindsBy(How = How.CssSelector, Using = "#mp-catalog-item-1 .mp-catalog-item-description-full-title")]
        private IWebElement ItemDescription;

        [FindsBy(How = How.Id, Using = "mp-catalog-filter-select-region")]
        private IWebElement Region;

        [FindsBy(How = How.Id, Using = "mp-catalog-filter-select-country")]
        private IWebElement Country;

        



        public string GetPageHeader() => PageHeader.Text;

        public PartnerPage SelectPartner(int n)
        {
            IWebElement Partner = _driver.FindElement(By.CssSelector($"#mp-catalog-item-{n} div"));
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(Partner));
            Partner.Click();
            return this;
        }

        public PartnerPage ChatClose()
        {
            Thread.Sleep(2000);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(OpenChat));
            OpenChat.Click();
            Thread.Sleep(2000);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(CloseChat));
            CloseChat.Click();
            return this;
        }

        public PartnerPage SearchPartner(string expected_company)
        { 
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(SearchForm));
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(SearchButtom));
            
            Actions action = new Actions(_driver);
            Thread.Sleep(1000);
            SearchForm.SendKeys(expected_company);
            SearchButtom.Click();
            Thread.Sleep(5000);
            
            return this;
        }

        public string GetDescription(int n) => _driver.FindElement(By.CssSelector($"#mp-catalog-item-{n} .mp-catalog-item-description-full-title")).Text;
        public string GetCountry(int n) => _driver.FindElement(By.CssSelector($"#mp-catalog-item-{n} .mp-catalog-item-description-teaser")).Text;

        public PartnerPage MoveItem(int n)
        {
            Actions action = new Actions(_driver);
            IWebElement Item = _driver.FindElement(By.CssSelector($"#mp-catalog-item-{n} div"));
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(Item));
            Thread.Sleep(5000);
            action.MoveToElement(Item).Perform();
           
            return this;
        }

        public PartnerPage SelectRegion(string region)
        {
            //new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(Region));
            SelectElement SelectRegion = new SelectElement(Region);
            SelectRegion.SelectByText(region);
            return this;

        }

        public PartnerPage SelectCountry(string country)
        {
            //new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(Country));
            SelectElement SelectCountry = new SelectElement(Country);
            SelectCountry.SelectByText(country);
            return this;

        }

        public PartnerPage GoToMainPage()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(Logo));
            Logo.Click();
            return this;
        }

        public PartnerPage GoToPageItem()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(Item1));
            Item1.Click();
            js.ExecuteScript("window.scrollBy(0,250)", "");
            return this;
        }
    }
    
}
