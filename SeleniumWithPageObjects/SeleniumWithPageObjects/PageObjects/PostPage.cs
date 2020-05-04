using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumWithPageObjects.PageObjects
{
    public class PostPage
    {
        private IWebDriver _driver;

        public PostPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement PostHeader => _driver.FindElement(By.XPath("//h1"));

        public IWebElement CommentContentInput => _driver.FindElement(
            By.XPath("//div[@class='comments__footer layout--a l-clear']/div/div//p[@contenteditable='true']"));

        public IWebElement CommentSubmitButton =>
            _driver.FindElement(By.XPath("//div[@class='thesis__submit ui-button ui-button--1']"));

        public IWebElement BookmarkButton => _driver.FindElement(By.XPath("//div[@class='favorite_marker__action']"));

        public string GetPostHeaderText()
        {
            return PostHeader.Text;
        }

        public PostPage SetCommentContent(string content)
        {
            if (content == null) return this;
            CommentContentInput.SendKeys(content);
            Thread.Sleep(1000);
            return this;
        }

        public PostPage SubmitComment()
        {
            CommentSubmitButton.Click();
            Thread.Sleep(20000);
            return this;
        }

        public string GetLastCommentContent()
        {
            return _driver
                .FindElement(By.XPath(
                    "//div[@class='comments__content layout--a l-mb-30']/div[last()]//div[@class='comments__item__text']/p"))
                .Text;
        }

        public bool IsPostInBookmarks()
        {
            return _driver.FindElement(By.XPath("//div[@air-module='module.favorite']")).GetAttribute("class")
                .Contains("favorite_marker--non_zero");
        }

        public PostPage AddPostToBookmarks()
        {
            if (IsPostInBookmarks()) return this;
            BookmarkButton.Click();
            Thread.Sleep(5000);
            return this;
        }
    }
}