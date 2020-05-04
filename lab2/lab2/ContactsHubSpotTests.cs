using lab2.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab2
{
    public class ContactsTests
    {
        private IWebDriver driver;
        private readonly string randomStr = Path.GetRandomFileName().Replace(".", "");
        private ContactsPage contactsPageObj;

        Random rand = new Random();

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            contactsPageObj = new ContactsPage(driver);
            contactsPageObj.GoToPage();
        }

        [TearDown]
        public void quitDriver()
        {
            driver.Quit();
        }

        [Test]
        public void CreateContactTroughEmailOnly()
        {
            string contactEmail = randomStr + "@me.com";
            contactsPageObj.CreateContactViaEmail(contactEmail);
            contactsPageObj.clickCreate();

            // verify contact is created
            System.Threading.Thread.Sleep(3000);
            driver.Navigate().GoToUrl("https://app.hubspot.com/contacts");
            List<string> emailsList = contactsPageObj.GetAllContactsList();

            Assert.IsTrue(emailsList.Contains(contactEmail));
        }

        [Test]
        public void AttemptCreatingContactWithInvalidEmail()
        {
            contactsPageObj.CreateContactViaEmail(randomStr);
            contactsPageObj.clickCreate();
            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(1, contactsPageObj.invalidEmailErrorMessage.Count());
        }

        [Test]
        public void DeleteRandomContact()
        {
            List<string> emailsList = contactsPageObj.GetAllContactsList();
            int index;
            if (emailsList.Count == 0)
            {
                Assert.Pass();
            }
            else
            {
                index = rand.Next(0, emailsList.Count - 1);
                string emailToDelete = emailsList[index];

                // delete contact with the index
                contactsPageObj.checkContactToDelete(index);
                contactsPageObj.DeleteSelectedContact();

                List<string> emailsListAfterDel = contactsPageObj.GetAllContactsList();
                Assert.IsFalse(emailsListAfterDel.Contains(emailToDelete));
            }
        }


    }
}