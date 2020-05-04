using lab2.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace lab2
{
    public class TemplateTests
    {
        private IWebDriver driver;
        private readonly string randomStr = Path.GetRandomFileName().Replace(".", "");
        private TemplatesPage templatesPageObj;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            templatesPageObj = new TemplatesPage(driver);
            templatesPageObj.GoToPage();
        }

        [TearDown]
        public void quitDriver()
        {
            driver.Quit();
        }

        [Test]
        public void AddFolderToTemplates()
        {
            templatesPageObj.CreateFolder(randomStr);
            templatesPageObj.ClickAdd();
            System.Threading.Thread.Sleep(1500);
            string newestFolderName = templatesPageObj.GetNewestFolderName();

            Assert.AreEqual(randomStr, newestFolderName);
        }



    }
}