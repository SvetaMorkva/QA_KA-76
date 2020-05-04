using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Laba2_part2
{
    public class Page
    {
        private IWebDriver _driver;
        static void Main()
        {
        }
        [Obsolete]
        public Page(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //test1
        [FindsBy(How = How.XPath, Using = "/html/body/nav/div/div/div[1]/nav/div/ul/li[3]/a")]
        private IWebElement BouquetPage;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[1]/div[1]/ul/li[1]/a")]
        private IWebElement FlowersPage;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/h1")]
        private IWebElement TitleFlower;


        [Obsolete]
        public Page GoToBouquetPage()
        {
            BouquetPage.Click();
            return this;
        }
        [Obsolete]
        public Page Selection()
        {
            FlowersPage.Click();
            return this;
        }
        public string GetTitle() => TitleFlower.Text;


        //test2
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[1]/div[2]/div[1]/div[2]/div/div[1]/h4/a")]
        private IWebElement Flowers;
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/div[1]/div[1]/h1")]
        private IWebElement FlowerTitle;

        [Obsolete]
        public Page GoToFlowersPage()
        {
            Flowers.Click();
            return this;
        }
        public string GetFlowerTitle() => FlowerTitle.Text;

        //test3
        [FindsBy(How = How.CssSelector, Using = "#button-cart")]
        private IWebElement ButtonBuy;
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/div[2]/h1")]
        private IWebElement BasketPageTitle;

        [Obsolete]
        public Page Buy()
        {
             ButtonBuy.Click();
            return this;
        }
        public string GetBasketPageTitle() => BasketPageTitle.Text;


        //test4
        [FindsBy(How = How.CssSelector, Using = "#logo > a:nth-child(1)")]
        private IWebElement HomePage;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div[1]/h2")]
        private IWebElement HomePageTitle;

        [Obsolete]
        public Page GoToHomePage()
        {
            HomePage.Click();
            return this;
        }
        public string GetHomePageTitle() => HomePageTitle.Text;

        //test5
        [FindsBy(How = How.CssSelector, Using = ".cart-href")]
        private IWebElement BasketPage;

        [Obsolete]
        public Page GoToBasketPage()
        {
            BasketPage.Click();
            return this;
        }

        //test6
        [FindsBy(How = How.CssSelector, Using = "#step_five > div:nth-child(3) > a:nth-child(1)")]
        private IWebElement FiveStepOrder;
        [FindsBy(How = How.CssSelector, Using = "div.radio:nth-child(1) > label:nth-child(1) > div:nth-child(2)")]
        private IWebElement PayWay;
        [FindsBy(How = How.CssSelector, Using = "button.next-step-button:nth-child(5)")]
        private IWebElement SubmitButton;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[3]/div/a")]
        private IWebElement PayWaySite;

        [Obsolete]
        public Page GoToFiveStep()
        {
            FiveStepOrder.Click();
            return this;
        }
        [Obsolete]
        public Page ChoosePayWay()
        {
            PayWay.Click();
            return this;
        }
        [Obsolete]
        public Page Submit()
        {
            SubmitButton.Click();
            return this;
        }
        public string GetSite()
        {
            var site = PayWaySite.GetAttribute("href");
            return site;
        }

        //test7
        [FindsBy(How = How.CssSelector, Using = "div.col-xl-auto:nth-child(1) > a:nth-child(7)")]
        private IWebElement ContactPage;
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div[1]/div/div/span/a[1]")]
        private IWebElement PhoneNumber;

        [Obsolete]
        public Page GoToContactPage()
        {
             ContactPage.Click();
            return this;
        }
        public string GetPhoneNumber()
        {
            var number = PhoneNumber.GetAttribute("href");
            return number;
        }
        //test8
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div[3]/div/div[2]/div/a")]
        private IWebElement Email;

        public string GetEmail()
        {
           var email = Email.GetAttribute("href");
            return email;
        }


    }
}
