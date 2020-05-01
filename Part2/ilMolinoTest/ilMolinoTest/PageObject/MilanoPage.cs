﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace IlMolinoSite.PageObject
{
    class MilanoPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[@class='button_a js-add-ingr']")]
        private IWebElement _buttonAddIngredients;

        [FindsBy(How = How.XPath, Using = "//li[@data-absnum='780']//a[@class='plus_ingr js-btn-ingr-plus']")]
        private IWebElement _plusChickenFillet;

        [FindsBy(How = How.XPath, Using = "//span[@class='js-lb-price']")]
        private IWebElement _price;
        public MilanoPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this._driver = driver;
        }

        public void ClickOnButtonAddIngredients()
        {
            _buttonAddIngredients.Click();
        }

        public void ClickOnPlusButtonChickenFillet()
        {
            _plusChickenFillet.Click();
        }

        public string Price
        {
            get => _price.Text;
        }
    }
}
