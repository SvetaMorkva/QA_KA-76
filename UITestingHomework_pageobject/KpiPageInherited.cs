using System;
using System.Web;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;

namespace UITestingHomework_pageobject
{
    public class KpiPageInherited : KpiPage
    {
        /**/


        public KpiPageInherited(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        /* ===================================
         * the usage of dynamic polymorphism 
         */

        public KpiPageInherited ClickButton(IWebElement buttonToClick)
        {
            Console.WriteLine("dynamic poly !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11");
            buttonToClick.Click();
            return this;
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-languagesimple']/div/div/ul/li[2]/a")]
        private IWebElement russianButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='block-sitebranding']/div/div")]
        public IWebElement title;

        public bool isRussian => title.GetAttribute("innerHTML").ToLower().Contains("национальный");

        public IWebElement getRussianButton()
        {
            return russianButton;
        }

        public void setRussianButton(IWebElement element)
        {
            russianButton = element;
        }
    }
}