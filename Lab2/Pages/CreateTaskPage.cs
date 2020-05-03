using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lab2.Pages
{
    class CreateTaskPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;


        public CreateTaskPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "login_id")]
        public IWebElement loginLineEdit;

        [FindsBy(How = How.Id, Using = "Crm_Tasks_SUBJECT")]
        public IWebElement subjectInput;

        [FindsBy(How = How.Id, Using = "Crm_Tasks_DUEDATE")]
        public IWebElement dueDateInput;

        [FindsBy(How = How.Id, Using = "Crm_Tasks_DUEDATE_label")]
        public IWebElement dueDateLabelDummy;

        [FindsBy(How = How.Id, Using = "Crm_Tasks_CONTACTID")]
        public IWebElement contactInput;

        [FindsBy(How = How.Id, Using = "saveTasksBtn")]
        public IWebElement saveBtn;


        [FindsBy(How = How.Id, Using = "subvalue_SUBJECT")]
        public IWebElement subjectLabel;

        public string subjectLabelValue => subjectLabel.Text;

        [FindsBy(How = How.Id, Using = "subvalue_DUEDATE")]
        public IWebElement dueLabel;
        public string dueLabelValue => dueLabel.Text;

        [FindsBy(How = How.Id, Using = "subvalue_CONTACTID")]
        public IWebElement contactLabel;
        public string contactLabelValue => contactLabel.Text;


        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _wait.Until(driver => ((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void CreateTask(string taskName, string date, string contact)
        {
            subjectInput.SendKeys(taskName);
            dueDateInput.SendKeys(date);
            dueDateLabelDummy.Click();
            contactInput.Click();
            IWebElement contactUIList = _driver.FindElement(By.XPath($"//ul[@class=\"ui-menu ui-widget ui-widget-content ui-autocomplete ui-front lookupFieldULlist\"]/li/a/span[text()=\"{contact}\"]"), 5);
            _wait.Until(dr => contactUIList.Displayed);
            contactUIList.Click();
            System.Threading.Thread.Sleep(2000);
            saveBtn.Click();
        }
    }   
}
