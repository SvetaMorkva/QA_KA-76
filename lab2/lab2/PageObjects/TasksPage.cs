using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using lab2.Utils;
using System.Drawing;

namespace lab2.PageObjects
{
    public class TasksPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public TasksPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            driver.Manage().Window.Size = new Size(800, 400);
        }

        [FindsBy(How = How.CssSelector, Using = "button[data-button-use='primary']")]
        public IWebElement createTaskButton;

        [FindsBy(How = How.CssSelector, Using = "input[data-selenium-test='property-input-hs_task_subject']")]
        public IWebElement taskTittleField;

        [FindsBy(How = How.CssSelector, Using = "button[data-selenium-test='CreateTaskSidebar__save-btn']")]
        public IWebElement createButton;

        [FindsBy(How = How.CssSelector, Using = "a[data-selenium-test='task-subject-cell__link']>span>span>span")]
        public IList<IWebElement> tasksElemsList;

        [FindsBy(How = How.CssSelector, Using = "a[data-selenium-test='task-subject-cell__link']>span>span>span")]
        public IWebElement mostRecentTask;

        [FindsBy(How = How.CssSelector, Using = "input[data-selenium-test='list-search-input']")]
        public IWebElement searchTasksField;

        public TasksPage GoToPage()
        {
            HomePage homeObj = new HomePage(driver);
            homeObj.GoToPage();
            homeObj.GoToTasksPage();
            return this;
        }

        public TasksPage CreateTask(string taskTittle)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(createTaskButton));
            createTaskButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(taskTittleField));
            taskTittleField.SendKeys(taskTittle);
            return this;
        }

        public TasksPage SerchForTask(string taskTittle)
        {
            searchTasksField.SendKeys(taskTittle);
            System.Threading.Thread.Sleep(1500);
            return this;
        }

        public TasksPage clickCreate() // when creating a task once done inputing task tittle
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(createButton));
            createButton.Click();
            return this;
        }

        public List<string> GetAllTasksList()
        {
            System.Threading.Thread.Sleep(3000);
            IWebElement[] tasksElems = tasksElemsList.ToArray();
            UtilsSelenium u = new UtilsSelenium();
            List<string> result = u.GetAllElemsList(tasksElems);
            return result;
        }
    }
}
