using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace IlMolinoSite.PageObject
{
    class HitPizzaPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_577']")]
        private IWebElement _pizzaAmericana;

        public HitPizzaPage BuyPizzaAmericana()
        {
            _pizzaAmericana.Click();
            return this;
        }
        public HitPizzaPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this._driver = driver;
        }
    }
}
