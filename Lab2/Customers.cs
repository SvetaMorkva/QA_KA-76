﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace QA_Lab2
{
    [TestFixture]
    public class Customers
    {
        string url = "https://www.zoho.com/customers.html";
        ChromeDriver driver;
        IWebElement clearAll;
        IWebElement articles;
        SelectElement selectBoxIndustry;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            clearAll = driver.FindElement(By.CssSelector(".reset-filter"));
            articles = driver.FindElement(By.CssSelector("body .testimonial-block"));

            wait.Until(d => driver.FindElements(By.CssSelector(".filter.industry")).Count > 0);
            selectBoxIndustry = new SelectElement(driver.FindElement(By.CssSelector(".filter.industry")));
            selectBoxIndustry.SelectByValue("automobile");
            wait.Until(d => !articles.Displayed);
        }

        [Test]
        public void Customers_FilterByIndustry_ShouldLeaveAutomobileArticles()
        {
            var articlesIndustry = driver.FindElements(By.CssSelector("[class*='automobile']"));

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
        public void Customers_FilterByIndustry_ShouldClearBeVisible()
        {
            Assert.IsTrue(clearAll.Enabled && clearAll.Displayed);
        }

        [Test]
        public void Customers_ClearClick_ShouldUnsetSelect_RemoveClearAllButton()
        {
            clearAll.Click();

            Assert.IsTrue(selectBoxIndustry.SelectedOption.Text == "Industry");
            Assert.IsTrue(!clearAll.Displayed);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }
    }
}
