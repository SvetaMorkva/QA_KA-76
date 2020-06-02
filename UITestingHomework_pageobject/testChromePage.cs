using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;

namespace UITestingHomework_pageobject
{ 
    public class TestChromePage
    {
        private IWebDriver _driver;

        public TestChromePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "div[id='SIvCob'] a:nth-of-type(2)")]
        public IWebElement linkToClick;

        [FindsBy(How = How.CssSelector, Using = "div[class='FPdoLc tfB0Bf'] input[class='RNmpXc'")]
        public IWebElement changedInput;

        public bool LanguageSuccesfullyChanged => changedInput.GetAttribute("value").ToLower().Contains("lucky");
        
        public TestChromePage ClickLinkToClick()
        {
            linkToClick.Click();
            return this;
        }

    }
}