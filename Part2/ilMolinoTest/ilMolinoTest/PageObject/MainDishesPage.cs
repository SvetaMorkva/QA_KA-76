using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace IlMolinoSite.PageObject
{
    class MainDishesPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_1165004']")]
        private IWebElement _pappardelleWithVealCheeks;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_1165005']")]
        private IWebElement _ravioliWithMushroomsAndTofu;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_1165006']")]
        private IWebElement _doradoWithVegetables;


        public MainDishesPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this._driver = driver;
        }

        public MainDishesPage BuyRavioliWithMushroomAndTofu()
        {
            _ravioliWithMushroomsAndTofu.Click();
            return this;
        }

        public MainDishesPage BuyPappardelleWithVealCheeks()
        {
            _pappardelleWithVealCheeks.Click();
            return this;
        }

        public MainDishesPage BuyDoradoWithVegetables()
        {
            _doradoWithVegetables.Click();
            return this;
        }
    }
}
