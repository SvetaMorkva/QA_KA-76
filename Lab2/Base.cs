using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace QA_Lab2
{
    public class Base
    {
        private string url = "https://accounts.zoho.eu/signin?servicename=ZohoHome&signupurl=https://www.zoho.com/signup.html";
        public string myEmail = "sveta.morkva28@gmail.com";
        private string myPassword = "ssss_1111";
        public ChromeDriver driver;
        public WebDriverWait wait;
        public IWebElement nextButton;
        public IWebElement loginLineEdit;
        public IWebElement passwordLineEdit;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            loginLineEdit = driver.FindElement(By.Id("login_id"));
            nextButton = driver.FindElement(By.Id("nextbtn"));

            loginLineEdit.Clear();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

        public void FillDataForLogin()
        {
            loginLineEdit.SendKeys(myEmail);
            nextButton.Click();

            wait.Until(d => driver.FindElement(By.Id("password")));

            passwordLineEdit = driver.FindElement(By.Id("password"));
            System.Threading.Thread.Sleep(3000);
            wait.Until(d => passwordLineEdit.Displayed && passwordLineEdit.Enabled);
            passwordLineEdit.SendKeys(myPassword);
        }
    }
}
