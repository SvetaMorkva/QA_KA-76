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

            IWebElement cookieclose = driver.FindElement(By.ClassName("cookieClose"), 5);

            IWebElement nameField = driver.FindElement(By.Id("namefield"), 5);
            IWebElement emailField = driver.FindElement(By.Id("email"), 5);
            IWebElement passField = driver.FindElement(By.Name("password"), 5);
            IWebElement phoneField = driver.FindElement(By.Id("mobile"), 5);
            IWebElement termsCheckbox = driver.FindElement(By.Id("signup-termservice"), 5);
            IWebElement getStartedButton = driver.FindElement(By.Id("signupbtn"), 5);

            //act 
            cookieclose.Click();
            nameField.SendKeys(name);
            emailField.SendKeys(email);
            passField.SendKeys(pass);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("signup-termservice")));
            phoneField.SendKeys(phone);

            System.Threading.Thread.Sleep(2000);

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
