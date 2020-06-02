using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace PageObjects
{
    class InsightsPage
    {
        private IWebDriver driver;

        public InsightsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private const string SELECT_FIELD = "//*[@id='main']/div[1]/div[4]/section/div/div[1]/div/div[2]/div/div/span[1]/div/div[1]";
        private const string SELECT_ITEM = "//*[@id='main']/div[1]/div[4]/section/div/div[1]/div/div[2]/div/div/span[1]/div/div[2]/div/ul/li[1]/label/span";
        private const string FINANCIAL_TITLE = "//*[@id='main']/div[1]/div[4]/section/div/div[1]/div/div[3]/ul/li[1]/a/div[2]/ul/li[2]";

        [FindsBy(How = How.XPath, Using = SELECT_FIELD)]
        private IWebElement selectField;
        [FindsBy(How = How.XPath, Using = SELECT_ITEM)]
        private IWebElement selectItem;
        [FindsBy(How = How.XPath, Using = FINANCIAL_TITLE)]
        private IWebElement financialTitle;

        public string filtrator()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(selectField));
            selectField.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(selectItem));
            selectItem.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(financialTitle));
            string res = financialTitle.GetAttribute("innerHTML");
            return res;
        }
    }
}
