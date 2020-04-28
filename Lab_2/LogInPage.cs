using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_2
{
    public class LogInPage
    {
        private IWebDriver _driver;

        public LogInPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "btnGoogle")]
        private IWebElement ButtonGoogle;

        [FindsBy(How = How.CssSelector, Using = "input[type=email]")]
        private IWebElement EmailField;

        [FindsBy(How = How.Id, Using = "passwordNext")]
        [FindsBy(How = How.CssSelector, Using = "div[role=button]")]
        private IWebElement SubmitButton;

        [FindsBy(How = How.CssSelector, Using = "input[type='password']")]
        private IWebElement PasswordField;

        public LogInPage SelectGoogleAuth()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(ButtonGoogle));
            ButtonGoogle.Click();
            return this;
        }

        public LogInPage TypeAndSubmitEmail(string Email)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(EmailField));
            EmailField.SendKeys(Email);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(SubmitButton));
            SubmitButton.Click();
            Thread.Sleep(2000);
            return this;
        }

        public LogInPage TypeAndSubmitPassword(string Password)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(PasswordField));
            EmailField.SendKeys(Password);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(SubmitButton));
            SubmitButton.Click();
            Thread.Sleep(2000);
            return this;
        }
    }
}
