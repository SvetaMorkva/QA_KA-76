using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lab2_pages.Pages
{
    public class UpdatePassword
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='modal-content']/div[5]/div[2]/a")]
        public IWebElement changePassBtn;
        [FindsBy(How = How.XPath, Using = "//*[@id='userUpdatePasswordCurrent']")]
        public IWebElement userUpdatePasswordCurrent;

        [FindsBy(How = How.XPath, Using = "//*[@id='userPasswordNew']")]
        public IWebElement userPasswordNew;

        [FindsBy(How = How.XPath, Using = "//*[@id='userPasswordConfirm']")]
        public IWebElement userPasswordConfirm;

        [FindsBy(How = How.XPath, Using = "//*[@id='modal-content']/div[6]/div/a")]
        public IWebElement confBtn;

        public UpdatePassword(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public String GetCurrntUrl() => _driver.Url;

        public UpdatePassword ChangePassword(String mypass, String newpass)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='modal-content']/div[5]/div[2]/a")));
            changePassBtn.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(100)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='userUpdatePasswordCurrent']")));
            userUpdatePasswordCurrent.SendKeys(mypass);
            userPasswordNew.SendKeys(newpass);
            userPasswordConfirm.SendKeys(newpass);

            confBtn.Click();

            return new UpdatePassword(_driver);

        }
    }
}
