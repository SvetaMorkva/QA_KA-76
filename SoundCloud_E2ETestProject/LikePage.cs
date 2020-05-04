using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SoundCloud_E2ETestProject
{
    class LikePage
    {
        private IWebDriver _driver;
        private WebDriverWait wait;

        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div[1]/div/div/div/button")]
        private IWebElement cookiesButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.userBadgeListItem__heading.sc-type-small.sc-link-dark.sc-truncate:nth-child(1)")]
        private IList<IWebElement> UserWhoLikedLink { get; set; }

        public LikePage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(1));
            PageFactory.InitElements(driver, this);

            try
            {
                new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(cookiesButton));
                cookiesButton.Click();
            }
            catch { }
        }


        public string GetUserPage(int indexOfUserWhoLiked)
        {
            new WebDriverWait(_driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(UserWhoLikedLink[indexOfUserWhoLiked]));
            return UserWhoLikedLink[indexOfUserWhoLiked].GetAttribute("href");
        }

    }
}

