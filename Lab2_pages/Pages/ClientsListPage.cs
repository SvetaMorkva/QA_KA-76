using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lab2_pages.Pages
{
    public class ClientsListPage
    {
        private IWebDriver _driver;
        WebDriverWait wait;
        [FindsBy(How = How.XPath, Using = "//*[@id='clientList']/table/thead/tr/th[7]/a")]
        public IWebElement addNewCompanyBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='clientCompany']")]
        public IWebElement addNewCompanyInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='modal-content']/div[11]/div[2]/div")]
        public IWebElement addButton;

        public ClientsListPage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            PageFactory.InitElements(driver, this);
        }

        public String GetCurrntUrl() => _driver.Url;

        public ClientsListPage AddClient(String name)
        {
            System.Threading.Thread.Sleep(1000);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='clientList']/table/thead/tr/th[7]/a")));
            addNewCompanyBtn.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='clientCompany']")));

            addNewCompanyInput.SendKeys(name);
            addButton.Click();
            return new ClientsListPage(_driver);
        }

    }
}
