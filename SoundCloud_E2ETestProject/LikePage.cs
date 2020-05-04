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

        [FindsBy(How = How.CssSelector, Using = "a.userBadgeListItem__heading.sc-type-small.sc-link-dark.sc-truncate:nth-child(1)")]
        private IList<IWebElement> UsersWhoLikedLink { get; set; }

        public LikePage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(1));
            PageFactory.InitElements(driver, this);
        }


        public string GetUserPageURL(int indexOfUserWhoLiked)
        {
            new WebDriverWait(_driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(UsersWhoLikedLink[indexOfUserWhoLiked]));
            return UsersWhoLikedLink[indexOfUserWhoLiked].GetAttribute("href");
        }

    }
}

