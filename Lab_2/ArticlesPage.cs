using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lab_2
{
    public class ArticlesPage
    {
        private IWebDriver _driver;

        public ArticlesPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".top_wide li:nth-of-type(3) a")]
        private IWebElement TagsPage;

        [FindsBy(How = How.CssSelector, Using = ".top_wide li:nth-of-type(2) a")]
        private IWebElement BestArticles;

        [FindsBy(How = How.CssSelector, Using = ".page-head h1")]
        private IWebElement PageHeader;

        [FindsBy(How = How.XPath, Using = "//select/option[text()='Digests']")]
        private IWebElement ComboBoxDigests;

        [FindsBy(How = How.CssSelector, Using = ".title a")]
        private IWebElement FirstArticleHeader;

        public ArticlesPage GoToTags()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(TagsPage));
            TagsPage.Click();
            return this;
        }

        public ArticlesPage SelectBestArticles()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(BestArticles));
            BestArticles.Click();
            return this;
        }

        public string GetPageHeader() => PageHeader.Text;

        public ArticlesPage SelectDigestsOption()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(ComboBoxDigests));
            ComboBoxDigests.Click();
            return this;
        }

        public string GetFirstArticleHeader() => FirstArticleHeader.Text;

        public ArticlesPage SelectTag(string TagName)
        {
            IWebElement Tag = _driver.FindElement(By.XPath($"//a[contains(text(), '{TagName}') and @class='b-tag tag-7']"));
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(Tag));
            Tag.Click();
            return this;
        }
    }
}
