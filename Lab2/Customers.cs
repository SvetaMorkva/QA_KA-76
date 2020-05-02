using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;

namespace QA_Lab2
{
    [TestFixture("automotive")]
    [TestFixture("education")]
    [TestFixture("electronics")]
    public class Customers
    {
        private readonly string industryValue;
        CustomerPage _CustomerPage;
        ChromeDriver Driver;

        public Customers(string _industry)
        {
            industryValue = _industry;
        }

        [SetUp]
        public void Initialize()
        {
            Driver = new ChromeDriver();
            _CustomerPage = new CustomerPage(Driver);

            _CustomerPage
                .OpenCustomerPage()
                .SelectValueInIndustryDropDown(industryValue)
                .WaitUntiTransparentClearAllButtonDisappeared();
        }

        [Test]
        public void FilterByIndustry_ShouldLeaveSelectedIndustryArticles()
        {
            _CustomerPage.GetArticlesOfSelectedIndustry(industryValue);

            Assert.IsTrue(_CustomerPage.ArticlesOfSelectedIndustryIsVisible());
        }

        [Test]
        public void FilterByIndustry_ShouldClearBeVisible()
        {
            Assert.IsTrue(_CustomerPage.ClearAllButtonIsVisible);
        }

        [Test]
        public void ClearClick_ShouldUnsetSelect_RemoveClearAllButton()
        {
            _CustomerPage
                .OnClearAllButtonClick()
                .WaitUntiTransparentClearAllButtonCreated();

            Assert.IsTrue(
                _CustomerPage.CheckTextOfIndustryDropDown("Industry") 
                && ! _CustomerPage.ClearAllButton.Displayed);
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Quit();
        }
    }
}
