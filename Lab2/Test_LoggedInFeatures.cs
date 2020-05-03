using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using Lab2.Pages;



namespace Lab2
{
    [TestFixture]
    public class Test_LoggedInFeatures
    {
        public ChromeDriver driver;
        public WebDriverWait wait;
        public IJavaScriptExecutor executor;

        private string testingEmail = "liniha1437@whmailtop.com";
        private string testingPass = "sepiajet";
        private string testingAccountUrl = "https://crm.zoho.com/crm/org714368552/";


        private string taskToSearch = "";

        [OneTimeSetUp]
        public void Initialize()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-application-cache"); // to disable cache

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            executor = (IJavaScriptExecutor)driver;
        }

        [Test, Order(1)]
        public void LoginWindow_ShouldLogin()
        {
            //arange
            LogInPage logInPage = new LogInPage(driver, wait);
            logInPage.GoToUrl();
            //act

            logInPage.LogIn(testingEmail, testingPass);

            //assert
            System.Threading.Thread.Sleep(3000);
            Assert.AreEqual(testingEmail, logInPage.EmailAfterLogin, "Couldn't login");
        }

        [Test, Order(2)]
        public void TaskCreation_ShouldCreateAndDisplayTask()
        {
            //arrange
            DateTime dateNow = DateTime.Now;
            Random rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            taskToSearch = "Test Task (" + new string(Enumerable.Repeat(chars, 5).Select(s => s[rnd.Next(s.Length)]).ToArray()) + ")";

            dateNow.AddDays(5);
            string dateToString = dateNow.ToString("MMM d, yyyy");
            List<string> contactList = new List<string> { "Kris Marrier (Sample) ", "Sage Wieser (Sample) ", "Mitsue Tollner (Sample) ", "James Venere (Sample) " };
            string contact = contactList[rnd.Next(contactList.Count)];

            CreateTaskPage taskCreationPage = new CreateTaskPage(driver, wait);
            taskCreationPage.GoToUrl(testingAccountUrl + "tab/Activities/create?sub_module=Tasks");

            //act
            taskCreationPage.CreateTask(taskToSearch, dateToString, contact);
            
            //assert
            System.Threading.Thread.Sleep(5000); // wait for task to create
            Assert.AreEqual(taskToSearch , taskCreationPage.subjectLabelValue, "Subject's name do not match");
            Assert.AreEqual(dateToString, taskCreationPage.dueLabelValue, "Due date do not match");
            Assert.AreEqual(contact.TrimEnd(), taskCreationPage.contactLabelValue, "Contacts do not match");
        }

        [Test, Order(3)]
        public void Search_ShouldDisplaySearchResult()
        {
            //arrange
            System.Threading.Thread.Sleep(8000); // wait for task to create and appear on page (thanks, zoho)
            ActivitiesPage activitiesPage = new ActivitiesPage(driver, wait);
            activitiesPage.GoToUrl(testingAccountUrl + "tab/Activities");

            //act
            bool found = activitiesPage.SearchForTask(taskToSearch);

            //assert
            Assert.IsTrue(found, $"Task wasn't found: expected:{taskToSearch}");
        }

        [Test, Order(4)]
        public void Delete_ShouldDeleteTask()
        {
            //arange
            ActivitiesPage activitiesPage = new ActivitiesPage(driver, wait);
            activitiesPage.GoToUrl(testingAccountUrl + "tab/Activities");

            System.Threading.Thread.Sleep(2000);
            //act
            activitiesPage.DeleteTask(taskToSearch);
            System.Threading.Thread.Sleep(5000);

            //assert
            bool found = activitiesPage.SearchForTask(taskToSearch);
            Assert.IsFalse(found, "Task wasn't deleted");

        }

        [Test, Order(5)]
        public void ProfileEdit_ShouldEditPersonalData()
        {
            //arrange
            string fName = "fNmame";
            string sName = "sName";
            string nName = "nName";
            ProfilePage profilePage = new ProfilePage(driver, wait);
            profilePage.GoToUrl();

            //act
            System.Threading.Thread.Sleep(2000);
            profilePage.EditProfile(fName, sName, nName);
            System.Threading.Thread.Sleep(2000);

            //assert
            Assert.AreEqual((fName + " " + sName), profilePage.fullNameLabelValue, "Full name incorrect");
            Assert.AreEqual(nName, profilePage.nickNameLabelValue, "Nick name incorrect");
        }


        [Test, Order(6)]
        public void SmartChat_ShouldOpenTab()
        {
            //arrange
            HomePage homePage = new HomePage(driver, wait);
            homePage.GoToUrl(testingAccountUrl + "tab/Home/begin");

            //act
            homePage.OpenSmartChat();

            //assert
            bool opened = homePage.IsSmartChatOpened();
            Assert.IsTrue(opened, "Smart chat not opened");
        }

        [Test, Order(7)]
        public void Status_ShouldChangeAccountStatus()
        {
            //arrange
            HomePage homePage = new HomePage(driver, wait);
            homePage.GoToUrl(testingAccountUrl + "tab/Home/begin");
            string status = "test status " + DateTime.Now.ToString("MMM d, yyyy");

            //act
            homePage.OpenStatusBar();
            homePage.ChangeStatus(status);
            //assert
            Assert.AreEqual(status, homePage.statusValue, "Status not set");
        }


        [OneTimeTearDown]
        public void CleanUp()
        {
            var tmp = driver.Manage().Cookies.AllCookies;
            driver.Quit();
        }
    }
}
