using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace IlMolinoSite.PageObject
{
    class MainSite
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[@class='pre_r_a']")]
        private IWebElement _box;

        [FindsBy(How = How.XPath, Using = "//span[@class='js-lb-basket-qty']")]
        private IWebElement _countProducts;
    }
}
