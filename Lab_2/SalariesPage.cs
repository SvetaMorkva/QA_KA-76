using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab_2
{
    public class SalariesPage
    {
        private IWebDriver _driver;

        public SalariesPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//select/option[text()='December 2019']")]
        private IWebElement Period;

        [FindsBy(How = How.XPath, Using = "//select/option[text()='Kyiv']")]
        private IWebElement City;

        [FindsBy(How = How.CssSelector, Using = ".salarydec-slider a:nth-of-type(2)")]
        private IWebElement Slider;

        [FindsBy(How = How.CssSelector, Using = ".salarydec-results-min .num")]
        private IWebElement MinField;

        [FindsBy(How = How.CssSelector, Using = ".salarydec-results-median .num")]
        private IWebElement MedianField;

        [FindsBy(How = How.CssSelector, Using = ".salarydec-results-max .num")]
        private IWebElement MaxField;

        public SalariesPage SelectPeriod()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(Period));
            Period.Click();
            return this;
        }

        public SalariesPage SelectCity()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(City));
            City.Click();
            return this;
        }

        public SalariesPage SelectJob(string JobName)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath($"//select//option[text()='{JobName}']"))));
            _driver.FindElement(By.XPath($"//select//option[text()='{JobName}']")).Click();
            return this;
        }

        public SalariesPage SelectPositionIfExist(string PositionName)
        {
            var elementList = new List<IWebElement>();
            elementList.AddRange(_driver.FindElements(By.XPath($"//select//option[text()='{PositionName}']")));
            if (elementList.Count > 0)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath($"//select//option[text()='{PositionName}']"))));
                elementList[0].Click();
            }
            return this;
        }

        public SalariesPage MoveSlider()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(Slider));
            Actions action = new Actions(_driver);
            action.Click(Slider).Build().Perform();
            Thread.Sleep(300);
            for (int i = 0; i < 8; i++)
                action.SendKeys(Keys.ArrowLeft).Build();

            action.Perform();
            Slider.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            return this;
        }

        public string GetMinField() => MinField.Text;

        public string GetMedianField() => MedianField.Text;

        public string GetMaxField() => MaxField.Text;
    }
}
