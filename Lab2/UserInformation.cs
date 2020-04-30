using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Lab2
{
    class UserInformation
    {
        string url = "https://app.knackbusiness.com/login";
        ChromeDriver driver;
        WebDriverWait wait;   
        string myName = "vkhlnk";

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        [Test]
        public void UserInformation_ShouldBeEqual()
        {
            driver.FindElement(By.Id("email")).SendKeys("l.khylenko@gmail.com");
            driver.FindElement(By.Id("password")).SendKeys("!Q@W#E");
            driver.FindElement(By.CssSelector(".btn")).Click();
            wait.Until(d => driver.FindElement(By.XPath("//img[@src='https://app.knackbusiness.com/assets/images/nav_projects.png']")));

            driver.FindElement(By.XPath("//img[@src='https://app.knackbusiness.com/assets/images/nav_projects.png']")).Click();
            wait.Until(d => driver.FindElement(By.XPath("//*[@id='slide-out']/ul/li[7]/a")));
            driver.FindElement(By.XPath("//*[@id='slide-out']/ul/li[7]/a")).Click();

            Thread.Sleep(3000);
            wait.Until(d => driver.FindElement(By.XPath("//*[@id='slide-out']/ul/li[7]/div/a[2]")));
            driver.FindElement(By.XPath("//*[@id='slide-out']/ul/li[7]/div/a[2]")).Click();
            

            wait.Until(d => driver.FindElement(By.XPath("//*[@id='modal-content']/div[2]/div/h5")));
            var userName = driver.FindElement(By.XPath("//*[@id='modal-content']/div[2]/div/h5")).Text;

            Assert.AreEqual(myName, userName);
        }

    }
}
