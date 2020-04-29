using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace lab2
{
    public class GeneralTests
    {
        private IWebDriver driver;
        private readonly string email = "olha.pashnieva@gmail.com";
        private readonly string password = "QALab123456";

        private readonly string randomStr = Path.GetRandomFileName().Replace(".", "");
        // private WebDriverWait waiterVar;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://app.hubspot.com/login");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            // waiterVar = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            // login to HubSpot
            driver.FindElement(By.Id("username")).SendKeys(email);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("loginBtn")).Submit();
        }

        [Test]
        public void CreateTask()
        {
            // go to Tasks page
            driver.FindElement(By.Id("nav-primary-sales-branch")).Click();
            driver.FindElement(By.Id("nav-secondary-tasks")).Click();

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

        [Test]
        public void ChangeProfileName()
        {
            driver.FindElement(By.Id("navSetting")).Click(); // go to Settings page
            driver.FindElement(By.CssSelector("a[data-selenium-id='Basic info']")).Click();
            driver.FindElement(By.CssSelector("span[class='UIIcon__IconContent-sc-1ngbkfp-0 hJvPJd']")).Click();

            string randomName = randomStr;
            string randomSurname = randomStr + "Surname";
            string fullRandomName = randomName + " " + randomSurname;

            driver.FindElement(By.CssSelector("input[data-test-id='first-name']")).Clear();
            driver.FindElement(By.CssSelector("input[data-test-id='last-name']")).Clear();

            driver.FindElement(By.CssSelector("input[data-test-id='first-name']")).SendKeys(randomName);
            driver.FindElement(By.CssSelector("input[data-test-id='last-name']")).SendKeys(randomSurname);

            driver.FindElement(By.CssSelector("button[data-test-id='save-name']")).Click();

            System.Threading.Thread.Sleep(1000);
            string newName = driver.FindElement(By.CssSelector("span[data-test-id='name']")).GetAttribute("innerHTML");

            Assert.AreEqual(fullRandomName, newName);
        }
    }
}