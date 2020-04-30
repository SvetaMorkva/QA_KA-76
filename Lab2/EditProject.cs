using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Lab2
{
    [TestFixture]
    class EditProject
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
        public void EditProject_ShouldUpdate()
        {
            driver.FindElement(By.Id("email")).SendKeys("l.khylenko@gmail.com");
            driver.FindElement(By.Id("password")).SendKeys("!Q@W#E");
            driver.FindElement(By.CssSelector(".btn")).Click();
            wait.Until(d => driver.FindElement(By.XPath("//img[@src='https://app.knackbusiness.com/assets/images/nav_projects.png']")));

            driver.FindElement(By.XPath("//img[@src='https://app.knackbusiness.com/assets/images/nav_projects.png']")).Click();
            wait.Until(d => driver.FindElement(By.XPath("//*[@id='slide-out']/ul/li[5]/div/a[3]")));
            driver.FindElement(By.XPath("//*[@id='slide-out']/ul/li[5]/div/a[3]")).Click();

			//wait.Until(d => driver.FindElement(By.LinkText("Edit")));
            //wait.Until(d => driver.FindElement(By.XPath("/html/body/div[4]/div/div[2]/div[2]/div/table/tbody/tr[1]/td[7]/a[2]")));
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("/html/body/div[4]/div/div[2]/div[2]/div/table/tbody/tr[1]/td[7]/a[2]")).Click();

            wait.Until(d => driver.FindElement(By.XPath("//*[@id='modal-content']/div[3]/div/div[1]/span[3]/button[2]")));
            driver.FindElement(By.XPath("//*[@id='modal-content']/div[3]/div/div[1]/span[3]/button[2]")).Click();

            wait.Until(d => driver.FindElement(By.XPath("//*[@id='modal-content']/div[4]/div[2]/div")));
            driver.FindElement(By.XPath("//*[@id='modal-content']/div[4]/div[2]/div")).Click();

            wait.Until(d => driver.FindElement(By.CssSelector(".toast")));
            var clientMsg = driver.FindElement(By.CssSelector(".toast"));

            Assert.IsTrue(clientMsg.Displayed);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
