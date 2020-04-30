using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace IlMolinoSite.PageObject
{
    class PizzaPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_1165015']")]
        private IWebElement _pizzaVerona;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_1165008']")]
        private IWebElement _pizzaBarbuqueGourmet;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_557']")]
        private IWebElement _pizzaMargherita;

        public PizzaPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this._driver = driver;
        }

        public void BuyPizzaVerona()
        {
            _pizzaVerona.Click();
        }

        public void BuyPizzaBarbuqueGourmet()
        {
            _pizzaBarbuqueGourmet.Click();
        }

        public void BuyPizzaMargherita()
        {
            _pizzaMargherita.Click();
        }
    }
}
