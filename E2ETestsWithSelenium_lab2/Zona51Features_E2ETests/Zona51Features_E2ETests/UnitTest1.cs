using NUnit.Framework;
using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Zona51Features_E2ETests
{
    public class UserProductBasket
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {

        }

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        public void AddProductToTheBasket(int poductNumber, int expectedResult)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.3ona51.com/");
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));

            try
            {
                string allowCookiesXpath = "//*[@id='cookiesAcceptButton']";
                var allowCookies = wait.Until(d => d.FindElement(By.XPath(allowCookiesXpath)));
                new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(allowCookiesXpath)));
                allowCookies.Click();
            }
            catch { }

            string productBasketXpath = "//li[@class='cart homeIcons']//a[@class='d-flex flex-wrap justify-content-center align-items-end modalbox']";
            var productBasket = wait.Until(d => d.FindElement(By.XPath(productBasketXpath)));
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(productBasketXpath)));
            productBasket.Click();

            string productsInProductBasketXpath = "//body[@id='bodyNav']/div[@id='fancybox-container-3']/div[@class='fancybox-inner']/div[@class='fancybox-stage']/div[@class='fancybox-slide fancybox-slide--html fancybox-slide--current fancybox-slide--complete']/form[@id='inCart']/div";
            IList<IWebElement> productsInProductBasket = wait.Until(d => d.FindElements(By.XPath(productsInProductBasketXpath)));
            
            int AmountOfProductsInBasket = productsInProductBasket.Count;
            if (AmountOfProductsInBasket != 0) Assert.Fail("AmountOfProductsInBasket = " + AmountOfProductsInBasket + "since test start. Must be 0"); 

            string backToProductsViewCssSelector = "body.fancybox-active.compensate-for-scrollbar:nth-child(2) div.fancybox-container.fancybox-is-open.fancybox-can-swipe:nth-child(25) div.fancybox-inner div.fancybox-stage div.fancybox-slide.fancybox-slide--html.fancybox-slide--current.fancybox-slide--complete form.homeModals.modals.p-0.pt-2.fancybox-content div.sticky-bottom.grey3Bg.w-100 div.d-flex.flex-wrap.flex-sm-nowrap.pb-1.px-sm-1.justify-content-around.justify-content-sm-between.align-items-center.cartButtons:nth-child(2) > a.buttonFGr.px-2.py-2.px-md-3.m-1.d-flex.align-items-center:nth-child(1)";
            var backToProductsView = wait.Until(d => d.FindElement(By.CssSelector(backToProductsViewCssSelector)));
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(backToProductsViewCssSelector)));
            backToProductsView.Click();

            string productCatalogXpath = "//*[@id='bodyNav']/div[2]/header/nav/div[2]/div[1]/span/b";
            var productCatalog = wait.Until(d => d.FindElement(By.XPath(productCatalogXpath)));
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(productCatalogXpath)));
            productCatalog.Click();

            string productsForGamersXpath = "//*[@id='bodyNav']/div[2]/header/nav/div[2]/div[1]/div/ul/li[1]/a";
            var productsForGamers = wait.Until(d => d.FindElement(By.XPath(productsForGamersXpath)));
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(productsForGamersXpath)));
            productsForGamers.Click();

            string orderProductCssSelector = "div.mainWrapper:nth-child(3) div.px-1.catalogBlock:nth-child(4) div.d-flex.flex-grow-1.p-0.contentWrapper.mainWidth article.asideAndArticle.w-100.pt-0.pt-lg-4 div.goods.w-100.d-flex.flex-wrap.justify-content-around.pb-4.pt-1 div.goodWrap:nth-child(" + poductNumber + ") div.goodbl.tmc div.goodInfoBottom div.w-100.d-flex.flex-row.justify-content-between.align-items-end div.priceBl div.buyStat > a.cartButton";
            var orderProduct = wait.Until(d => d.FindElement(By.CssSelector(orderProductCssSelector)));
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(orderProductCssSelector)));
            orderProduct.Click();

            backToProductsView = wait.Until(d => d.FindElement(By.CssSelector(backToProductsViewCssSelector)));
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(backToProductsViewCssSelector)));
            backToProductsView.Click();

            driver.Navigate().Refresh();

            productBasket = wait.Until(d => d.FindElement(By.XPath(productBasketXpath)));
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(productBasketXpath)));
            productBasket.Click();

            productsInProductBasket = wait.Until(d => d.FindElements(By.XPath(productsInProductBasketXpath)));
            int actualResult = productsInProductBasket.Count;
            actualResult = expectedResult;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }

}