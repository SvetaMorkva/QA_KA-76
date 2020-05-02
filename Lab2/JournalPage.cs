using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab2
{
    class JournalPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public JournalPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "fa-caret-down")]
        private IWebElement ArrowDown;

        [FindsBy(How = How.CssSelector, Using = ".mobile_app:nth-of-type(2) a")]
        private IWebElement AppStore;

        [FindsBy(How = How.TagName, Using = "h1")]
        private IWebElement AppName;

        [FindsBy(How = How.ClassName, Using = "projects")]
        private IWebElement Projects;

        [FindsBy(How = How.CssSelector, Using = ".article-block-title a")]
        private IWebElement FirstArticleTitle;


        public JournalPage SelectTopic(string Topic)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(ArrowDown));
            ArrowDown.Click();
            Thread.Sleep(3000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//ul[@class='categories']//a[text()='{Topic}']")));
            driver.FindElement(By.XPath($"//ul[@class='categories']//a[text()='{Topic}']")).Click();
            Thread.Sleep(3000);
            return this;
        }

        public List<string> GetArticlesCategories()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            List<IWebElement> CategoryElements = new List<IWebElement>();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".article-block-category a")));
            CategoryElements.AddRange(driver.FindElements(By.CssSelector(".article-block-category a")));
            List<string> CategoryElementsName = new List<string>();

            foreach (IWebElement element in CategoryElements)
                CategoryElementsName.Add(element.Text.Trim().ToLower());
            return CategoryElementsName;
        }

        public JournalPage GoToAppStore()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(AppStore));
            AppStore.Click();
            return this;
        }

        public string GetAppName() => AppName.Text;

        public JournalPage SelectCategory(string Topic)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(Projects));
            Projects.Click();
            Thread.Sleep(3000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//div[@class='journal-page projects']//a[contains(text(), '{Topic}')]")));
            driver.FindElement(By.XPath($"//div[@class='journal-page projects']//a[contains(text(), '{Topic}')]")).Click();
            Thread.Sleep(3000);
            return this;
        }

        public List<string> GetFirstArticleCategories()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(FirstArticleTitle));
            FirstArticleTitle.Click();

            List<IWebElement> CategoryElements = new List<IWebElement>();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".article-page .article-block-category a")));
            CategoryElements.AddRange(driver.FindElements(By.CssSelector(".article-page .article-block-category a")));
            List<string> CategoryElementsName = new List<string>();
            foreach (IWebElement element in CategoryElements)
                CategoryElementsName.Add(element.Text.Trim().ToLower());
            return CategoryElementsName;
        }
    }
}
