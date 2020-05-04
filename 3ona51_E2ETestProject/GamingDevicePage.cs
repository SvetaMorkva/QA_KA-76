using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace _3ona51_E2ETestProject
{
    public class GamingDevicePage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "a.cartButton")]
        private IList<IWebElement> BuyProductButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.mainWrapper:nth-child(3) header.px-1.pt-1.sticky-top:nth-child(1) nav.mainWidth.d-flex.flex-wrap.align-items-center.px-0:nth-child(1) div.d-flex.flex-wrap.flex-sm-nowrap.align-items-center.justify-content-between.flex-grow-1.mb-1 div.home.p-0.m-0.pt-lg-2.pt-lg-0.d-flex.align-items-center.justify-content-center.order-3.order-sm-4 ul.p-0.m-0.d-flex.align-items-end.justify-content-center li.cart.homeIcons > a.d-flex.flex-wrap.justify-content-center.align-items-end.modalbox")]
        private IWebElement OpenProductBusketButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.xButton.red.p-1.p-wsm-2.d-none.d-wsm-block")]
        private IList<IWebElement> DeleteProductFromBasketButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='inCart']/div[3]/div[1]/span/span")]
        private IWebElement SumUpOrderPrice;


        [FindsBy(How = How.CssSelector, Using = "a.buttonFGr.px-2.py-2.px-md-3.m-1.d-flex.align-items-center")]
        private IWebElement CloseProductBusketButton { get; set; }

        

        public GamingDevicePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public GamingDevicePage BuyProduct(int indexOfProduct)
        {
            new WebDriverWait(_driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(BuyProductButton[indexOfProduct]));
            BuyProductButton[indexOfProduct].Click();
            return this;
        }

        public GamingDevicePage OpenProductBusket()
        {
            new WebDriverWait(_driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(OpenProductBusketButton));
            OpenProductBusketButton.Click();
            return this;
        }

        public int AmountOfProductsInBusket()
        {
            new WebDriverWait(_driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(CloseProductBusketButton));
            return DeleteProductFromBasketButton.Count; ;
        }

        public int GetSumUpOrderPrice()
        {
            new WebDriverWait(_driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(CloseProductBusketButton));
            string input = SumUpOrderPrice.Text;
            input = input.Substring(0, input.LastIndexOf("."));
            
            return Int32.Parse(input);
        }

        public GamingDevicePage DeleteProductFromProductBusket(int indexOfProductInBasket)
        {
            new WebDriverWait(_driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(CloseProductBusketButton));
            new WebDriverWait(_driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(DeleteProductFromBasketButton[indexOfProductInBasket]));
            DeleteProductFromBasketButton[indexOfProductInBasket].Click();
            return this;
        }

        public GamingDevicePage CloseProductBusket()
        {
            new WebDriverWait(_driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(CloseProductBusketButton));
            CloseProductBusketButton.Click();
            return this;
        }
    }
}