using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace QA_Lab2
{
    [TestFixture("automotive")]
    [TestFixture("education")]
    [TestFixture("electronics")]
    public class Customers
    {
        private string url = "https://www.zoho.com/customers.html";
        private string industry;
        private ChromeDriver driver;
        private IWebElement clearAll;
        private IWebElement articles;
        private SelectElement selectBoxIndustry;

        public Customers(string _industry)
        {
            industry = _industry;
        }

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            clearAll = driver.FindElement(By.CssSelector(".reset-filter"));
            articles = driver.FindElement(By.CssSelector("body .testimonial-block"));

            wait.Until(d => driver.FindElements(By.CssSelector("option[value=" + industry + "]")));
            selectBoxIndustry = new SelectElement(driver.FindElement(By.CssSelector(".filter.industry")));
            selectBoxIndustry.SelectByValue(industry);
            wait.Until(d => !articles.Displayed);
        }

        [Test]
        public void FilterByIndustry_ShouldLeaveAutomotiveArticles()
        {
            var articlesIndustry = driver.FindElements(By.CssSelector("[class*=" + industry + "]"));

            bool allIndustryArticlesDisplayed = true;
            foreach(var a in articlesIndustry)
            {
                if (!a.Displayed)
                {
                    allIndustryArticlesDisplayed = false;
                    break;
                }
            }

            Assert.IsTrue(allIndustryArticlesDisplayed);
        }

        [Test]
        public void FilterByIndustry_ShouldClearBeVisible()
        {
            Assert.IsTrue(clearAll.Enabled && clearAll.Displayed);
        }

        [Test]
        public void ClearClick_ShouldUnsetSelect_RemoveClearAllButton()
        {
            clearAll.Click();

            Assert.IsTrue(selectBoxIndustry.SelectedOption.Text == "Industry");
            Assert.IsTrue(!clearAll.Displayed);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
