using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WebDriverHomework
{
    public class ProfilePage
    {
        private IWebDriver driver;

        public ProfilePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        private const string PROFILE_NAME = ".rhpdm";

        private const string SEARCH_BUTTON = ".coreSpriteSearchIcon";
        private const string SEARCH_INPUT = ".XTCLo";
        private const string HOME_BUTTON = ".Fifk5:nth-child(1) a";
        private const string INBOX_BUTTON = ".Fifk5:nth-child(2) a";
        private const string EXPLORE_BUTTON = ".Fifk5:nth-child(3) a";
        private const string ACTIVITY_BUTTON = ".Fifk5:nth-child(4) a";
        private const string PROFILE_BUTTON = ".Fifk5:nth-child(5) a";

        private const string FIRST_SEARCH_RESULT = ".yCE8d:nth-child(1)";

        private const string VERIFIED_BADGE = ".coreSpriteVerifiedBadge";
        private const string MOST_RECENT_POST = ".weEfm:nth-child(1) ._bz0w:nth-child(1) ._9AhH0";
        private const string FOLLOW_BUTTON = "._6VtSN";
        private const string FOLLOWING_LIST = ".Y8-fY~ .Y8-fY+ .Y8-fY .-nal3";
        private const string SETTINGS_BUTTON = ".thEYr button";
        private const string PROFILE_BIO = ".-vDIg span";
        private const string PROFILE_WEBSITE = ".yLUwa";

        //search .coreSpriteSearchIcon .TqC_a
        [FindsBy(How = How.CssSelector, Using = SEARCH_BUTTON)]
        private IWebElement searchButton;
        [FindsBy(How = How.CssSelector, Using = SEARCH_INPUT)]
        private IWebElement searchInput;

        //navbar
        [FindsBy(How = How.CssSelector, Using = HOME_BUTTON)]
        private IWebElement homeButton;
        [FindsBy(How = How.CssSelector, Using = INBOX_BUTTON)]
        private IWebElement inboxButton;
        [FindsBy(How = How.CssSelector, Using = EXPLORE_BUTTON)]
        private IWebElement exploreButton;
        [FindsBy(How = How.CssSelector, Using = ACTIVITY_BUTTON)]
        private IWebElement activityButton;
        [FindsBy(How = How.CssSelector, Using = PROFILE_BUTTON)]
        private IWebElement profileButton;

        [FindsBy(How = How.CssSelector, Using = FIRST_SEARCH_RESULT)]
        private IWebElement firstSearchResult;

        [FindsBy(How = How.CssSelector, Using = VERIFIED_BADGE)]
        private IWebElement verifiedBadge;
        [FindsBy(How = How.CssSelector, Using = MOST_RECENT_POST)]
        private IWebElement mostRecentPost;
        [FindsBy(How = How.CssSelector, Using = FOLLOW_BUTTON)]
        private IWebElement followButton;
        [FindsBy(How = How.CssSelector, Using = FOLLOWING_LIST)]
        private IWebElement followingList;
        [FindsBy(How = How.CssSelector, Using = SETTINGS_BUTTON)]
        private IWebElement settingsButton;

        [FindsBy(How = How.CssSelector, Using = PROFILE_NAME)]
        private IWebElement profileName;
        [FindsBy(How = How.CssSelector, Using = PROFILE_BIO)]
        private IWebElement profileBio;
        [FindsBy(How = How.CssSelector, Using = PROFILE_WEBSITE)]
        private IWebElement profileWebsite;

        public Boolean profileNameEquals(string s)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(PROFILE_NAME)));
            return profileName.GetAttribute("innerHTML").Equals(s);
        }

        public Boolean profileBioEquals(string s)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(PROFILE_BIO)));
            return profileBio.GetAttribute("innerHTML").Equals(s);
        }

        public Boolean profileWebsiteEquals(string s)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(PROFILE_WEBSITE)));
            return profileWebsite.GetAttribute("innerHTML").Equals(s);
        }

        public ProfileSettingsPage openProfileSettingsPage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(settingsButton));
            settingsButton.Click();
            return new ProfileSettingsPage(driver);
        }


        public ProfilePage follow()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(followButton));
            followButton.Click();
            return this;
        }

        public Boolean hasVerifiedBadge()
        {
            return verifiedBadge.Displayed;
        }

        public PostPage openMostRecentPost()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(mostRecentPost));
            mostRecentPost.Click();
            return new PostPage(driver);
        }

        public HomePage openHomePage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(homeButton));
            homeButton.Click();
            return new HomePage(driver);
        }

        public InboxPage openInboxPage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(inboxButton));
            inboxButton.Click();
            return new InboxPage(driver);
        }

        public Boolean isPresentInFollowing(string username)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(followingList));
            followingList.Click();
            return smartFind(driver, "._0imsa").GetAttribute("innerHTML").Equals(username);
        }

        public ExplorePage openExplorePage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(exploreButton));
            exploreButton.Click();
            return new ExplorePage(driver);
        }

        public ActivityPage openActivityPage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(activityButton));
            activityButton.Click();
            return new ActivityPage(driver);
        }

        public ProfilePage openProfilePage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(profileButton));
            profileButton.Click();
            return new ProfilePage(driver);
        }

        public static void waitUntilExists(IWebDriver driver, string selector)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(selector)));
        }

        public static IWebElement smartFind(IWebDriver driver, string selector)
        {
            waitUntilExists(driver, selector);
            return driver.FindElement(By.CssSelector(selector));
        }

        public ProfilePage searchUser(string username)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(searchButton));
            searchButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(SEARCH_INPUT)));
            searchInput.SendKeys(username);
            searchInput.SendKeys(Keys.Enter);
            return this;
        }

        public ProfilePage chooseTheFirstOneSuggested()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(FIRST_SEARCH_RESULT)));
            firstSearchResult.Click();
            return new ProfilePage(driver);
        }
    }
}
