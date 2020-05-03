using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using Lab2.Pages;

namespace Lab2
{
    [TestFixture]
    public class Test_SignUp
    {
        private string url = "https://www.zoho.com/crm/";
        private ChromeDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }


        [Test]
        public void SignUp_FillPersonalData_ShouldCreateAccount()
        {
            // arrange
            var date = DateTime.Now;
            string mock = date.Hour.ToString() + date.Minute.ToString() + date.Second.ToString();

            var name = "Name" + mock;
            var email = "username" + mock + "@gmail.com";
            var pass = "strongPassword1234!!";
            var phone = "0504319992";

            var signUpPage = new SignUpPage(driver, wait);

            //act
            signUpPage.GoToUrl();
            signUpPage.SkipCookies();
            signUpPage.FillDataAndSignUp(name, email, pass, phone);

            //assert
            Assert.IsTrue(signUpPage.CheckSignUpSucces(name), "Sign up failed");
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }

    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
}
