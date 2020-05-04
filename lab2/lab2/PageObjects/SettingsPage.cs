using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;

namespace lab2.PageObjects
{
    public class SettingsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public SettingsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Window.Size = new Size(800, 400);
        }

        // basic info section related elements
        [FindsBy(How = How.CssSelector, Using = "a[data-selenium-id='Basic info']")]
        public IWebElement basicInfoSection;

        [FindsBy(How = How.XPath, Using = "//span[@data-test-id='edit-name']/span")]
        public IWebElement editProfileNameButton;

        [FindsBy(How = How.CssSelector, Using = "input[data-test-id='first-name']")]
        public IWebElement firstNameField;

        [FindsBy(How = How.CssSelector, Using = "input[data-test-id='last-name']")]
        public IWebElement lastNameField;

        [FindsBy(How = How.CssSelector, Using = "button[data-test-id='save-name']")]
        public IWebElement saveProfileNameButton;

        [FindsBy(How = How.CssSelector, Using = "span[data-test-id='name']")]
        public IWebElement profileNameStr;

        // account defaults section related elements
        [FindsBy(How = How.CssSelector, Using = "a[data-selenium-id = 'Account defaults']")]
        public IWebElement accountDefaultsSection;

        [FindsBy(How = How.CssSelector, Using = "input[class='form-control private-form__control']")]
        public IWebElement accountNameField;

        [FindsBy(How = How.CssSelector, Using = "button[data-test-id='save-footer-confirm-btn']")]
        public IWebElement saveChangesButton;

        public SettingsPage GoToPage()
        {
            HomePage homeObj = new HomePage(driver);
            homeObj.GoToPage();
            homeObj.GoToSettingsPage();
            return this;
        }

        public SettingsPage EnterNewProfileName(string name, string surname)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(firstNameField));
            wait.Until(ExpectedConditions.ElementToBeClickable(lastNameField));

            firstNameField.Clear();
            lastNameField.Clear();

            firstNameField.SendKeys(name);
            lastNameField.SendKeys(surname);

            return this;
        }

        public SettingsPage EnterNewAccountName(string accName)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(accountNameField));
            accountNameField.Clear();
            accountNameField.SendKeys(accName);
            return this;
        }

        public string GetProfileName()
        {
            return profileNameStr.GetAttribute("innerHTML");
        }

        public string GetAccountName()
        {
            return accountNameField.GetAttribute("value");
        }
    }
}
