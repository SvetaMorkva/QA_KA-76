using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace QA_Lab2
{
    [TestFixture]
    public class Login
    {
        string url = "https://accounts.zoho.eu/signin?servicename=ZohoHome&signupurl=https://www.zoho.com/signup.html";
        string myEmail = "sveta.morkva28@gmail.com";
        string myPassword = "ssss_1111";
        ChromeDriver driver;
        WebDriverWait wait;
        IWebElement loginLineEdit;
        IWebElement nextButton;
        IWebElement passwordLineEdit;

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


        [Test]
        public void Login_WithoutFilling_ShouldMadeErrorVisible()
        {
            nextButton.Click();

            var errorMsg = driver.FindElement(By.CssSelector(".fielderror.errorlabel"));
            var errorLineEdit = driver.FindElement(By.CssSelector(".textbox.errorborder"));

            Assert.IsTrue(errorMsg.Displayed && errorLineEdit.Displayed);
        }

        [Test]
        public void Login_PasswordEyeButton_ShouldMadePasswordVisible()
        {
            FillDataForLogin();

            driver.FindElement(By.CssSelector("[class$='show_hide_password']")).Click();

            wait.Until(d => driver.FindElements(By.CssSelector("[class$='show_hide_password']")).Count == 0);
            var iconShow = driver.FindElement(By.CssSelector(".icon-show"));

            Assert.IsTrue(iconShow.Displayed && passwordLineEdit.GetAttribute("type") == "text");
        }

        [Test]
        public void Login_ValidEmailAndPassword_ShouldEnterInAccount()
        {
            FillDataForLogin();

            nextButton.Click();

            wait.Until(d => driver.FindElement(By.CssSelector("[class*='ztb-p']")));
            var userEmail = driver.FindElement(By.Id("ztb-user-id")).GetAttribute("ztooltip");

            Assert.AreEqual(myEmail, userEmail);
        }


        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }

        private void FillDataForLogin()
        {
            loginLineEdit.SendKeys(myEmail);
            nextButton.Click();

            wait.Until(d => driver.FindElement(By.Id("password")));

            passwordLineEdit = driver.FindElement(By.Id("password"));
            passwordLineEdit.SendKeys(myPassword);
        }
    }
}
