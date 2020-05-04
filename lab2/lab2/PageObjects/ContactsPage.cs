using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2.Utils;

namespace lab2.PageObjects
{
    public class ContactsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public ContactsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [FindsBy(How = How.CssSelector, Using = "button[data-button-use='primary']")]
        public IWebElement createContactButton;

        [FindsBy(How = How.CssSelector, Using = "input[data-selenium-test='property-input-email']")]
        public IWebElement contactEmailField;

        [FindsBy(How = How.CssSelector, Using = "button[data-selenium-test='base-dialog-confirm-btn']")]
        public IWebElement createButton;

        [FindsBy(How = How.CssSelector, Using = "a[class='private-link uiLinkWithoutUnderline uiLinkDark text-left truncate-text']")]
        public IList<IWebElement> contactsElemsList;

        [FindsBy(How = How.CssSelector, Using = "a[class='private-link uiLinkWithoutUnderline uiLinkDark text-left truncate-text']")]
        public IWebElement mostRecentContact;

        [FindsBy(How = How.CssSelector, Using = "i18n-string[data-key='customerDataProperties.PropertyInput.errorMessageInvalidEmail']")]
        public IList<IWebElement> invalidEmailErrorMessage;

        [FindsBy(How = How.CssSelector, Using = "span[class='private-checkbox__indicator']")]
        public IList<IWebElement> checkSelector;

        [FindsBy(How = How.CssSelector, Using = "span[data-icon-name='delete']")]
        public IWebElement deleteSelectedContactsButton;

        [FindsBy(How = How.CssSelector, Using = "textarea[data-selenium-test='delete-dialog-match']")]
        public IWebElement deleteDialogMatch;

        [FindsBy(How = How.CssSelector, Using = "button[data-selenium-test='delete-dialog-confirm-button']")]
        public IWebElement deleteContactConfirmButton;

        public ContactsPage GoToPage()
        {
            HomePage homeObj = new HomePage(driver);
            homeObj.GoToPage();
            homeObj.GoToContactsPage();
            return this;
        }

        public ContactsPage CreateContactViaEmail(string email)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(createContactButton));
            createContactButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(contactEmailField));
            contactEmailField.SendKeys(email);
            return this;
        }

        public ContactsPage clickCreate()
        {
            // wait.Until(ExpectedConditions.ElementToBeClickable(createButton));
            System.Threading.Thread.Sleep(2000);
            createButton.Click();
            System.Threading.Thread.Sleep(3000);
            return this;
        }

        public ContactsPage checkContactToDelete(int index)
        {
            IWebElement[] checksElems = checkSelector.ToArray();
            checksElems[index + 1].Click();
            return this;
        }

        public ContactsPage DeleteSelectedContact()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(deleteSelectedContactsButton));
            deleteSelectedContactsButton.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(deleteDialogMatch));
            deleteDialogMatch.SendKeys("1");

            wait.Until(ExpectedConditions.ElementToBeClickable(deleteContactConfirmButton));
            deleteContactConfirmButton.Click();
            return this;
        }

        public List<string> GetAllContactsList()
        {
            System.Threading.Thread.Sleep(3000);
            IWebElement[] contactsElems = contactsElemsList.ToArray();
            UtilsSelenium u = new UtilsSelenium();
            List<string> result = u.GetAllElemsList(contactsElems);
            return result;
        }
    }
}
