using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lab2_pages.Pages
{
    public class DashBoard
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public DashBoard(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _wait.Until(driver => ((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        [FindsBy(How = How.ClassName, Using = "noMarginBottom")]
        public IWebElement confirm;

        [FindsBy(How = How.XPath, Using = "//img[@src='https://app.knackbusiness.com/assets/images/nav_clients.png']")]
        public IWebElement openClientsFeatures;

        [FindsBy(How = How.XPath, Using = "//*[@id='slide-out']/ul/li[2]/div/a[6]")]
        public IWebElement openClientsList;

        [FindsBy(How = How.XPath, Using = "//img[@src='https://app.knackbusiness.com/assets/images/nav_projects.png']")]
        public IWebElement openProjectFeatures;

        [FindsBy(How = How.XPath, Using = "//*[@id='slide-out']/ul/li[5]/div/a[3]")]
        public IWebElement openProjectsList;

        [FindsBy(How = How.XPath, Using = "//*[@id='slide-out']/ul/li[5]/div/a[5]")]
        public IWebElement openTasksList;

        [FindsBy(How = How.XPath, Using = "//*[@id='slide-out']/ul/li[1]/a[1]/div")]
        public IWebElement openProfileOptions;

        [FindsBy(How = How.XPath, Using = "//*[@id='logoutLink']/div")]
        public IWebElement logoutLink;

        [FindsBy(How = How.XPath, Using = "//*[@id='slide-out']/ul/li[7]/a")]
        public IWebElement openCompanyOptions;

        [FindsBy(How = How.XPath, Using = "//*[@id='slide-out']/ul/li[7]/div/a[2]")]
        public IWebElement openCompanyDetail;

        [FindsBy(How = How.XPath, Using = "//*[@id='accountsList']/div/a")]
        public IWebElement accountList;

        //[FindsBy(How = How.XPath, Using = "/html/body/div[12]/div/div[5]/a[1]")]
        //public IWebElement notification;
        

        public String GetCurrntUrl() => _driver.Url;

        public ClientsListPage OpenClientsList()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//img[@src='https://app.knackbusiness.com/assets/images/nav_clients.png']")));
            openClientsFeatures.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementIsVisible(By.LinkText("Clients")));
            openClientsList.Click();
            //new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='clientList']/table/thead/tr/th[7]/a")));
            return new ClientsListPage(_driver);
        }

        public ProjectListPage OpenProjectsList()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//img[@src='https://app.knackbusiness.com/assets/images/nav_projects.png']")));
            openProjectFeatures.Click();
            System.Threading.Thread.Sleep(200);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementExists(By.LinkText("Projects")));
            openProjectsList.Click();
            //new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='projectViewList']/table/thead/tr/th[7]/a")));
            return new ProjectListPage(_driver);
        }

        public TasksListPage OpenTasksList()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//img[@src='https://app.knackbusiness.com/assets/images/nav_projects.png']")));
            openProjectFeatures.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Tasks")));
            openTasksList.Click();
            //new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='projectViewList']/table/thead/tr/th[7]/a")));
            return new TasksListPage(_driver);
        }

        public DashBoard LogOut()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("profileImage")));
            openProfileOptions.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("accountsList")));
            logoutLink.Click();
            return this;

        }

        public UserInformation UserInfo()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='slide-out']/ul/li[7]/a")));
            openCompanyOptions.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='slide-out']/ul/li[7]/div/a[2]")));
            openCompanyDetail.Click();

            return new UserInformation(_driver);
        }

        public UpdatePassword UpdPass()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("profileImage")));
            openProfileOptions.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementIsVisible(By.XPath(("//*[@id='accountsList']/div/a"))));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].removeAttribute('margin-left')", accountList);
            accountList.Click();

            //new WebDriverWait(_driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementIsVisible(By.XPath(("/html/body/div[12]/div/div[5]/a[1]"))));
            //notification.Click();
            System.Threading.Thread.Sleep(500);

            return new UpdatePassword(_driver);
        }
    }
}
