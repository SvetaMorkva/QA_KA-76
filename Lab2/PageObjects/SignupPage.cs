using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace Lab2.PageObjects
{
    class SignupPage
    {
        private readonly IWebDriver driver;
        private readonly string url = @"https://www.zoho.com/signup.html";

        public SignupPage(IWebDriver browser)
        {
            driver = browser;
            driver.Manage().Window.Maximize();

            PageFactory.InitElements(browser, this);
        }


        [FindsBy(How = How.CssSelector, Using = ".signupbtn")]
        public IWebElement SignUpButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".testdrivetext .field-msg")]
        public IList<IWebElement> ErrorMsgLabel { get; set; }

        [FindsBy(How = How.Id, Using = "zip-countryname-change")]
        public IWebElement ChangeCountryButton { get; set; }

        [FindsBy(How = How.Id, Using = "country")]
        public IWebElement ChangeCountryDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "emailfield")]
        public IWebElement EmailLineEdit { get; set; }

        public bool ChangeCountryDropDownIsVisible => ChangeCountryDropDown.Displayed && ChangeCountryDropDown.Enabled;

        // navigate
        public SignupPage OpenSignUpPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }


        // act method

        public SignupPage OnSignUpButtonClick()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(SignUpButton, 1, 1).Click().Build().Perform();
            return this;
        }

        public SignupPage OnChangeCountryButtonClick()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(ChangeCountryButton, 1, 1).Click().Build().Perform();
            return this;
        }


        // assert method

        public bool CheckThatErrorMsgIsVisible()
        {
            foreach (var e in ErrorMsgLabel)
            {
                if (!e.Displayed)
                    return false;
            }
            return true;
        }


        //additional mehod - for usability

        public SignupPage WaitUntilSignUpButtonClickable()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(EmailLineEdit));

            EmailLineEdit.SendKeys("shfsg");
            EmailLineEdit.Clear();

            return this;
        }

        public SignupPage WaitUntilErrorMsgCreated()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(d => ErrorMsgLabel.Count == 3);
            return this;
        }
    }
}
