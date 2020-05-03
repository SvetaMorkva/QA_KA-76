using LabWork3.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace LabWork3
{
    [TestFixture]
    public class LogEventsTests
    {
        private IWebDriver driver;


        [SetUp]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

        }

        [Test]
        public void Test_Log_Meeting_Should_Appear_InList()
        {
            // arrange
            var loginPage = new LoginPage(driver);
            var contact = loginPage
                .LoadLoginPage()
                .Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2")
                .OpenContactsList()
                .OpenContactPage(851);
            String meetingDescription = "Meeting Descripti1on";
            int loggedEventsBefore = contact.GetAllEvents().Count;

            // act
            contact = contact.LogMeeting(meetingDescription);

            // assert
            int loggedEventsAfter = contact.GetAllEvents().Count;
            Assert.AreEqual(1, loggedEventsAfter - loggedEventsBefore);
        }

        [Test]
        public void Test_Log_Call_Should_Appear_InList()
        {
            // arrange
            var loginPage = new LoginPage(driver);
            var contact = loginPage
                .LoadLoginPage()
                .Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2")
                .OpenContactsList()
                .OpenContactPage(851);
            String meetingDescription = "Meeting Descripti1on";
            int loggedEventsBefore = contact.GetAllEvents().Count;

            // act
            contact = contact.LogCall(meetingDescription);

            // assert
            int loggedEventsAfter = contact.GetAllEvents().Count;
            Assert.AreEqual(1, loggedEventsAfter - loggedEventsBefore);
        }

        [Test]
        public void Test_Log_Email_Should_Appear_InList()
        {
            // arrange
            var loginPage = new LoginPage(driver);
            var contact = loginPage
                .LoadLoginPage()
                .Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2")
                .OpenContactsList()
                .OpenContactPage(851);
            String meetingDescription = "Meeting Descripti1on";
            int loggedEventsBefore = contact.GetAllEvents().Count;

            // act
            contact = contact.LogEmail(meetingDescription);

            // assert
            int loggedEventsAfter = contact.GetAllEvents().Count;
            Assert.AreEqual(1, loggedEventsAfter - loggedEventsBefore);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

    }

}
