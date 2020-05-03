using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lab2_pages.Pages
{
    public class UserInformation
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='modal-content']/div[2]/div/h5")]
        public IWebElement myname;
        

        public UserInformation(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public String GetCurrntUrl() => _driver.Url;

        public string GetUserInformation()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='modal-content']/div[2]/div/h5")));
            return myname.Text;
        }        
    }
}
