using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Lab2
{   [TestFixture]
    class UpdatePassword
    {
        string url = "https://app.knackbusiness.com/login";
        string myPassword = "!Q@W#E";
        string newPassword = "1234";
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
        public void ShortPassword_ShouldWarn()
        {
            driver.FindElement(By.Id("email")).SendKeys("l.khylenko@gmail.com");
            driver.FindElement(By.Id("password")).SendKeys("!Q@W#E");
            driver.FindElement(By.CssSelector(".btn")).Click();

            wait.Until(d => driver.FindElement(By.ClassName("profileImage")));
            driver.FindElement(By.ClassName("profileImage")).Click();

            wait.Until(d => driver.FindElement(By.XPath("//*[@id='accountsList']/div/a")));
            IWebElement elem = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='accountsList']/div/a")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].removeAttribute('margin-left')", elem);
            driver.FindElement(By.XPath("//*[@id='accountsList']/div/a")).Click();
            


            wait.Until(d => driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div[5]/div[2]/a")));
            driver.FindElement(By.XPath("/html/body/div[12]/div/div[5]/a[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div[5]/div[2]/a")).Click();


            wait.Until(d => driver.FindElement(By.Id("userUpdatePasswordCurrent")));
            driver.FindElement(By.Id("userUpdatePasswordCurrent")).SendKeys(myPassword);
            driver.FindElement(By.Id("userPasswordNew")).SendKeys(newPassword);
            driver.FindElement(By.Id("userPasswordConfirm")).SendKeys(newPassword);

            driver.FindElement(By.CssSelector(".btn.btn-large.pink.accent-4")).Click();

            wait.Until(d => driver.FindElement(By.CssSelector(".toast")));
            var passMsg = driver.FindElement(By.CssSelector(".toast"));

            Assert.IsTrue(passMsg.Displayed);


        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
