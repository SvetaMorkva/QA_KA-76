using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWithPageObjects.PageObjects;

namespace SeleniumWithPageObjects
{
    [TestFixture]
    public class Tests
    {
         private ChromeDriver _driver;
         private string _userPageUrl = "https://dtf.ru/u/239963";
         private string _userPageRelativeUrl = "/u/239963";

         private string _email = "hesoyam7ripazha@gmail.com";
         private string _password = "somestrongpassword";

         public IWebElement FluentWait(By target)
         {
             var option = new ChromeOptions();
             option.AddArgument("--headless");
             
             WebDriverWait webdriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
             return webdriverWait.Until(x=>x.FindElement(target));
         }
         
         [SetUp]
        public void SetUp()
        {
            
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://dtf.ru");
            
            var indexPage = new IndexPage(_driver);

            indexPage
                .EnterLoginForm()
                .SetEmail(_email)
                .SetPassword(_password)
                .SubmitLoginForm();
            
            Thread.Sleep(20000);
        }
        
        [Test]
        public void TestLogin()
        {
            var indexPage = new IndexPage(_driver);
            Assert.IsTrue(indexPage.IsUserLoggedIn(_userPageRelativeUrl));
        }

        [Test]
        public void AddRubricSubscription()
        {
            _driver.Navigate().GoToUrl("https://dtf.ru/subs");
            var subsPage = new SubsPage(_driver);

            string rubricLink = subsPage.GetUnsubscribedRubricLink();
            subsPage.SubscribeRubric();
            
            _driver.Navigate().GoToUrl(rubricLink);
            
            var rubricPage = new RubricPage(_driver);
            
            Assert.IsTrue(rubricPage.IsUserSubscribed());
        }

        [Test]
        public void AddDraft()
        {
            string expectedText = "Some random text";
            var indexPage = new IndexPage(_driver);
            var postWritingPage = indexPage.CreatePost();

            postWritingPage
                .SelectRubric()
                .SetPostHeaderText(expectedText)
                .SavePost();
            
            _driver.Navigate().GoToUrl($"{_userPageUrl}/drafts");
            Thread.Sleep(3000);
            
            string actualText = new DraftsPage(_driver).GetLastDraftHeader();
            
            Assert.IsTrue(actualText.Contains(expectedText));
        }

        [Test]
        // Site have restriction of post publishes, so test may fail
        public void PublishDraft()
        {
            string expectedText = "Draft I want to publish";

            // Create draft
            var indexPage = new IndexPage(_driver);
            var postWritingPage = indexPage.CreatePost();

            var postPage = postWritingPage
                .SelectRubric()
                .SetPostHeaderText(expectedText)
                .PublishPost();

            string actualText = postPage.GetPostHeaderText();
            Assert.IsTrue(actualText == expectedText);
        }

        [Test]
        public void AddComment()
        {
            string expectedText = "some comment content";
            
            _driver.Navigate().GoToUrl("https://dtf.ru/u/239963-selenium-lab/130875-article-with-i-will-comment");
            var postPage = new PostPage(_driver);
            
            string actualText = postPage
                .SetCommentContent(expectedText)
                .SubmitComment().
                GetLastCommentContent();

            Assert.AreEqual(expectedText, actualText);
        }

        [Test]
        public void AddBookMark()
        {
            string postLink = "https://dtf.ru/u/239963"; 
            string postRelativeLink = "/u/239963"; 
            
            _driver.Navigate().GoToUrl(postLink);
            
            var postPage = new PostPage(_driver);
            
            _driver.Navigate().GoToUrl($"{_userPageUrl}/favorites/entries");

            Assert.IsTrue(new BookmarksPage(_driver).IsPostInBookmarks(postRelativeLink));
        }

        [Test]
        public void Search()
        {
            string searchValue = "d435a6cdd786300dff204ee7c2ef942d3e9034e2";
            
            var indexPage = new IndexPage(_driver);
            var searchResultPage = indexPage.Search(searchValue);
            string actualPostHeader = searchResultPage.GetFirstResultHeaderText();
            
            Assert.AreEqual(searchValue, actualPostHeader);
        }

        [Test]
        public void AddSavedMessage()
        {
            string messageContent = "Some message";
            
            _driver.Navigate().GoToUrl(_userPageUrl);
            
            var userPage = new UserPage(_driver);

            string actualMessage = userPage.
                StartChat().
                SendMessage(messageContent)
                .GetLastMessageContent();
            
            Assert.AreEqual(messageContent, actualMessage);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}