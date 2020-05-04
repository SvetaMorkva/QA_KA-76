using System;
using OpenQA.Selenium;

namespace SeleniumWithPageObjects.PageObjects
{
    public class BookmarksPage
    {
        private IWebDriver _driver;

        public BookmarksPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsPostInBookmarks(string postUrl)
        {
            try
            {
                _driver.FindElement(By.XPath($"//a[@href='{postUrl}']"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}