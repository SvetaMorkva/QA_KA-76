using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace IlMolinoSite.PageObject
{
    class DessertPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_1165205']")]
        private IWebElement _syrnikiWithRaisins;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_1165308']")]
        private IWebElement _vanillaClassicIceCream;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_1165165']")]
        private IWebElement _darkChocolateIceCream;

        public DessertPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this._driver = driver;
        }

        public DessertPage BuySyrnikiWithRaisins()
        {
            _syrnikiWithRaisins.Click();
            return this;
        }

        public DessertPage BuyVanillaClassicIceCream()
        {
            _vanillaClassicIceCream.Click();
            return this;
        }

        public DessertPage BuyDarkChocolateIceCream()
        {
            _darkChocolateIceCream.Click();
            return this;
        }
    }
}
