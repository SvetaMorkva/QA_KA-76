using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Lab_2
{
    public class EShelf
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public EShelf(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Моя е-Полиця')]")]
        private IWebElement ToEShelf;

        [FindsBy(How = How.CssSelector, Using = ".td1[width='21%']")]
        private IWebElement BookName;

        [FindsBy(How = How.CssSelector, Using = "input[type='checkbox']")]
        private IList<IWebElement> EShelfItems;

        [FindsBy(How = How.CssSelector, Using = "input[type='checkbox']")]
        private IWebElement FirstEShelfItem;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Видалити')]")]
        private IWebElement ButtonDelete;

        [FindsBy(How = How.CssSelector, Using = "b[style]")]
        private IWebElement EShelfMessage;


        public string GetBookName() => BookName.Text;

        public EShelf GoToEShelf()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(ToEShelf));
            ToEShelf.Click();

            return this;
        }

        public int CountEShelfItems() => EShelfItems.Count;

        public EShelf DeleteFirstItem()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(FirstEShelfItem));
            FirstEShelfItem.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(ButtonDelete));
            ButtonDelete.Click();

            return this;
        }

        public string GetEShelfMessage() => EShelfMessage.Text;
    }
}
