using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace IlMolinoSite.PageObject
{
    class SaladsPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_1165002']")]
        private IWebElement _vealSalad;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_1164611')")]
        private IWebElement _saladNicoise;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_697')")]
        private IWebElement _caesarSaladWithChicken;

        public SaladsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this._driver = driver;
        }

        public SaladsPage BuyVealSalad()
        {
            _vealSalad.Click();
            return this;
        }

        public SaladsPage BuySaladNicoise()
        {
            _saladNicoise.Click();
            return this;
        }

        public SaladsPage BuyCaesarSaladWithChicken()
        {
            _caesarSaladWithChicken.Click();
            return this;
        }
    }
}
