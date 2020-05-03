using LabWork3.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace LabWork3
{
    [TestFixture]
    public class ContactsTests
    {
        private IWebDriver driver;

        [SetUp]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test_Add_Contact_Redirect_NewContactPage()
        {
            // arrange
            var loginPage = new LoginPage(driver);
            var contactsList = loginPage
                .LoadLoginPage()
                .Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2")
                .OpenContactsList();
            int index = 61;

            // /act
            var contact = contactsList.AddContact($"Test{index}", $"User{index}", $"test{index}@email.com", "Front-End developer");

            //assert
            String[] urlParametres = contact.GetCurrntUrl().Split('/');
            Assert.AreEqual("contact", urlParametres[urlParametres.Length - 2]);
        }


        [Test]
        public void Test_Delete_Contact_Should_Disappear_FromList()
        {
            // arrange
            var loginPage = new LoginPage(driver);
            var contactsList = loginPage
                .LoadLoginPage()
                .Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2")
                .OpenContactsList();
            int amount2Delete = 1;

            // act
            int amountBefore = contactsList.CountContacts();
            contactsList = contactsList.DeleteContacts(amount2Delete);
            int amountAfter = contactsList.CountContacts();

            // assert
            Assert.AreEqual(amountBefore - amountAfter, amount2Delete);
        }



        [Test]
        public void Test_Add_Task_Should_Appeat_InList()
        {
            // arrange
            var loginPage = new LoginPage(driver);
            var contact = loginPage
                .LoadLoginPage()
                .Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2")
                .OpenContactsList()
                .OpenContactPage(851);
            int index = 21;
            string taskTitle = $"Test Task {index}";

            // act
            contact = contact.AddTask(taskTitle, $"Test Description {index}");

            // assert
            var taskTitles = contact.GetAllTasks();
            Assert.AreEqual(taskTitles[0].Text, taskTitle);
        }



        [Test]
        public void Test_Delete_Task_Should_Disapear_FromList()
        {
            // arrange
            var loginPage = new LoginPage(driver);
            var contact = loginPage
                .LoadLoginPage()
                .Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2")
                .OpenContactsList()
                .OpenContactPage(851);
            int amount2Delete = 1;
            int tasksBefore = contact.GetAllTasks().Count;

            // act
            contact.DeleteTasks(amount2Delete);

            // assert
            int tasksAfter = contact.GetAllTasks().Count;
            Assert.AreEqual(tasksBefore - tasksAfter, amount2Delete);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
