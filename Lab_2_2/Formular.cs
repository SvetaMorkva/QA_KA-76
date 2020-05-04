using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Lab_2
{
    public class Formular
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public Formular(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Формуляр')]")]
        private IWebElement ToFormular;

        [FindsBy(How = How.ClassName, Using = "title")]
        [FindsBy(How = How.ClassName, Using = "bar")]
        private IWebElement FormularTitle;

        [FindsBy(How = How.CssSelector, Using = ".indent1[cellspacing='2'] .td1:nth-of-type(2) a[href*='history-hold']")]
        private IWebElement HoldRequests;

        [FindsBy(How = How.Id, Using = "centered")]
        private IList<IWebElement> HistoryItems;

        [FindsBy(How = How.CssSelector, Using = ".indent1[cellspacing='2'] .td1:nth-of-type(2) a[href*='history-loan']")]
        private IWebElement OrdersHistory;


        public string GetFormularTitle() => FormularTitle.Text;

        public string GetHoldReqestsMainPage() => HoldRequests.Text;

        public string GetOrdersHistoryMainPage() => OrdersHistory.Text;

        public Formular GoToHoldRequests()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(HoldRequests));
            HoldRequests.Click();

            return this;
        }

        public Formular GoToOrdersHistory()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(OrdersHistory));
            OrdersHistory.Click();

            return this;
        }

        public int GetHistoryItemsCount() => HistoryItems.Count;

        public Formular GoToFomularPage()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(ToFormular));
            ToFormular.Click();

            return this;
        }
    }
}
