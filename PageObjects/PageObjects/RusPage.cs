using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace PageObjects
{
    public class RusPage
    {
        private IWebDriver driver;

        public RusPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private const string RUSSIAN_WORD = ".top-navigation__item:nth-child(1) .top-navigation__item-link";

        [FindsBy(How = How.CssSelector, Using = RUSSIAN_WORD)]
        private IWebElement russianWordElement;

        public string getRussianWord()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(russianWordElement));
            string res = russianWordElement.GetAttribute("innerHTML");
            return res;
        }

    }
}
