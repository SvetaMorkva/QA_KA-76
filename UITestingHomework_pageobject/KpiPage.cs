using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;

namespace UITestingHomework_pageobject
{ 
    public class KpiPage
    {
        protected IWebDriver _driver;
        
        /* ========================
         * the usage of incapsulation
         */
        public void SetWebDriver(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebDriver getWebDriver()
        {
            return _driver;
        }
        
        public KpiPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "a[lang='en']")]
        public IWebElement languageButton;

        [FindsBy(How = How.CssSelector, Using = "div[class='site-branding__slogan']")]
        public IWebElement newEnglishName;

        [FindsBy(How = How.CssSelector, Using = "input[name='keys']")]
        public IWebElement searchForm;
        
        [FindsBy(How = How.CssSelector, Using = "h1[class='title page-title']")]
        public IWebElement searchResult;
        
        [FindsBy(How = How.CssSelector, Using = "a[title='Головна']")]
        public IWebElement logoLink;


        public bool NameSuccesfullyChanged => newEnglishName.GetAttribute("innerHTML").ToLower().Contains("national");

        public string AfterClickLink => _driver.Url;
        public bool SearchCompleted(string TextToType)
        {
            return searchResult.GetAttribute("innerHTML").ToLower().Contains(TextToType);
        }
        
        /*  ===============================================
         * the usage of static polymorphism
         */

        public bool SearchCompleted()
        {
            string TextToType = "testtext";
            return searchResult.GetAttribute("innetyHTML").ToLower().Contains(TextToType);
        }
        
        
        public KpiPage ClickButton()
        {
            languageButton.Click();
            return this;
        }

        public KpiPage ClickButton(IWebElement buttonToClick)
        {
            buttonToClick.Click();
            return this;
        }
        
        public KpiPage FillSearchField(string TextToType)
        {
            searchForm.SendKeys(TextToType);
            searchForm.Submit();
            return this;
        }

        public KpiPage ClickLogo()
        {
            logoLink.Click();
            return this;
        }
        
        public KpiPage ClickEnglishButton()
        {
            languageButton.Click();
            return this;
        }

    }
}