using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Threading;

namespace Lab2
{
    [TestFixture]
    public class AddNew
    {
        string url = "https://app.knackbusiness.com/login";
        IWebElement clientCompany;
        ChromeDriver driver;
        WebDriverWait wait;

        [SetUp]
        public void Initialize()
        { 
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        [Test]
        public void CreateClient_ShouldAddNewClient()
        {
            driver.FindElement(By.Id("email")).SendKeys("l.khylenko@gmail.com");
            driver.FindElement(By.Id("password")).SendKeys("!Q@W#E");
            driver.FindElement(By.CssSelector(".btn")).Click();
            wait.Until(d => driver.FindElement(By.XPath("//img[@src='https://app.knackbusiness.com/assets/images/nav_clients.png']")));
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//img[@src='https://app.knackbusiness.com/assets/images/nav_clients.png']")).Click();
            Thread.Sleep(3000);
            wait.Until(d => driver.FindElement(By.XPath("//*[@id='slide-out']/ul/li[2]/div/a[2]")));
            driver.FindElement(By.XPath("//*[@id='slide-out']/ul/li[2]/div/a[2]")).Click();

            wait.Until(d => driver.FindElement(By.Id("clientCompany")));
            clientCompany = driver.FindElement(By.Id("clientCompany"));
            clientCompany.SendKeys("new company");

            driver.FindElement(By.CssSelector(".btn.pink.accent-4")).Click();

            wait.Until(d => driver.FindElement(By.CssSelector(".toast")));
            var clientMsg = driver.FindElement(By.CssSelector(".toast"));

            Assert.IsTrue(clientMsg.Displayed);
        }

        [Test]
        public void CreateProject_ShouldAddNewProject()
        {
            driver.FindElement(By.Id("email")).SendKeys("l.khylenko@gmail.com");
            driver.FindElement(By.Id("password")).SendKeys("!Q@W#E");
            driver.FindElement(By.CssSelector(".btn")).Click();
            wait.Until(d => driver.FindElement(By.XPath("//img[@src='https://app.knackbusiness.com/assets/images/nav_projects.png']")));
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//img[@src='https://app.knackbusiness.com/assets/images/nav_projects.png']")).Click();
            wait.Until(d => driver.FindElement(By.XPath("//*[@id='slide-out']/ul/li[5]/div/a[1]")));
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='slide-out']/ul/li[5]/div/a[1]")).Click();

            wait.Until(d => driver.FindElement(By.XPath("//*[@id='modal-content']/div[2]/div[1]/div/input")));
            driver.FindElement(By.XPath("//*[@id='modal-content']/div[2]/div[1]/div/input")).Click();

            wait.Until(d => driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div[2]/div[1]/div/ul/li[6]/span")));
            driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div[2]/div[1]/div/ul/li[6]/span")).Click();

            wait.Until(d => driver.FindElement(By.CssSelector(".ql-editor.ql-blank")));
            driver.FindElement(By.CssSelector(".ql-editor.ql-blank")).SendKeys("new project");

            driver.FindElement(By.CssSelector(".btn.pink.accent-4")).Click();

            wait.Until(d => driver.FindElement(By.CssSelector(".toast")));
            var projMsg = driver.FindElement(By.CssSelector(".toast"));

            Assert.IsTrue(projMsg.Displayed);
        }

        [Test]
        public void CreateTask_ShouldAddNewTask()
        {
            driver.FindElement(By.Id("email")).SendKeys("l.khylenko@gmail.com");
            driver.FindElement(By.Id("password")).SendKeys("!Q@W#E");
            driver.FindElement(By.CssSelector(".btn")).Click();
            wait.Until(d => driver.FindElement(By.XPath("//img[@src='https://app.knackbusiness.com/assets/images/nav_projects.png']")));

            driver.FindElement(By.XPath("//img[@src='https://app.knackbusiness.com/assets/images/nav_projects.png']")).Click();
            wait.Until(d => driver.FindElement(By.XPath("//*[@id='slide-out']/ul/li[5]/div/a[2]")));
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='slide-out']/ul/li[5]/div/a[2]")).Click();

            wait.Until(d => driver.FindElement(By.XPath("//*[@id='modal-content']/div[4]/div[2]/a")));
            driver.FindElement(By.XPath("//*[@id='modal-content']/div[4]/div[2]/a")).Click();
            wait.Until(d => driver.FindElement(By.XPath("//*[@id='addTaskTitle']")));
            driver.FindElement(By.XPath("//*[@id='addTaskTitle']")).SendKeys("new task");
            driver.FindElement(By.CssSelector(".ql-editor.ql-blank")).SendKeys("do new project");

            driver.FindElement(By.CssSelector(".btn.pink.accent-4")).Click();

            wait.Until(d => driver.FindElement(By.CssSelector(".toast")));
            var taskMsg = driver.FindElement(By.CssSelector(".toast"));

            Assert.IsTrue(taskMsg.Displayed);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
