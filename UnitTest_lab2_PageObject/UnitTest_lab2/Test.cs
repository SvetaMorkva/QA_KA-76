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
        private IWebDriver _driver;
        private string _url = "https://www.creatio.com/";
        
        [SetUp]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl(_url);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.UrlToBe(_url));

            var mainPage = new MainPage(_driver);
            mainPage.CloseNotification();
        }

        [TearDown]
        public void TestFinalize()
        {
            _driver.Quit();
        }



        [Test]
        public void TestLookingPartners()
        {
            var mainPage = new MainPage(_driver);
            var partnerPage = new PartnerPage(_driver);

            mainPage.GoToPartnersPage();

            string actual_header = partnerPage.GetPageHeader();
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

            var mainPage = new MainPage(_driver);
            var partnerPage = new PartnerPage(_driver);

            mainPage.GoToPartnersPage();
            partnerPage.ChatClose();
            partnerPage.SelectPartner(n);

            using (new AssertionScope())
            { 
                _driver.Url.Should().Be($"https://www.creatio.com/partners/{expected_partner.ToLower()}");
            }

        }

        [TestCase("Amdocs")]
        [TestCase("TSI")]
        public void TestSearchforPartners(string expected_company)
        {

            var mainPage = new MainPage(_driver);
            var partnerPage = new PartnerPage(_driver);

            mainPage.GoToPartnersPage();

            Thread.Sleep(1000);
            partnerPage.SearchPartner(expected_company);
            string actual_company = partnerPage.MoveItem(1).GetDescription(1);
            using (new AssertionScope())
            {
                actual_company.Should().Contain(expected_company);

            }
            

        }

        [Test]
        public void TestFilterPartners()
        {
            
            var mainPage = new MainPage(_driver);
            var partnerPage = new PartnerPage(_driver);

            mainPage.GoToPartnersPage();

            Thread.Sleep(1000);

            partnerPage.SelectRegion("Europe").SelectCountry("Ukraine");

            Thread.Sleep(5000);
            string actual_company1 = partnerPage.MoveItem(1).GetDescription(1);
            string actual_company2 = partnerPage.MoveItem(2).GetDescription(2);
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

            var mainPage = new MainPage(_driver);
            var partnerPage = new PartnerPage(_driver);

            mainPage.GoToPartnersPage();
            Thread.Sleep(1000);
            partnerPage.SelectCountry(country);

            Thread.Sleep(5000);
            string actual_country = partnerPage.GetCountry(1);
          
            using (new AssertionScope())
            {
                actual_country.Should().Contain(country);
                
            }


        }

        [Test]
        public void ToMainPage()
        {
            var mainPage = new MainPage(_driver);
            var partnerPage = new PartnerPage(_driver);

            mainPage.GoToPartnersPage();
            Thread.Sleep(1000);
            partnerPage.GoToMainPage();
            Thread.Sleep(2000);

            using (new AssertionScope())
            {
                _driver.Url.Should().Be(_url); 
            }

        }

        [TestCase("ProcessFirst", "http://processfirst.fr/")]
        [TestCase("Amdocs","https://www.amdocs.com/")]
        [TestCase("TSI", "https://tsintegr.com/")]
        public void PartnersLink(string expected_company, string url)
        {

            var mainPage = new MainPage(_driver);
            var partnerPage = new PartnerPage(_driver);
            var itemPage = new ItemPage(_driver);

            mainPage.GoToPartnersPage();
            Thread.Sleep(2000);
            partnerPage.ChatClose();
            partnerPage.SearchPartner(expected_company).GoToPageItem();
            itemPage.GoToItemWeb();
           
            using (new AssertionScope())
            {
                _driver.Url.Should().Be(url);
            }


        }
    }
}