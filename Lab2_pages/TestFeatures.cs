using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using Lab2_pages.Pages;

namespace Lab2_pages
{
    [TestFixture]
    class TestFeatures
    {

        string myEmail = "l.khylenko@gmail.com";
        string myPassword = "!Q@W#E";

        private IWebDriver driver;

        [SetUp]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test_Login_Should_Redirect_Homepage()
        {
            // arrange
            var loginPage = new LoginPage(driver);

            // act
            var new_dashboard = loginPage
                .LoadLoginPage()
                .Login(myEmail, myPassword);
            System.Threading.Thread.Sleep(1000);
            // assert
            Assert.AreEqual("https://app.knackbusiness.com/dashboard", new_dashboard.GetCurrntUrl());
        }

        [Test]
        public void Test_Login_WithoutFilling_ShouldMadeError()
        {
            // arrange
            var loginPage = new LoginPage(driver);

            // act
            var new_dashboard = loginPage
                .LoadLoginPage()
                .Login("", "");
            System.Threading.Thread.Sleep(1000);
            // assert
            var errorMsg = driver.FindElement(By.CssSelector(".toast"));
            Assert.IsTrue(errorMsg.Displayed);
        }

        [Test]
        public void Test_Add_Client_Should_Show_ClientsListPage()
        {
            // arrange
            var loginPage = new LoginPage(driver);
            var clientsList = loginPage
                .LoadLoginPage()
                .Login(myEmail, myPassword)
                .OpenClientsList();

            string nameIndex = "TEST COMPANY";
            // act
            var company = clientsList.AddClient(nameIndex);

            // assert
            IWebElement client = driver.FindElement(By.XPath("//*[@id='clientList']/table/thead/tr/th[1]"));
            Assert.IsTrue(client.Displayed);
        }

        [Test]
        public void Test_Add_Project_Should_Show_ProjectsListPage()
        {
            // arrange
            var loginPage = new LoginPage(driver);
            var projectsList = loginPage
                .LoadLoginPage()
                .Login(myEmail, myPassword)
                .OpenProjectsList();

            // act
            string nameDes = "TEST DESCRIPTION";
            var company = projectsList.AddProject(nameDes);

            
            // assert
            IWebElement project = driver.FindElement(By.XPath("//*[@id='projectViewList']/table/thead/tr/th[1]"));
            Assert.IsTrue(project.Displayed);
        }

        [Test]
        public void Test_Add_Task_Should_Show_TaskDetails()
        {
            // arrange
            var loginPage = new LoginPage(driver);
            var tasksList = loginPage
                .LoadLoginPage()
                .Login(myEmail, myPassword)
                .OpenTasksList();

            // act
            string nameTitle = "TEST TITLE";
            string nameDes = "TEST DESCRIPTION";
            var task = tasksList.AddTask(nameTitle, nameDes);

            // assert
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='taskDetailList']/div/div[2]/ul/li[1]/h5")));
            IWebElement tasks = driver.FindElement(By.XPath("//*[@id='taskDetailList']/div/div[2]/ul/li[1]/h5"));
            Assert.IsTrue(tasks.Displayed);
        }

        [Test]
        public void Test_LogOut_Should_Show_LogIn()
        {
            // arrange
            var loginPage = new LoginPage(driver);
            var logout = loginPage
                .LoadLoginPage()
                .Login(myEmail, myPassword)
                .LogOut();

            // assert
            System.Threading.Thread.Sleep(1000);
            Assert.AreEqual("https://app.knackbusiness.com/login", logout.GetCurrntUrl());
        }

        [Test]
        public void Test_ShortPassword_ShouldWarn()
        {
            // arrange
            var loginPage = new LoginPage(driver);
            var upd = loginPage
                .LoadLoginPage()
                .Login(myEmail, myPassword)
                .UpdPass();

            string newPass = "1234";
            upd.ChangePassword(myPassword, newPass);

            System.Threading.Thread.Sleep(1000);
            // assert
            var passMsg = driver.FindElement(By.CssSelector(".toast"));
            Assert.IsTrue(passMsg.Displayed);

        }

        [Test]
        public void Test_UserInfo_ShouldEqual()
        {
            // arrange
            var loginPage = new LoginPage(driver);
            var upd = loginPage
                .LoadLoginPage()
                .Login(myEmail, myPassword)
                .UserInfo();

            string userinfo = upd.GetUserInformation();
            Assert.AreEqual("vkhlnk", userinfo);


        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
