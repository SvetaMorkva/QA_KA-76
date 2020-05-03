using LabWork3.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace LabWork3
{
    [TestFixture]
    public class GeneralTests
    {
        private IWebDriver driver;

        [SetUp]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test_Login_Should_Redirect_Homepage()
        {
            // arrange
            var loginPage = new LoginPage(driver);

            // act
            var greeting_page = loginPage
                .LoadLoginPage()
                .Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2");
            
            // assert
            Assert.AreEqual("https://app.hubspot.com/getting-started/7486179", greeting_page.GetCurrntUrl());
        }


        [Test]
        public void Test_SignOut_Should_Redirect_LoginPage()
        {
            // arrange
            var loginPage = new LoginPage(driver);
            var greetingPage = loginPage
                .LoadLoginPage()
                .Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2");

            // act
            var resultPage = greetingPage.SignOut();

            // assert
            Assert.AreEqual("https://app.hubspot.com/login", resultPage.GetCurrntUrl());
        }


        [Test]
        public void Test_Add_Company_Should_Redirect_NewCompanyPage()
        {
            // arrange
            var loginPage = new LoginPage(driver);
            var companiesList = loginPage
                .LoadLoginPage()
                .Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2")
                .OpenCompaniesList();
            int nameIndex = 51;

            // act
            var company = companiesList.AddCompany($"test{nameIndex}.company", $"Test Company {nameIndex}", $"Test Description {nameIndex}");

            // assert
            String[] urlParametres = company.GetCurrntUrl().Split('/');
            Assert.AreEqual("company", urlParametres[urlParametres.Length - 2]);
        }



        [Test]
        public void Test_SearchInGoogle_Should_Redirect_GoogleSearchResult()
        {
            // arrange
            var loginPage = new LoginPage(driver);
            var contact = loginPage
                .LoadLoginPage()
                .Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2")
                .OpenContactsList()
                .OpenContactPage(851);

            String[] parsedLink = contact.GetGoogleSearchLink().Split('=');

            // act
            GoogleSearchResultsPage result = contact.SearchInGoogle();

            // assert
            String[] currentUrl = result.GetCurrntUrl().Split('=');
            Assert.AreEqual(parsedLink[parsedLink.Length - 1], currentUrl[currentUrl.Length - 1]);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
