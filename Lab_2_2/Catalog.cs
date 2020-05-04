using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lab_2
{
    public class Catalog
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public Catalog(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "a[title='Загальний каталог']")]
        private IWebElement ToCatalog;

        [FindsBy(How = How.ClassName, Using = "keyboardInput")]
        private IWebElement TextBoxName;

        [FindsBy(How = How.CssSelector, Using = "input[alt*='Пошук']")]
        private IWebElement Search;

        [FindsBy(How = How.CssSelector, Using = ".td1 a")]
        private IWebElement BookAuthor;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Покласти на ')]")]
        private IWebElement EShelf;

        [FindsBy(How = How.CssSelector, Using = "input[type='image']")]
        private IWebElement SubmitEShelf;

        [FindsBy(How = How.CssSelector, Using = "b[style]")]
        private IWebElement CatalogMessage;

        [FindsBy(How = How.XPath, Using = "//option[text()='Періодика']")]
        private IWebElement Periodic;


        public string GetBookAuthor() => BookAuthor.Text;

        public string GetCatalogMessage() => CatalogMessage.Text;

        public Catalog GoToCatalog()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(ToCatalog));
            ToCatalog.Click();

            return this;
        }

        public Catalog EnterBookName(string Name)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(TextBoxName));
            TextBoxName.SendKeys(Name);

            return this;
        }

        public Catalog SubmitSearch()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(Search));
            Search.Click();

            return this;
        }

        public Catalog SelectBookWithName(string Name)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//a[contains(text(), '{Name}')]")));
            driver.FindElement(By.XPath($"//a[contains(text(), '{Name}')]")).Click();

            return this;
        }

        public Catalog PutBookOnEShelf()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(EShelf));
            EShelf.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(SubmitEShelf));
            SubmitEShelf.Click();

            return this;
        }

        public Catalog SelectPeriodic()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(Periodic));
            Periodic.Click();

            return this;
        }
    }
}
