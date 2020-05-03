using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;

namespace Lab2.PageObjects
{
    class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly string url = @"https://accounts.zoho.eu/signin?servicename=ZohoHome&signupurl=https://www.zoho.com/signup.html";
        public  readonly string myEmail = "sveta.morkva28@gmail.com";
        public  readonly string myPassword = "ssss_1111";

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
            driver.Manage().Window.Maximize();

            PageFactory.InitElements(browser, this);
        }


        [FindsBy(How = How.Id, Using = "login_id")]
        public IWebElement EmailLineEdit { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordLineEdit { get; set; }

        [FindsBy(How = How.Id, Using = "nextbtn")]
        public IWebElement NextButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[class$='show_hide_password']")]
        public IWebElement ShowPasswordIcon { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".icon-show")]
        public IWebElement HidePasswordIcon { get; set; }


        public bool HidePasswordIconIsVisible => HidePasswordIcon.Displayed && HidePasswordIcon.Enabled;

        // navigate
        public LoginPage OpenLoginPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }


        // act method

        public LoginPage OnNextButtonClick()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(NextButton, 1, 1).Click().Build().Perform();
            return this;
        }

        public LoginPage OnShowPasswordButtonClick()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(ShowPasswordIcon, 1, 1).Click().Build().Perform();
            return this;
        }

        public LoginPage OnHidePasswordButtonClick()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(HidePasswordIcon, 1, 1).Click().Build().Perform();
            return this;
        }


        // assert method

        public bool CheckTypeOfDataInPasswordLineEdit(string expectedType)
        {
            return expectedType == PasswordLineEdit.GetAttribute("type");
        }


        //additional mehod - for usability

        public LoginPage SendKeysEmailLineEdit()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(EmailLineEdit));

            EmailLineEdit.Click();
            EmailLineEdit.Clear();
            EmailLineEdit.SendKeys(myEmail);

            return this;
        }
        public LoginPage SendKeysPasswordLineEdit()
        {

            System.Threading.Thread.Sleep(3000);
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(PasswordLineEdit));

            PasswordLineEdit.Click();
            PasswordLineEdit.Clear();
            PasswordLineEdit.SendKeys(myPassword);

            return this;
        }

        public LoginPage WaitUntilShowPasswordButtonClickable()
        {

            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(ShowPasswordIcon));

            return this;
        }
        public LoginPage WaitUntilHidePasswordButtonClickable()
        {

            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(HidePasswordIcon));

            return this;
        }
    }
}
