using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;

namespace UITestingHomework_pageobject
{ 
    public class LibraryPage
    {
        private IWebDriver _driver;

        public LibraryPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "li[class = rss] a")]
        public IWebElement linkToClick;

        [FindsBy(How = How.CssSelector, Using = "input[name = 'your-name']")]
        public IWebElement nameForm;
        
        [FindsBy(How = How.CssSelector, Using = "input[name = 'prizv']")]
        public IWebElement surnameForm;
        
        [FindsBy(How = How.CssSelector, Using = "input[name = 'your-email']")]
        public IWebElement emailForm;

        [FindsBy(How = How.CssSelector, Using = "input[name = 'text-867']")]
        public IWebElement positionForm;
        
        [FindsBy(How = How.CssSelector, Using = "input[name = 'checkbox-34[]']")]
        public IWebElement checkbox;
        
        [FindsBy(How = How.CssSelector, Using = "input[type='submit']")]
        public IWebElement submitButton;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div[2]/centerb/article/div/div/form/div[2]")]
        public IWebElement errorAttribute;

        public bool actualErrorAttribute => errorAttribute.GetAttribute("role") == null;

        public LibraryPage ClickLinkToClick()
        {
            linkToClick.Click();
            return this;
        }

        public LibraryPage ClickSubmitButton()
        {
            submitButton.Click();
            return this;
        }

        public LibraryPage clickCheckbox()
        {
            checkbox.Click();
            return this;
        }

        public LibraryPage FillTheFields(string name, string surname, string email, string position)
        {
            nameForm.SendKeys(name);
            surnameForm.SendKeys(surname);
            emailForm.SendKeys(email);
            positionForm.SendKeys(position);
            return this;
        }

    }
}