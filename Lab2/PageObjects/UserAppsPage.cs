using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;

namespace Lab2.PageObjects
{
    class UserAppsPage
    {
        private readonly IWebDriver driver;

        public UserAppsPage(IWebDriver browser)
        {
            driver = browser;
            driver.Manage().Window.Maximize();

            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[class*='ztb-p']")]
        public IWebElement UserAccountButton { get; set; }

        [FindsBy(How = How.Id, Using = "ztb-user-id")]
        public IWebElement UserAccountEmailLabel { get; set; }

        [FindsBy(How = How.Id, Using = "ztb-myaccount")]
        public IWebElement ToMyAccountButton { get; set; }


        public string UserAccountEmail => UserAccountEmailLabel.Text;

        // act method

        public UserAppsPage OnUserAccountButtonClick()
        {

            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(UserAccountButton));

            Actions actions = new Actions(driver);
            actions.MoveToElement(UserAccountButton, 1, 1).Click().Build().Perform();
            return this;
        }

        public UserAppsPage GoToMyAccountSettings()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(ToMyAccountButton));

            Actions actions = new Actions(driver);
            actions.MoveToElement(ToMyAccountButton, 1, 1).Click().Build().Perform();
            return this;
        }

        //additional method - for usability

        public UserAppsPage WaitUntilUserAccountEmailClickable()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(UserAccountEmailLabel));

            return this;
        }

    }
}
