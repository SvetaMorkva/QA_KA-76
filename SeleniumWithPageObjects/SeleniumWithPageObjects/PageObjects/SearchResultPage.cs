using OpenQA.Selenium;

namespace SeleniumWithPageObjects.PageObjects
{
    public class SearchResultPage
    {
        private IWebDriver _driver;

        public SearchResultPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetFirstResultHeaderText()
        {
            return _driver.FindElement(By.XPath("//h2[@class='content-header__title layout--a']")).Text.Trim();
        }
    }
}