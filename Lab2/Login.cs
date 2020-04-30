using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Lab2
{
    [TestFixture]
    public class Login
    {
        string url = "https://app.knackbusiness.com/login";        
        string myEmail = "l.khylenko@gmail.com";
        string myPassword = "!Q@W#E";
        ChromeDriver driver;
        WebDriverWait wait;
        IWebElement emailLineEdit;
        IWebElement nextButton;
        IWebElement passwordLineEdit;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            emailLineEdit = driver.FindElement(By.Id("email"));
            passwordLineEdit = driver.FindElement(By.Id("password"));
            nextButton = driver.FindElement(By.CssSelector(".btn"));

            emailLineEdit.Clear();
            passwordLineEdit.Clear();
        }

        [Test]
        public void Login_WithoutFilling_ShouldMadeError()
        {
            nextButton.Click();
            var errorMsg = driver.FindElement(By.CssSelector(".toast"));      

            Assert.IsTrue(errorMsg.Displayed);
        }

        [Test]
        public void Login_ShouldEnterInAccount()
        {
            emailLineEdit.SendKeys(myEmail);
            passwordLineEdit.SendKeys(myPassword);

            nextButton.Click();

            wait.Until(d => driver.FindElement(By.ClassName("noMarginBottom")));
            var confirm = driver.FindElement(By.ClassName("noMarginBottom"));

            Assert.IsTrue(confirm.Displayed);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }

    }
}
