using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WebDriverHomework
{
    public class ExplorePage
    {
        private IWebDriver driver;

        public ExplorePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        private const string FIRST_POST = ".-muEz+ .pKKVh ._9AhH0";

        private const string SEARCH_BUTTON = ".coreSpriteSearchIcon";
        private const string SEARCH_INPUT = ".XTCLo";
        private const string HOME_BUTTON = ".Fifk5:nth-child(1) a";
        private const string INBOX_BUTTON = ".Fifk5:nth-child(2) a";
        private const string EXPLORE_BUTTON = ".Fifk5:nth-child(3) a";
        private const string ACTIVITY_BUTTON = ".Fifk5:nth-child(4) a";
        private const string PROFILE_BUTTON = ".Fifk5:nth-child(5) a";

        private const string FIRST_SEARCH_RESULT = ".yCE8d:nth-child(1)";

        [FindsBy(How = How.CssSelector, Using = FIRST_POST)]
        private IWebElement firstPost;

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


        public PostPage openFirstPost()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(FIRST_POST)));
            firstPost.Click();
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

        public HomePage searchUser(string username)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(searchButton));
            searchButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(SEARCH_INPUT)));
            searchInput.SendKeys(username);
            searchInput.SendKeys(Keys.Enter);
            return new HomePage(driver);
        }

        public ProfilePage chooseTheFirstOneSuggested()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(FIRST_SEARCH_RESULT)));
            firstSearchResult.Click();
            return new ProfilePage(driver);
        }
    }
}
