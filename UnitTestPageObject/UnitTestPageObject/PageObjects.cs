using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lab2_1
{
    public class WebPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [Obsolete]
        public WebPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "foo")]
        public IWebElement NavList;

        [FindsBy(How = How.CssSelector, Using = "a[href*=\"zviti\"]")]
        public IWebElement ItemReports;

        [FindsBy(How = How.CssSelector, Using = ".lang-item-bottom a")]
        public IWebElement LangSwitcher;

        [FindsBy(How = How.CssSelector, Using = ".main-wrapper h1")]
        public IWebElement TitleLabel;

        [FindsBy(How = How.ClassName, Using = "news-home-description")]
        public IWebElement CheckLabel;

        [FindsBy(How = How.CssSelector, Using = ".heade__icon.f-heade__icon a")]
        public IWebElement FacebookItem;

        [FindsBy(How = How.CssSelector, Using = "a[href*=\"nszu.gov.ua/academy\"]")]
        public IWebElement NavAcademy;

        [FindsBy(How = How.CssSelector, Using = ".col-md-5 a")]
        public IWebElement Academy;

        [FindsBy(How = How.CssSelector, Using = ".sign-up-btn button")]
        public IWebElement AcademyTitle;

        [FindsBy(How = How.CssSelector, Using = ".search-container.for-desktop input")]
        public IWebElement SearchBox;

        [FindsBy(How = How.CssSelector, Using = ".search-container.for-desktop button")]
        public IWebElement SearchButton;

        [FindsBy(How = How.CssSelector, Using = ".main-wrapper h1")]
        public IWebElement SearchTitle;

        [FindsBy(How = How.CssSelector, Using = "a[href*=\"tel:16-77\"]")]
        public IWebElement FeetbackNumber;

        [FindsBy(How = How.CssSelector, Using = "a[href*=\"info@nszu.gov.ua\"]")]
        public IWebElement FeetbackEmail;
        

        [Obsolete]
        public WebPage SelectItemOfNavigatoin(string infoUkr)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(NavList));
            NavList.Click();
            Thread.Sleep(3000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//div[@class='col-12 col-md-6 col-xl-4 jj']//ul//li//ul//a[contains(text(), '{infoUkr}')]")));
            driver.FindElement(By.XPath($"//div[@class='col-12 col-md-6 col-xl-4 jj']//ul//li//ul//a[contains(text(), '{infoUkr}')]")).Click();
            Thread.Sleep(3000);

            return this;
        }
        
        public string GetTitleLabel() => TitleLabel.Text.ToLower();
        
        [Obsolete]
        public WebPage SwitchLang()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(LangSwitcher));
            LangSwitcher.Click();
            Thread.Sleep(1000);
            return this;
        }

        public string GetLabel() => CheckLabel.Text;


        [Obsolete]
        public WebPage OpenFacebookSource()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(FacebookItem));
            FacebookItem.Click();
            Thread.Sleep(3000);

            driver.SwitchTo().Window(driver.WindowHandles.Last());

            return this;
        }


        [Obsolete]
        public WebPage GoToAcademy()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(NavAcademy));
            NavAcademy.Click();
            Thread.Sleep(3000);

            driver.SwitchTo().Window(driver.WindowHandles.Last());

            wait.Until(ExpectedConditions.ElementToBeClickable(Academy));
            Academy.Click();

            return this;
        }

        public string GetAcademyTtileText() => AcademyTitle.Text;

        [Obsolete]
        public WebPage GetSearchBoxResult(string textValueToSet)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(SearchBox));
            SearchBox.SendKeys(textValueToSet);
            wait.Until(ExpectedConditions.ElementToBeClickable(SearchButton));
            SearchButton.Click();
            Thread.Sleep(3000);

            return this;
        }

        public string GetSearchTitle() => SearchTitle.Text;

        [Obsolete]
        public WebPage GetReports()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(NavList));
            NavList.Click();
            Thread.Sleep(3000);

            wait.Until(ExpectedConditions.ElementToBeClickable(ItemReports));
            ItemReports.Click();
            Thread.Sleep(3000);

            return this;
        }

        public string GetFeetbackNumber() => FeetbackNumber.Text;

        public string GetFeetbackEmail() => FeetbackEmail.Text;
        

    }
}