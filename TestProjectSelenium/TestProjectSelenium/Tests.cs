using System;
using System.Collections.ObjectModel;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace TestProjectSelenium
{
    [TestFixture]
    public class Tests
    {
         private ChromeDriver _driver;
         private string _userPageUrl = "https://dtf.ru/u/239963";
         private string _userPageRelativeUrl = "/u/239963";
        
         [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://dtf.ru");
            _driver.FindElementByXPath("//div[@class='main_menu__auth l-ml-10 lm-ml-10 l-mr-40 lm-mr-0']").Click();
            
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.FindElementByXPath("(//div[@class='social-auth__label'])[3]/..").Click();
            
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            _driver.FindElementByXPath("(//input[@placeholder='Почта'])[1]")
                .SendKeys("hesoyam7ripazha@gmail.com");
            _driver.FindElementByXPath("(//input[@placeholder='Пароль'])[1]")
                .SendKeys("somestrongpassword");
            _driver.FindElementByXPath("(//div[@class='ui_form__fieldset'])[3]/input").Click();
        }
        
        [Test]
        public void TestsLogin()
        {
            try
            {
                _driver.FindElementByXPath($"//a[@href='{_userPageRelativeUrl}']");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void AddRubricSubscription()
        {
            _driver.Navigate().GoToUrl("https://dtf.ru/subs");
            var subscribedRubricLink = _driver
                .FindElementByXPath("//div[@class='subsites_catalog__recommended']/div/div/a").GetAttribute("href");
            _driver.FindElementByXPath("//div[@class='subsites_catalog__recommended']/div/div/div[2]").Click();
            
            _driver.Navigate().GoToUrl(subscribedRubricLink);
            var actualString = _driver.
                FindElementByXPath("//div[@class='subsite_subscribe_button__main']/div[2]/span").Text;

            Assert.AreEqual( "Подписан", actualString, $"Expected 'Подписан' but got {actualString}");
        }

        [Test]
        public void AddDraft()
        {
            string expectedText = "Some random text";
            
            _driver.FindElementByXPath("//div[@air-module='module.creationButton']").Click();
            _driver.FindElementByXPath("//div[@class='ui-limited-input ui-limited-input--big']/textarea")
                .SendKeys(expectedText);
            
            _driver.FindElementByXPath("//div[@title='Сохранить']").Click();
            _driver.Navigate().GoToUrl($"{_userPageUrl}/drafts");

            string actualText = _driver.FindElementByXPath("//div[@class='feed__chunk']/div//h2").Text;
            
            Assert.IsTrue(actualText.Contains(expectedText));
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}