using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab2
{
    public class TasksTests
    {
        private IWebDriver driver;
        private readonly string email = "olha.pashnieva@gmail.com";
        private readonly string password = "QALab123456";

        private readonly string randomStr = Path.GetRandomFileName().Replace(".", "");

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

            // go to Tasks page
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Id("nav-primary-sales-branch")).Click();
            driver.FindElement(By.Id("nav-secondary-tasks")).Click();
        }

        [TearDown]
        public void quitDriver()
        {
            driver.Quit();
        }

        [Test]
        public void CreateTask()
        {
            // create a task
            By createTaskButton = By.CssSelector("button[data-selenium-test='TasksHeaderView__add-task-btn']");
            By taskTitleInput = By.CssSelector("input[data-selenium-test='property-input-hs_task_subject']");
            By createButton = By.CssSelector("button[data-selenium-test='CreateTaskSidebar__save-btn']");

            driver.FindElement(createTaskButton).Click();
            driver.FindElement(taskTitleInput).SendKeys(randomStr);
            driver.FindElement(createButton).Click();

            // verify task is created
            System.Threading.Thread.Sleep(2000); // a task is added in a few seconds
            By newestTaskTittle = By.CssSelector("a[data-selenium-test='task-subject-cell__link']>span>span>span");
            string laskTastTittle = driver.FindElement(newestTaskTittle).GetAttribute("textContent");

            Assert.AreEqual(randomStr, laskTastTittle);
        }

        private List<string> getAllTasksNames()
        {
            By tasksSelector = By.CssSelector("a[data-selenium-test='task-subject-cell__link']>span>span>span");
            IWebElement[] tasksElems = driver.FindElements(tasksSelector).ToArray();

            var tasksList = new List<string>();

            foreach (IWebElement taskElem in tasksElems)
            {
                tasksList.Add(taskElem.GetAttribute("textContent"));
            }
            return tasksList;
        }

        [Test]
        public void CheckSearchByName()
        {
            Random rand = new Random();

            List<string> tasksList = getAllTasksNames();
            int index = rand.Next(0, tasksList.Count);
            string taskToSearchFor = tasksList[index];

            driver.FindElement(By.CssSelector("input[data-selenium-test='list-search-input']")).SendKeys(taskToSearchFor);
            System.Threading.Thread.Sleep(1500);
            string searchResult = driver.FindElement(By.CssSelector("a[data-selenium-test='task-subject-cell__link']>span>span>span")).GetAttribute("textContent");

            Assert.AreEqual(taskToSearchFor, searchResult);
        }

    }
}