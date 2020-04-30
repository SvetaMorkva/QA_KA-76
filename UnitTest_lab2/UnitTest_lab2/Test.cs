using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace UnitTest_lab2
{
    [TestFixture]
    public class Test
    {
        private IWebDriver driver;
        private string _url = "https://www.creatio.com/";
        private string _partner_selector = "#block-mainmenu li:nth-of-type(5) a";
        
        private static IWebElement WaitandFindElement(IWebDriver driver, By selector)
        {
            Thread.Sleep(1000);
            new WebDriverWait(driver, TimeSpan.FromSeconds(40)).Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(selector)));
            return driver.FindElement(selector);
        }

        [SetUp]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(_url);
       
            WaitandFindElement(driver, By.CssSelector(" .eu-cookie-compliance-buttons button")).Click();
            WaitandFindElement(driver, By.XPath("//button[@aria-label='Close']")).Click();
        }

        [TearDown]
        public void TestFinalize()
        {
            driver.Quit();
        }



        [Test]
        public void TestLookingPartners()
        {
            IWebElement element = WaitandFindElement(driver, By.CssSelector(_partner_selector));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            WaitandFindElement(driver, By.CssSelector("#block-mainmenu li:nth-of-type(5) div.main-menu-submenu-row div:nth-child(2)  li:nth-child(1)  a")).Click();

            string actual_header = WaitandFindElement(driver, By.CssSelector("#block-topheaderinpartnerspage h1")).Text;
            using (new AssertionScope())
            {
                actual_header.Should().Contain("Creatio partner");

            }

        }

        [TestCase("ProcessFirst", 2)]
        [TestCase("TSI", 4)]
        [TestCase("Amdocs", 6 )]
        public void TestChoosePartnerFromList(string expected_partner, int n)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WaitandFindElement(driver, By.CssSelector(_partner_selector)).Click();
            WaitandFindElement(driver, By.CssSelector(_partner_selector)).Click();
            
            js.ExecuteScript("window.scrollBy(0,250)", "");
            
            WaitandFindElement(driver, By.CssSelector($"#mp-catalog-item-{n} div")).Click();

            using (new AssertionScope())
            {
                
                driver.Url.Should().Be($"https://www.creatio.com/partners/{expected_partner.ToLower()}");

            }

        }

        [TestCase("Amdocs")]
        [TestCase("TSI")]
        public void TestSearchforPartners(string expected_company)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WaitandFindElement(driver, By.CssSelector(_partner_selector)).Click();
            WaitandFindElement(driver, By.CssSelector(_partner_selector)).Click();
           
            js.ExecuteScript("window.scrollBy(0,250)", "");

            Thread.Sleep(1000);
            WaitandFindElement(driver, By.CssSelector("input[ type = text]")).SendKeys(expected_company);
            WaitandFindElement(driver, By.CssSelector(".startSearch-btn")).Click();

    
            Actions action = new Actions(driver);
            action.MoveToElement(WaitandFindElement(driver, By.CssSelector("#mp-catalog-item-1 div"))).Perform();

            string actual_company = WaitandFindElement(driver, By.CssSelector("#mp-catalog-item-1 .mp-catalog-item-description-full-title")).Text;
            using (new AssertionScope())
            {
                actual_company.Should().Contain(expected_company);

            }
            

        }

        [Test]
        public void TestFilterPartners()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WaitandFindElement(driver, By.CssSelector(_partner_selector)).Click();
            WaitandFindElement(driver, By.CssSelector(_partner_selector)).Click();

            js.ExecuteScript("window.scrollBy(0,250)", "");


            SelectElement SelectRegion = new SelectElement(driver.FindElement(By.Id("mp-catalog-filter-select-region")));
            SelectRegion.SelectByText("Europe");

            SelectElement SelectCountry = new SelectElement(driver.FindElement(By.Id("mp-catalog-filter-select-country")));
            SelectCountry.SelectByText("Ukraine");

            Actions action1 = new Actions(driver);
            action1.MoveToElement(WaitandFindElement(driver, By.CssSelector("#mp-catalog-item-1 div"))).Perform();
            string actual_company1 = WaitandFindElement(driver, By.CssSelector("#mp-catalog-item-1 .mp-catalog-item-description-full-title")).Text;

            Actions action2 = new Actions(driver);
            action1.MoveToElement(WaitandFindElement(driver, By.CssSelector("#mp-catalog-item-2 div"))).Perform();
            string actual_company2 = WaitandFindElement(driver, By.CssSelector("#mp-catalog-item-2 .mp-catalog-item-description-full-title")).Text;


            using (new AssertionScope())
            {
                actual_company1.Should().Contain("CRM");
                actual_company2.Should().Contain("Galaktika");

            }


        }

        [TestCase("United Kingdom")]
        [TestCase("France")]
        [TestCase("Italy")]
        public void TestPartnersCountry(string country)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WaitandFindElement(driver, By.CssSelector(_partner_selector)).Click();
            WaitandFindElement(driver, By.CssSelector(_partner_selector)).Click();

            js.ExecuteScript("window.scrollBy(0,250)", "");

            SelectElement SelectCountry = new SelectElement(driver.FindElement(By.Id("mp-catalog-filter-select-country")));
            SelectCountry.SelectByText(country);

            string actual_country = WaitandFindElement(driver, By.CssSelector("#mp-catalog-item-1 .mp-catalog-item-description-teaser")).Text;
            using (new AssertionScope())
            {
                actual_country.Should().Contain(country);
                
            }


        }

        [Test]
        public void ToMainPage()
        {
            IWebElement element = WaitandFindElement(driver, By.CssSelector(_partner_selector));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            WaitandFindElement(driver, By.CssSelector("#block-mainmenu li:nth-of-type(5) div.main-menu-submenu-row div:nth-child(2)  li:nth-child(1)  a")).Click();
            WaitandFindElement(driver, By.CssSelector("img[alt = 'Creatio']")).Click();
            
         
            using (new AssertionScope())
            {
                driver.Url.Should().Be(_url); 
            }

        }

        [TestCase("ProcessFirst", "http://processfirst.fr/")]
        [TestCase("Amdocs","https://www.amdocs.com/")]
        [TestCase("TSI", "https://tsintegr.com/")]
        public void PartnersLink(string expected_company, string url)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WaitandFindElement(driver, By.CssSelector(_partner_selector)).Click();
            WaitandFindElement(driver, By.CssSelector(_partner_selector)).Click();

            js.ExecuteScript("window.scrollBy(0,250)", "");

            Thread.Sleep(1000);
            WaitandFindElement(driver, By.CssSelector("input[ type = text]")).SendKeys(expected_company);
            WaitandFindElement(driver, By.CssSelector(".startSearch-btn")).Click();

            WaitandFindElement(driver, By.CssSelector("#mp-catalog-item-1 div")).Click();
            js.ExecuteScript("window.scrollBy(0,250)", "");
            WaitandFindElement(driver, By.CssSelector(".group-app-developer a")).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            using (new AssertionScope())
            {
                driver.Url.Should().Be(url);
            }


        }
    }
}