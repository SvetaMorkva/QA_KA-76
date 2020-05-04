using System.Threading;
using OpenQA.Selenium;

namespace SeleniumWithPageObjects.PageObjects
{
    public class SubsPage
    {
        private IWebDriver _driver;

        public SubsPage(IWebDriver driver)
        {
            _driver = driver;
        }
        
        // subscribe button to first recommended rubric
        public IWebElement SubscribeButton =>
            _driver.FindElement(By.XPath("//div[@class='subsites_catalog__recommended']/div/div/div[2]/div"));

        public SubsPage SubscribeRubric()
        {
            SubscribeButton.Click();
            Thread.Sleep(10000);
            return this;
        }
        
        public string GetUnsubscribedRubricLink()
        {
            return _driver.FindElement(By.XPath("//div[@class='subsites_catalog__recommended']/div/div/a"))
                .GetAttribute("href");
        }
    }
}