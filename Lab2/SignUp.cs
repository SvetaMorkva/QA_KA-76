using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace QA_Lab2
{
    [TestFixture]
    public class SignUp
    {
        private string url = "https://www.zoho.com/signup.html";
        private ChromeDriver driver;
        private WebDriverWait wait;
        private IWebElement signUpButton;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            signUpButton = driver.FindElement(By.CssSelector(".signupbtn"));
        }
        

        [Test]
        public void SignUp_WithoutFilling_ShouldMadeErrorVisible()
        {
            System.Threading.Thread.Sleep(7000);
            signUpButton.Click();

            var errorMsg = driver.FindElements(By.CssSelector(".testdrivetext .field-msg"));

            bool errorsDisplayed = true;
            foreach (var e in errorMsg)
            {
                if (!e.Displayed)
                {
                    errorsDisplayed = false;
                    break;
                }
            }

            Assert.AreEqual(3, errorMsg.Count);
            Assert.IsTrue(errorsDisplayed);
        }

        [Test]
        public void SignUp_ChangeCountry_ShouldMadeCountryVisible()
        {
            var changeCountry = driver.FindElement(By.Id("zip-countryname-change"));
            wait.Until(d => changeCountry.Enabled);

            changeCountry.Click();

            Assert.IsTrue(driver.FindElement(By.Id("country")).Displayed);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }
    }
}
