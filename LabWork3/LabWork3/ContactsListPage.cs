using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LabWork3.Pages
{
    public class ContactsListPage
    {
        private IWebDriver _driver;


        public const string CONTACTS_TABLE_CLASSNAME = "ReactTable";
        public const string PHONE_FIELD_CSS = "input[data-field='phone']";
        public const string EMAIL_FIELD_CSS = "input[data-field='email']";
        public const string JOBTITLE_FIELD_CSS = "input[data-field='jobtitle']";
        public const string FIRSTNAME_FIELD_CSS = "input[data-field='firstname']";
        public const string CREATE_CONTACT_BUTTON_CSS = "button[data-button-use='primary']";
        public const string DELETE_CHECKBOXES_CSS = "span[class='private-checkbox__indicator']";
        public const string DELETE_CONTACTS_BUTTON_CSS = "button[data-selenium-test='bulk-action-delete']";
        public const string DELETE_BUTTON_CSS = "button[data-selenium-test='delete-dialog-confirm-button']";
        public const string CONFIRT_DELETION_TEXTAREA_CSS = "textarea[data-selenium-test='delete-dialog-match']";
        public const string CREATE_BUTTON_CSS = "button[class='uiButton private-button private-button--primary private-button--default private-loading-button private-button--primary private-button--non-link']";

        [FindsBy(How = How.CssSelector, Using = CREATE_CONTACT_BUTTON_CSS)]
        public IWebElement createContactButton;

        [FindsBy(How = How.CssSelector, Using = EMAIL_FIELD_CSS)]
        public IWebElement emailField;

        [FindsBy(How = How.CssSelector, Using = FIRSTNAME_FIELD_CSS)]
        public IWebElement firstnameField;

        [FindsBy(How = How.CssSelector, Using = JOBTITLE_FIELD_CSS)]
        public IWebElement jotTitleField;

        [FindsBy(How = How.CssSelector, Using = PHONE_FIELD_CSS)]
        public IWebElement phoneField;

        [FindsBy(How = How.CssSelector, Using = CREATE_BUTTON_CSS)]
        public IWebElement createButton;

        [FindsBy(How = How.CssSelector, Using = DELETE_CHECKBOXES_CSS)]
        public IList<IWebElement> checkboxes2Delete;

        [FindsBy(How = How.CssSelector, Using = DELETE_CONTACTS_BUTTON_CSS)]
        public IWebElement deleteContacts;

        [FindsBy(How = How.CssSelector, Using = CONFIRT_DELETION_TEXTAREA_CSS)]
        public IWebElement confirmDeleteion;

        [FindsBy(How = How.CssSelector, Using = DELETE_BUTTON_CSS)]
        public IWebElement deleteButton;

        public ContactsListPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public String GetCurrntUrl() => _driver.Url;

        public ContactPage AddContact(String firstName, String lastName, String email, String jobTitle = "", String phoneNumber = "")
        {

            createContactButton.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(EMAIL_FIELD_CSS)));

            emailField.SendKeys(email);
            firstnameField.SendKeys(firstName);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(JOBTITLE_FIELD_CSS)));

            jotTitleField.SendKeys(jobTitle);
            phoneField.SendKeys(phoneNumber);

            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CREATE_BUTTON_CSS)));
            createButton.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector(ContactPage.CONTACT_TITLE_CSS)));

            return new ContactPage(_driver);
        }

        public int CountContacts()
        {
            Thread.Sleep(5000);
            return checkboxes2Delete.Count();
        }

        public ContactsListPage DeleteContacts(int amount2Delete)
        {
            Thread.Sleep(5000);
            if (amount2Delete > checkboxes2Delete.Count())
            {
                throw new Exception("Trying to delete more contacts than exist");
            }

            for (int i = 1; i < amount2Delete + 1; i++)
            {
                checkboxes2Delete[i].Click();
            }
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(DELETE_CONTACTS_BUTTON_CSS)));
            deleteContacts.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CONFIRT_DELETION_TEXTAREA_CSS)));
            confirmDeleteion.SendKeys(amount2Delete.ToString());
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(DELETE_BUTTON_CSS)));
            deleteButton.Click();
            Thread.Sleep(2000);

            return this;
        }

        public ContactPage OpenContactPage(int contactID)
        {
            _driver.Navigate().GoToUrl($"https://app.hubspot.com/contacts/7486179/contact/{contactID}/");
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(ContactPage.CREATE_TASK_BUTTON_CSS)));
            return new ContactPage(_driver);
        }

    }
}
