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

        public PizzaPage BuyPizzaVerona()
        {
            _pizzaVerona.Click();
            return this;
        }

        public PizzaPage BuyPizzaBarbuqueGourmet()
        {
            _pizzaBarbuqueGourmet.Click();
            return this;
        }

        public PizzaPage BuyPizzaMargherita()
        {
            _pizzaMargherita.Click();
            return this;
        }
    }
}
