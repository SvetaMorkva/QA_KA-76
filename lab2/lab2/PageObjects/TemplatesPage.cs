using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.PageObjects
{
    public class TemplatesPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public TemplatesPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            driver.Manage().Window.Size = new Size(800, 400);
        }

        [FindsBy(How = How.CssSelector, Using = "button[class='uiButton private-button private-button--secondary private-button--default template-index-new-folder-button private-button--non-responsive private-button--non-link']")]
        public IWebElement createFolderButton;

        [FindsBy(How = How.CssSelector, Using = "button[class='uiButton private-button private-button--primary private-button--default private-button--non-link']")]
        public IWebElement addFolderButton;

        [FindsBy(How = How.CssSelector, Using = "input[class='form-control private-form__control']")]
        public IWebElement folderNameField;

        [FindsBy(How = How.CssSelector, Using = "a[data-selenium-test='sales-content-index-table-folder-link']")]
        public IWebElement newestFolderElem;

        public TemplatesPage GoToPage()
        {
            HomePage homeObj = new HomePage(driver);
            homeObj.GoToPage();
            homeObj.GoToTemplatesPage();
            return this;
        }

        public TemplatesPage CreateFolder(string folderName)
        {
            System.Threading.Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementToBeClickable(createFolderButton));
            createFolderButton.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(folderNameField));
            folderNameField.SendKeys(folderName);

            return this;
        }

        public TemplatesPage ClickAdd()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(addFolderButton));
            addFolderButton.Click();
            return this;
        }

        public string GetNewestFolderName()
        {
            return newestFolderElem.GetAttribute("textContent");
        }

    }
}
