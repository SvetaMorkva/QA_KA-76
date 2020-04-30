using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace IlMolinoSite.PageObject
{
    class MainPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='lang_bl']//div//a[@href='/en/delivery.html']")]
        private IWebElement _en;

        [FindsBy(How = How.XPath, Using = "//div[@class=\"lang_bl\"]//span//span")]
        private IWebElement _howLangage;

        [FindsBy(How = How.XPath, Using = "//a[@class='pre_r_a']")]
        private IWebElement _box;

        [FindsBy(How = How.XPath, Using = "//span[@class='js-lb-basket-qty']")]
        private IWebElement _countProducts;

        [FindsBy(How = How.XPath, Using = "//a[@class='menu-item-2325']")]
        private IWebElement _pizza;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_1165205']")]
        private IWebElement _dessert;

        [FindsBy(How = How.XPath, Using = "//a[@class='menu-item-2328']")]
        private IWebElement _salad;

        [FindsBy(How = How.XPath, Using = "//a[@class='menu-item-2386']")]
        private IWebElement _hitPizza;

        [FindsBy(How = How.XPath, Using = "//a[@class='menu-item-2329']")]
        private IWebElement _soup;

        [FindsBy(How = How.XPath, Using = "//a[@class='box js-add-basket tit_1165004']")]
        private IWebElement _mainDishes;

        [FindsBy(How = How.XPath, Using = "//a[@class='menu-item-2332']")]
        private IWebElement _beverages;

        [FindsBy(How = How.XPath, Using = "//div/a[@title='Краща мережа ресторанів']")]
        private IWebElement _money;

        [FindsBy(How = How.XPath, Using = "//div[@class='lang_bl']")]
        private IWebElement _langage;

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this._driver = driver;
        }

        public void ClickOnBox()
        {
            _box.Click();
        }

        public void ClickOnPizza()
        {
            _pizza.Click();
        }

        public void ClickOnDessert()
        {
            _dessert.Click();
        }
        public void ClickOnSalad()
        {
            _salad.Click();
        }
        public void ClickOnHitPizza()
        {
            _hitPizza.Click();
        }

        public void ClickOnSoup()
        {
            _soup.Click();
        }

        public void ClickOnMainDishes()
        {
            _mainDishes.Click();
        }

        public void ClickOnBeverages()
        {
            _beverages.Click();
        }

        public void ClickOnMoney()
        {
            _money.Click();
        }

        public void ClickOnLangage()
        {
            _langage.Click();
        }

        public void SelectEnglish()
        {
            _en.Click();
        }

        public string Langage
        {
            get => _howLangage.Text;
        }
        public string CountProducts
        {
            get => _countProducts.Text;
        }
    }
}
