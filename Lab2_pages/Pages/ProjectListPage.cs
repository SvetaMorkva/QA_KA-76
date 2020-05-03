using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lab2_pages.Pages
{
    public class ProjectListPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='projectViewList']/table/thead/tr/th[7]/a")]
        public IWebElement addNewProjectBtn;

        [FindsBy(How = How.CssSelector, Using = ".ql-editor.ql-blank")]
        public IWebElement addNewProjectDesc;


        [FindsBy(How = How.XPath, Using = "//*[@id='modal-content']/div[4]/div[2]/div")]
        public IWebElement addButton;

        public ProjectListPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public String GetCurrntUrl() => _driver.Url;

        public ProjectListPage AddProject(String description)
        {
            System.Threading.Thread.Sleep(1000);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='projectViewList']/table/thead/tr/th[7]/a")));
            addNewProjectBtn.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='modal-content']/div[4]/div[2]/div")));
            addNewProjectDesc.SendKeys(description);
            addButton.Click();

            return new ProjectListPage(_driver);
        }
    }
}
