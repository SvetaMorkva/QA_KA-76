using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace QA_Lab2
{
    class CustomerPage
    {
        private readonly IWebDriver driver;
        private readonly string url = @"https://www.zoho.com/customers.html";

        public CustomerPage(IWebDriver browser)
        {
            driver = browser;
            driver.Manage().Window.Maximize();

            PageFactory.InitElements(browser, this);
        }

        private IList<IWebElement> ArticlesOfSelectedIndustry;

        [FindsBy(How = How.CssSelector, Using = ".filter.industry")]
        private IWebElement IndustryWebElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".reset-filter")]
        public IWebElement ClearAllButton { get; set; }



        public bool ClearAllButtonIsVisible => ClearAllButton.Displayed && ClearAllButton.Enabled;
        public bool AllIndustryValuesAppeared => IndustrySelectElement().Options.Count > 50;


        // navigate
        public CustomerPage OpenCustomerPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }


        // act method

        public CustomerPage SelectValueInIndustryDropDown(string textIndustry)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(d => AllIndustryValuesAppeared);

            var select = IndustrySelectElement();
            select.SelectByValue(textIndustry);

            return this;
        }

        public CustomerPage OnClearAllButtonClick()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(ClearAllButton, 1, 1).Click().Build().Perform();
            return this;
        }


        // method for assert

        public bool CheckTextOfIndustryDropDown(string expectedText)
        {
            return expectedText == IndustrySelectElement().SelectedOption.Text;
        }

        public bool ArticlesOfSelectedIndustryIsVisible() 
        {
            if (ArticlesOfSelectedIndustry.Count == 0)
            {
                return false;
            }
            foreach (var a in ArticlesOfSelectedIndustry)
            {
                if (!a.Displayed)
                    return false;
            }
            return true;
        }

        // additional - for greater usability

        public SelectElement IndustrySelectElement()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(d => IndustryWebElement);
            return new SelectElement(IndustryWebElement);
        }

        public void GetArticlesOfSelectedIndustry(string selectedIndustry)
        {
            ArticlesOfSelectedIndustry = driver.FindElements(By.CssSelector("[class*=" + selectedIndustry + "]"));
        }

        public CustomerPage WaitUntiTransparentClearAllButtonDisappeared()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20))
                .Until(d => driver.FindElements(By.CssSelector("div[class$='reset-filter']")).Count == 0);
            return this;
        }

        public CustomerPage WaitUntiTransparentClearAllButtonCreated()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20))
                .Until(d => driver.FindElements(By.CssSelector("div[class$='reset-filter']")));
            return this;
        }
    }
}
