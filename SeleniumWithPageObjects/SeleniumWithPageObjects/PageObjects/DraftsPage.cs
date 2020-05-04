using OpenQA.Selenium;

namespace SeleniumWithPageObjects.PageObjects
{
    public class DraftsPage
    {
        private IWebDriver _driver;

        public DraftsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetLastDraftHeader()
        {
            return _driver.FindElement(By.XPath("//div[@class='feed__chunk']/div//h2")).Text;
        }
    }
}