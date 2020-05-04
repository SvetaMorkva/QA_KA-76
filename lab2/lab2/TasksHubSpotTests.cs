using lab2.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;

namespace lab2
{
    public class TasksTests
    {
        private IWebDriver driver;
        private readonly string randomStr = Path.GetRandomFileName().Replace(".", "");
        private TasksPage tasksPageObj;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            tasksPageObj = new TasksPage(driver);
            tasksPageObj.GoToPage();
        }

        [TearDown]
        public void quitDriver()
        {
            driver.Quit();
        }

        [Test]
        public void CreateTask()
        {
            tasksPageObj.CreateTask(randomStr);
            tasksPageObj.clickCreate();
            System.Threading.Thread.Sleep(2000); // a task is added in a few seconds

            string laskTastTittle = tasksPageObj.mostRecentTask.GetAttribute("textContent");

            Assert.AreEqual(randomStr, laskTastTittle);
        }


        [Test]
        public void CheckSearchByName()
        {
            Random rand = new Random();

            List<string> tasksList = tasksPageObj.GetAllTasksList();
            int index;

            if (tasksList.Count == 0)
            {
                Assert.Pass();
            }
            else
            {
                index = rand.Next(0, tasksList.Count - 1);
                string taskToSearchFor = tasksList[index];
                tasksPageObj.SerchForTask(taskToSearchFor);
                string searchResult = tasksPageObj.mostRecentTask.GetAttribute("textContent");
                Assert.AreEqual(taskToSearchFor, searchResult);
            }
        }

    }
}