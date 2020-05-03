using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lab2_pages.Pages
{
    public class TasksListPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='taskViewList']/div/div/table/thead/tr/th[7]/a")]
        public IWebElement addNewTaskBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='modal-content']/div[4]/div[2]/a")]
        public IWebElement addQuickTask;

        [FindsBy(How = How.XPath, Using = "//*[@id='addTaskTitle']")]
        public IWebElement addTaskTitle;

        [FindsBy(How = How.CssSelector, Using = ".ql-editor.ql-blank")]
        public IWebElement addTaskDesc;


        [FindsBy(How = How.XPath, Using = "//*[@id='modal-content']/div[5]/div[2]/div")]
        public IWebElement addButton;

        public TasksListPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public String GetCurrntUrl() => _driver.Url;

        public TasksListPage AddTask(String title, String description)
        {
            System.Threading.Thread.Sleep(1000);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='taskViewList']/div/div/table/thead/tr/th[7]/a")));
            addNewTaskBtn.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='modal-content']/div[4]/div[2]/a")));
            addQuickTask.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='addTaskTitle']")));
            addTaskTitle.SendKeys(title);
            addTaskDesc.SendKeys(description);
            addButton.Click();

            return new TasksListPage(_driver);
        }
    }
}
