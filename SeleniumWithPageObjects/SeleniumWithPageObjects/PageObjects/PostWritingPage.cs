using System.Threading;
using OpenQA.Selenium;

namespace SeleniumWithPageObjects.PageObjects
{
    public class PostWritingPage
    {
        public IWebDriver _driver;
        
        public PostWritingPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement PostHeaderInput =>
            _driver.FindElement(By.XPath("//div[@class='ui-limited-input ui-limited-input--big']/textarea"));

        public IWebElement SavePostButton => _driver.FindElement(By.XPath("//div[@title='Сохранить']"));

        public IWebElement PublishPostButton => _driver.FindElement(By.XPath("//div[@class='ui-button ui-button--5']"));

        public IWebElement SubmitPostPublishButton =>
            _driver.FindElement(By.XPath("//div[@air-click='modal_window_apply']"));

        public PostWritingPage SelectRubric()
        {
            _driver.FindElement(By.XPath("//div[@class='bubble__container']/div[3]/div")).Click();
            Thread.Sleep(3000);
            return this;
        }

        public PostWritingPage SetPostHeaderText(string text)
        {
            PostHeaderInput.SendKeys(text);
            Thread.Sleep(1000);
            return this;
        }

        public PostWritingPage SavePost()
        {
            SavePostButton.Click();
            Thread.Sleep(10000);
            return this;
        }

        public PostPage PublishPost()
        {
            PublishPostButton.Click();
            Thread.Sleep(3000);
            
            SubmitPostPublishButton.Click();
            Thread.Sleep(10000);
            return new PostPage(_driver);
        }
    }
}