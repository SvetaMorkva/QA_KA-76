using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace lab2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://app.hubspot.com/login");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            By usernamePath = By.XPath("//*[@id='username']");
            By passwordPath = By.XPath("//*[@id='password']");
            By loginBtnPath = By.XPath("//*[@id='loginBtn']");

            // login to HubSpot
            driver.FindElement(usernamePath).SendKeys("olha.pashnieva@gmail.com");
            driver.FindElement(passwordPath).SendKeys("QALab123456");
            driver.FindElement(loginBtnPath).Submit();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}