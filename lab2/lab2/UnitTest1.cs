using NUnit.Framework;
using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace lab2
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly string email = "olha.pashnieva@gmail.com";
        private readonly string password = "QALab123456";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://app.hubspot.com/login");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            // login to HubSpot
            driver.FindElement(By.Id("username")).SendKeys(email);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("loginBtn")).Submit();
        }

        [Test]
        public void CreateATask()
        {
            // go to Tasks page
            driver.FindElement(By.Id("nav-primary-sales-branch")).Click();
            driver.FindElement(By.Id("nav-secondary-tasks")).Click();

            // create a task
            By createTaskButton = By.CssSelector("button[data-selenium-test='TasksHeaderView__add-task-btn']");
            By taskTitleInput = By.CssSelector("input[data-selenium-test='property-input-hs_task_subject']");
            By createButton = By.CssSelector("button[data-selenium-test='CreateTaskSidebar__save-btn']");

            string taskTittle = Path.GetRandomFileName().Replace(".", ""); // get random string for the task name

            driver.FindElement(createTaskButton).Click();
            driver.FindElement(taskTitleInput).SendKeys(taskTittle);
            driver.FindElement(createButton).Click();

            // verify task is created
            System.Threading.Thread.Sleep(2000); // a task is added in a few seconds
            By newestTaskTittle = By.CssSelector("a[data-selenium-test='task-subject-cell__link']>span>span>span");
            string laskTastTittle = driver.FindElement(newestTaskTittle).GetAttribute("textContent");

            Assert.AreEqual(taskTittle, laskTastTittle);
        }
    }
}