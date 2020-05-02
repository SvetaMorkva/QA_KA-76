using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Lab2
{
    public class MainPage
    {
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".left a")]
        private IWebElement LeftPart;

        [FindsBy(How = How.CssSelector, Using = ".cities-popup li:nth-of-type(1)")]
        private IWebElement CityKyiv;

        [FindsBy(How = How.CssSelector, Using = ".right a")]
        private IWebElement RightPart;


        public MainPage GoToLeftPart()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(LeftPart));
            LeftPart.Click();
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementToBeClickable(CityKyiv));
            CityKyiv.Click();
            return this;
        }

        public MainPage GoToRightPart()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(RightPart));
            RightPart.Click();
            return this;
        }
    }
}
