using System.Threading;
using OpenQA.Selenium;

namespace SeleniumWithPageObjects.PageObjects
{
    public class UserPage
    {
        private IWebDriver _driver;

        public UserPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement StartChatButton =>
            _driver.FindElement(By.XPath("//span[@air-module='module.messengerButton']"));

        public IWebElement ChatMessageInput => _driver.FindElement(By.XPath("//textarea[@placeholder]"));

        public UserPage StartChat()
        {
            StartChatButton.Click();
            Thread.Sleep(10000);
            return this;
        }

        public UserPage SendMessage(string messageContent)
        {
            if (messageContent == null) return this;
            ChatMessageInput.SendKeys(messageContent + Keys.Enter);
            Thread.Sleep(10000);
            return this;
        }

        public string GetLastMessageContent()
        {
            return _driver.FindElement(By.XPath("(//div[@class='message__content-text'])[last()]")).Text;
        }
    }
}