using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
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

            IWebElement nameField = driver.FindElementById("namefield");
            IWebElement emailField = driver.FindElementById("email");
            IWebElement passField = driver.FindElementByName("password");
            IWebElement phoneField = driver.FindElementById("mobile");
            IWebElement termsCheckbox = driver.FindElementById("signup-termservice");
            IWebElement getStartedButton = driver.FindElementById("signupbtn");

            //act
            nameField.SendKeys(name);
            emailField.SendKeys(email);
            passField.SendKeys(pass);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("signup-termservice")));
            phoneField.SendKeys(phone);
            termsCheckbox.Click();
            getStartedButton.Click();

            //assert
            System.Threading.Thread.Sleep(10000); // wait for Zoho to create account
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

            var welcomePopup = driver.FindElement(By.Id("cobdiv"), 20);
            Assert.IsTrue(welcomePopup.Displayed && welcomePopup.Enabled, "Pop up is not visible");
            var accountName = driver.FindElement(By.Id("headerUName"), 20);
            Assert.IsTrue(accountName.Text == name, "Wrong account name");
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
