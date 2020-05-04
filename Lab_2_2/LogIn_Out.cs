using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Lab_2
{
    public class LogIn_Out
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public LogIn_Out(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "input[name='bor_id']")]
        private IWebElement TextBoxUsername;

        [FindsBy(How = How.CssSelector, Using = "input[name='bor_verification']")]
        private IWebElement TextBoxPassword;

        [FindsBy(How = How.CssSelector, Using = "input[alt='Ввійти']")]
        private IWebElement ButtonSubmitCredentials;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Вихід')]")]
        private IWebElement ButtonLogOut;

        [FindsBy(How = How.CssSelector, Using = "a img[alt='Завершити']")]
        private IWebElement ButtonEndSession;


        public LogIn_Out EnterCredentials(string username, string password)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(TextBoxUsername));
            TextBoxUsername.Click();
            TextBoxUsername.SendKeys(username);
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementToBeClickable(TextBoxPassword));
            TextBoxPassword.Click();
            TextBoxPassword.SendKeys(password);

            return this;
        }

        public LogIn_Out SubmitCredentials()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(ButtonSubmitCredentials));
            ButtonSubmitCredentials.Click();

            return this;
        }

        public LogIn_Out LogOut_EndSession()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(ButtonLogOut));
            ButtonLogOut.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(ButtonEndSession));
            ButtonEndSession.Click();

            return this;
        }
    }
}
