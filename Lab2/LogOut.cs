using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Lab2
{
    [TestFixture]
    class LogOut
    {
        string url = "https://app.knackbusiness.com/login";
        ChromeDriver driver;
        WebDriverWait wait;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        [Test]
        public void SLogOut_ShouldLogOut()
        {
            driver.FindElement(By.Id("email")).SendKeys("l.khylenko@gmail.com");
            driver.FindElement(By.Id("password")).SendKeys("!Q@W#E");
            driver.FindElement(By.CssSelector(".btn")).Click();

            wait.Until(d => driver.FindElement(By.ClassName("profileImage")));
            driver.FindElement(By.ClassName("profileImage")).Click();

            wait.Until(d => driver.FindElement(By.XPath("//*[@id='logoutLink']/div")));
            driver.FindElement(By.XPath("//*[@id='logoutLink']/div")).Click();

            wait.Until(d => driver.FindElement(By.ClassName("white-text")));
            var logMsg = driver.FindElement(By.ClassName("white-text"));

            Assert.IsTrue(logMsg.Displayed);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
