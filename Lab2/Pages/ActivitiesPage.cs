using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lab2.Pages
{
    class ActivitiesPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public ActivitiesPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "login_id")]
        public IWebElement loginLineEdit;
        
        [FindsBy(How = How.XPath, Using = "//ul[@id=\"RelatedTo_Container\"]/li/div/div/div/span/a/span[@id=\"Subject\"]")]
        public IList<IWebElement> tasksList;
        
        [FindsBy(How = How.Id, Using = "CustomizeTools")]
        public IWebElement customizeTools;

        [FindsBy(How = How.XPath, Using = "//a[@name=\"Delete2\"]")]
        public IWebElement deleteBtn;

        [FindsBy(How = How.Id, Using = "deleteButton")]
        public IWebElement popUpDelete;

        public IWebElement findTaskToDelete(string by)
        {
            return _driver.FindElement(By.XPath($"//ul[@id=\"RelatedTo_Container\"]/li/div/div/div/span/a[span[@title=\"{by}\"]]"), 10);
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _wait.Until(driver => ((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void DeleteTask(string taskName)
        {
            var taskToDelete = findTaskToDelete(taskName);
            System.Threading.Thread.Sleep(1000);
            taskToDelete.Click();
            System.Threading.Thread.Sleep(1000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", customizeTools);
            System.Threading.Thread.Sleep(1000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", deleteBtn);

            System.Threading.Thread.Sleep(2000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", popUpDelete);
        }


        public bool SearchForTask(string taskName)
        {
            foreach (var task in tasksList)
            {
                if (task.Text == taskName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
