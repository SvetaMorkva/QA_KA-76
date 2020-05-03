using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace Lab2.PageObjects
{
    class ProfilePage
    {
        private readonly IWebDriver driver;

        public ProfilePage(IWebDriver browser)
        {
            driver = browser;
            driver.Manage().Window.Maximize();

            PageFactory.InitElements(browser, this);
        }


        [FindsBy(How = How.Id, Using = "editprofile")]
        public IWebElement EditProfileButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "form div[class$=' hide']")]
        public IList<IWebElement> ProfileChangeLineEdit { get; set; }


        public bool EditProfileButtonIsVisible => EditProfileButton.Displayed && EditProfileButton.Enabled;
        public bool ProfileChangeEditlinesCountIsRight => ProfileChangeLineEdit.Count == 3;


        // act method

        public ProfilePage OnEditProfileButtonClick()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(EditProfileButton, 1, 1).Click().Build().Perform();

            return this;
        }


        // assert method

        public bool ProfileChangeEditlinesIsVisible()
        {
            foreach (var p in ProfileChangeLineEdit)
            {
                if (!p.Displayed)
                {
                    return false;
                }
            }
            return true;
        }


        //additional method - for usability

        public ProfilePage WaitUntilEditProfileButtonClickable()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(EditProfileButton));
            wait.Until(d => EditProfileButtonIsVisible);

            return this;
        }

        public ProfilePage WaitUntilEditProfileButtonRemoved()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until( d => ! EditProfileButtonIsVisible );

            return this;
        }
    }
}
