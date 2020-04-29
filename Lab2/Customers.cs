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
        private string url = "https://www.zoho.com/customers.html";
        private string industry;
        private ChromeDriver driver;
        private WebDriverWait wait;
        private IWebElement clearAll;
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
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            clearAll = driver.FindElement(By.CssSelector(".reset-filter"));

            wait.Until(d => driver.FindElement(By.CssSelector(".filter.industry")));
            selectBoxIndustry = new SelectElement(driver.FindElement(By.CssSelector(".filter.industry")));
            wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.CssSelector(".filter.industry"))));
            wait.Until(d => selectBoxIndustry.Options.Count > 50);
            selectBoxIndustry.SelectByValue(industry);
            wait.Until(d => driver.FindElements(By.CssSelector("div[class$='reset-filter']")).Count == 0);
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
            Actions actions = new Actions(driver);
            actions.MoveToElement(clearAll, 1, 1).Click().Build().Perform();

            wait.Until(d => driver.FindElements(By.CssSelector("div[class$='reset-filter']")));

            Assert.IsTrue(!clearAll.Displayed);
            Assert.IsTrue(selectBoxIndustry.SelectedOption.Text == "Industry");
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
