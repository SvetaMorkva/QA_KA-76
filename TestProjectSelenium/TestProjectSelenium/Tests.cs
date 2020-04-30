using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestProjectSelenium
{
    [TestFixture]
    public class Tests
    {
         private ChromeDriver _driver;
         private string _userPageUrl = "https://dtf.ru/u/239963";
         private string _userPageRelativeUrl = "/u/239963";

         public IWebElement FluentWait(By target)
         {
             WebDriverWait webdriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
             return webdriverWait.Until(x=>x.FindElement(target));
         }
         
         [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://dtf.ru");
            _driver.FindElementByXPath("//div[@class='main_menu__auth l-ml-10 lm-ml-10 l-mr-40 lm-mr-0']").Click();
            
            Thread.Sleep(5000);
            _driver.FindElementByXPath("(//div[@class='social-auth__label'])[3]/..").Click();

            Thread.Sleep(3000);
            _driver.FindElementByXPath("(//input[@placeholder='Почта'])[1]")
                .SendKeys("hesoyam7ripazha@gmail.com");
            _driver.FindElementByXPath("(//input[@placeholder='Пароль'])[1]")
                .SendKeys("somestrongpassword");
            _driver.FindElementByXPath("(//div[@class='ui_form__fieldset'])[3]/input").Click();
            
            // Wait while we logged in
            Thread.Sleep(30000);
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
            Thread.Sleep(3000);
            var subscribedRubricLink = _driver
                .FindElementByXPath("//div[@class='subsites_catalog__recommended']/div/div/a").GetAttribute("href");
            Thread.Sleep(3000);
            _driver.FindElementByXPath("//div[@class='subsites_catalog__recommended']/div/div/div[2]/div").Click();
            Thread.Sleep(10000);
            
            _driver.Navigate().GoToUrl(subscribedRubricLink);
            var actualString = FluentWait(By.XPath("//div[@class='subsite_subscribe_button__main']/div[2]/span")).Text;

            Assert.AreEqual( "Подписан", actualString, $"Expected 'Подписан' but got {actualString}");
        }

        [Test]
        public void AddDraft()
        {
            string expectedText = "Some random text";
            
            // go to creation page
            _driver.FindElementByXPath("//div[@air-module='module.creationButton']/a").Click();
            Thread.Sleep(3000);
            
            // Select Rubric
            _driver.FindElementByXPath("//div[@class='bubble__container']/div[3]/div").Click();
            Thread.Sleep(3000);
            
            // set some content
            _driver.FindElementByXPath("//div[@class='ui-limited-input ui-limited-input--big']/textarea")
                .SendKeys(expectedText);
            Thread.Sleep(3000);
            
            // Save Draft
            _driver.FindElementByXPath("//div[@title='Сохранить']").Click();
            Thread.Sleep(20000);
            _driver.Navigate().GoToUrl($"{_userPageUrl}/drafts");
            Thread.Sleep(3000);
            
            string actualText = FluentWait(By.XPath("//div[@class='feed__chunk']/div//h2")).Text;
            
            Assert.IsTrue(actualText.Contains(expectedText));
        }

        [Test]
        public void PublishDraft()
        {
            string expectedText = "Draft I want to publish";

            // Create draft
            _driver.FindElementByXPath("//div[@air-module='module.creationButton']/a").Click();
            Thread.Sleep(3000);
            
            // Select rubric
            _driver.FindElementByXPath("//div[@class='bubble__container']/div[3]/div").Click();
            Thread.Sleep(3000);
            
            // Add some content, so we con save it
            _driver.FindElementByXPath("//div[@class='ui-limited-input ui-limited-input--big']/textarea")
                .SendKeys(expectedText);
            Thread.Sleep(3000);
            
            // Publish
            _driver.FindElementByXPath("//div[@class='ui-button ui-button--5']").Click();
            Thread.Sleep(3000);
            
            _driver.FindElementByXPath("//div[@air-click='modal_window_apply']").Click();
            Thread.Sleep(9000);
            // Check if article apears
            _driver.Navigate().GoToUrl(_userPageUrl);
            Thread.Sleep(6000);
            string actualText = FluentWait(By.XPath("//div[@class='feed__chunk']/div//h2")).Text;
            Assert.IsTrue(actualText.Contains(expectedText));
        }

        [Test]
        public void AddComment()
        {
            string expectedText = "some comment content";
            
            _driver.Navigate().GoToUrl("https://dtf.ru/u/239963-selenium-lab/130875-article-with-i-will-comment");
            _driver.FindElementByXPath("//div[@class='comments__footer layout--a l-clear']/div/div//p[@contenteditable='true']")
                .SendKeys(expectedText);
            Thread.Sleep(3000);
            
            _driver.FindElementByXPath("//div[@class='thesis__submit ui-button ui-button--1']").Click();
            Thread.Sleep(20000);

            string actualText = _driver.FindElementByXPath(
                    "//div[@class='comments__content layout--a l-mb-30']/div[last()]//div[@class='comments__item__text']/p")
                .Text;
            
            Assert.AreEqual(expectedText, actualText);
        }

        [Test]
        public void AddBookMark()
        {
            string articleLink = "https://dtf.ru/u/239963-selenium-lab/130875-article-with-i-will-comment"; 
            
            _driver.Navigate().GoToUrl(articleLink);
            string bookmarkCount = _driver.FindElementByXPath("//div[@class='favorite_marker__count']").Text;

            if (bookmarkCount == "1")
            {
                _driver.FindElementByXPath("//div[@class='favorite_marker__action']").Click();
                Thread.Sleep(3000);
            }
            
            _driver.FindElementByXPath("//div[@class='favorite_marker__action']").Click();
            Thread.Sleep(10000);
            
            _driver.Navigate().GoToUrl($"{_userPageUrl}/favorites/entries");

            try
            {
                string actualLink = _driver.FindElementByXPath("(//a[@class='content-feed__link'])[1]")
                    .GetAttribute("href");
                
                Assert.AreEqual(articleLink, actualLink);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Search()
        {
            string searchValue = "d435a6cdd786300dff204ee7c2ef942d3e9034e2";
            
            _driver.FindElementByXPath("//input[@placeholder='Поиск']").SendKeys(searchValue + Keys.Enter);
            Thread.Sleep(20000);

            string actualResult = _driver.FindElementByXPath("//h2[@class='content-header__title layout--a']").Text;
            
            Assert.IsTrue(actualResult.Contains(searchValue));
        }

        [Test]
        public void AddSavedMessage()
        {
            string messageContent = "Some message";
            
            _driver.Navigate().GoToUrl(_userPageUrl);
            
            _driver.FindElementByXPath("//span[@air-module='module.messengerButton']").Click();
            Thread.Sleep(5000);
            
            _driver.FindElementByXPath("//textarea[@placeholder]").SendKeys(messageContent + Keys.Enter);
            Thread.Sleep(20000);

            string actualMessage = _driver.FindElementByXPath("(//div[@class='message__content-text'])[last()]").Text;
            
            Assert.AreEqual(messageContent, actualMessage);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}