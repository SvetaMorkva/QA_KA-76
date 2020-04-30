using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Lab2
{
    [TestFixture]
    public class Test_LoggedInFeatures
    {
        public ChromeDriver driver;
        public WebDriverWait wait;

        private string testingEmail = "reloho4213@whmailtop.com";
        private string testingPass = "sepiajet";
        private string testingAccountUrl = "https://crm.zoho.eu/crm/org20070584675/";


        private string taskToSearch = "";

        [OneTimeSetUp]
        public void Initialize()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-application-cache"); // to disable cache

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://accounts.zoho.eu/signin?servicename=ZohoHome&signupurl=https://www.zoho.com/signup.html");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        [Test, Order(1)]
        public void LoginWindow_ShouldLogin()
        {
            //arange
            IWebElement loginLineEdit = driver.FindElement(By.Id("login_id"));
            IWebElement nextButton = driver.FindElement(By.Id("nextbtn"));
            IWebElement passwordLineEdit = driver.FindElement(By.Id("password"), 10);

            //act
            loginLineEdit.SendKeys(testingEmail);
            nextButton.Click();
            wait.Until(d => passwordLineEdit.Displayed && passwordLineEdit.Enabled);
            passwordLineEdit.SendKeys(testingPass);
            nextButton.Click();

            //assert
            string userEmail = driver.FindElement(By.Id("ztb-user-id"), 10).GetAttribute("ztooltip");
            Assert.AreEqual(testingEmail, userEmail, "Couldn't login");
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

            driver.Navigate().GoToUrl(testingAccountUrl + "tab/Activities/create?sub_module=Tasks");
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

            IWebElement subjectInput = driver.FindElement(By.Id("Crm_Tasks_SUBJECT"), 5);
            IWebElement dueDateInput = driver.FindElement(By.Id("Crm_Tasks_DUEDATE"), 5);
            IWebElement dueDateLabelDummy = driver.FindElement(By.Id("Crm_Tasks_DUEDATE_label"), 5);
            IWebElement contactInput = driver.FindElement(By.Id("Crm_Tasks_CONTACTID"), 5);
            IWebElement saveBtn = driver.FindElement(By.Id("saveTasksBtn"), 5);

            //act
            subjectInput.SendKeys(taskToSearch);
            dueDateInput.SendKeys(dateToString);
            dueDateLabelDummy.Click();
            contactInput.Click();
            IWebElement contactUIList = driver.FindElement(By.XPath($"//ul[@class=\"ui-menu ui-widget ui-widget-content ui-autocomplete ui-front lookupFieldULlist\"]/li/a/span[text()=\"{contact}\"]"), 5);
            wait.Until(dr => contactUIList.Displayed);
            contactUIList.Click();
            saveBtn.Click();

            //assert
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            string subjectLabel = driver.FindElement(By.Id("subvalue_SUBJECT"), 10).Text;
            string dueLabel = driver.FindElement(By.Id("subvalue_DUEDATE"), 5).Text;
            string contactLabel = driver.FindElement(By.Id("subvalue_CONTACTID"), 5).Text;
            Assert.IsTrue(subjectLabel == taskToSearch, "Subject's name do not match");
            Assert.IsTrue(dueLabel == dateToString, "Due date do not match");
            Assert.IsTrue(contactLabel == contact.TrimEnd(), "Contacts do not match");
        }

        [Test, Order(3)]
        public void Search_ShouldDisplaySearchResult()
        {
            //arrange
            System.Threading.Thread.Sleep(8000); // wait for task to create
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(testingAccountUrl + "tab/Activities");
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));


            //act
            ReadOnlyCollection<IWebElement> tasksList = driver.FindElements(By.XPath("//ul[@id=\"RelatedTo_Container\"]/li/div/div/div/span/a/span[@id=\"Subject\"]"));

            //assert
            bool taskFound = false;
            string actualTaskName = "";
            foreach(var task in tasksList)
            {
                if(task.Text == taskToSearch)
                {
                    actualTaskName = task.Text;
                    taskFound = true;
                }
            }

            Assert.IsTrue(taskFound, $"Task wasn't found: expected:{taskToSearch}, got: {actualTaskName}");
        }

        [Test, Order(4)]
        public void Delete_ShouldDeleteTask()
        {
            //arange
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(testingAccountUrl + "tab/Activities");
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            IWebElement taskToDelete = null;
            IWebElement customizeTools = null;
            IWebElement deleteBtn = null;
            IWebElement popUpDelete = null;

            System.Threading.Thread.Sleep(2000);
            //act  //ul[@id="RelatedTo_Container"]/li/div/div/div/span/a[span[@title="Test Task (ZUPG2)"]]
            taskToDelete = driver.FindElement(By.XPath($"//ul[@id=\"RelatedTo_Container\"]/li/div/div/div/span/a[span[@title=\"{taskToSearch}\"]]"), 10);
            taskToDelete.Click();
            customizeTools = driver.FindElement(By.Id("CustomizeTools"), 10); 
            customizeTools.Click();

            deleteBtn = driver.FindElement(By.XPath("//a[@name=\"Delete2\"]"), 10);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", deleteBtn);

            System.Threading.Thread.Sleep(2000);
            popUpDelete = driver.FindElement(By.Id("deleteButton"), 10);
            popUpDelete.Click();

            System.Threading.Thread.Sleep(5000);

            //assert
            bool taskFound = false;
            ReadOnlyCollection<IWebElement> tasksList = driver.FindElements(By.XPath("//ul[@id=\"RelatedTo_Container\"]/li/div/div/div/span/a/span[@id=\"Subject\"]"));
            foreach (var task in tasksList)
            {
                if (task.Text == taskToSearch)
                {
                    taskFound = true;
                }
            }

            Assert.IsFalse(taskFound, "Task wasn't deleted");

        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
