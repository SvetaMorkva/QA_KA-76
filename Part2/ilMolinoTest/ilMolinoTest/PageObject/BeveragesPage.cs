using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace IlMolinoSite.PageObject
{
    class BeveragesPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_733']")]
        private IWebElement _limeLemonade;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_1163499']")]
        private IWebElement _burn;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_1165168']")]
        private IWebElement _gingerNaturalTeaConcentrate;

        public BeveragesPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this._driver = driver;
        }

        public BeveragesPage BuyLimeLemonade()
        {
            _limeLemonade.Click();
            return this;
        }

        public BeveragesPage BuyBurn()
        {
            _burn.Click();
            return this;
        }

        public BeveragesPage BuyGingerNaturalTeaConcentrate()
        {
            _gingerNaturalTeaConcentrate.Click();
            return this;
        }
    }
}
