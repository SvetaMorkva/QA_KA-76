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

        public void BuyLimeLemonade()
        {
            _limeLemonade.Click();
        }

        public void BuyBurn()
        {
            _burn.Click();
        }

        public void BuyGingerNaturalTeaConcentrate()
        {
            _gingerNaturalTeaConcentrate.Click();
        }
    }
}
