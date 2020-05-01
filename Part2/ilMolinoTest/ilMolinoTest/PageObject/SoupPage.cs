using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace IlMolinoSite.PageObject
{
    class SoupPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_704']")]
        private IWebElement _chickenSoupWithPasta;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_1164320']")]
        private IWebElement _tomatoSoup;

        public SoupPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this._driver = driver;
        }

        public void BuyChickenSoupWithPasta()
        {
            _chickenSoupWithPasta.Click();
        }

        public void BuyTomatoSoup()
        {
            _tomatoSoup.Click();
        }
    }
}
