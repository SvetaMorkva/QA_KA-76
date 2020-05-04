using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WebDriverHomework
{
    public class InboxPage
    {
        private IWebDriver driver;


        public InboxPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private const string NEW_MESSAGE_BUTTON = ".wpO6b";
        private const string SEARCH_MESSAGE_FIELD = ".j_2Hd";
        private const string FIRST_MESSAGE_SEARCH_RESULT = ".-qQT3:nth-child(1) .HVWg4";
        private const string NEXT_BUTTON = ".cB_4K";
        private const string CHAT_NAME = ".vy6Bb";
        private const string MESSAGE_FIELD = ".ItkAi textarea";
        private const string ERROR = ".FeN85";

        private const string LAST_MESSAGE_TIME = ".R19PB ~ time";
        private const string LAST_MESSAGE_INFO = ".R19PB span";


        [FindsBy(How = How.CssSelector, Using = NEW_MESSAGE_BUTTON)]
        private IWebElement newMessageButton;
        [FindsBy(How = How.CssSelector, Using = SEARCH_MESSAGE_FIELD)]
        private IWebElement searchMessageField;
        [FindsBy(How = How.CssSelector, Using = FIRST_MESSAGE_SEARCH_RESULT)]
        private IWebElement firstMessageSearchResult;
        [FindsBy(How = How.CssSelector, Using = NEXT_BUTTON)]
        private IWebElement nextButton;
        [FindsBy(How = How.CssSelector, Using = CHAT_NAME)]
        private IWebElement chatName;
        [FindsBy(How = How.CssSelector, Using = MESSAGE_FIELD)]
        private IWebElement messageField;
        [FindsBy(How = How.CssSelector, Using = LAST_MESSAGE_INFO)]
        private IWebElement lastMessageInfo;
        [FindsBy(How = How.CssSelector, Using = LAST_MESSAGE_TIME)]
        private IWebElement lastMessageTime;


        public Boolean lastMessageTimeContains(string s)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(LAST_MESSAGE_TIME)));
            return lastMessageTime.GetAttribute("innerHTML").Contains(s);
        }

        public Boolean lastMessageInfoContains(string s)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(LAST_MESSAGE_INFO)));
            return lastMessageInfo.GetAttribute("innerHTML").Contains(s);
        }


        public InboxPage startNewMessageDialog()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(newMessageButton));
            newMessageButton.Click();
            return this;
        }

        public InboxPage searchAddressee(string targetUser)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(SEARCH_MESSAGE_FIELD)));
            searchMessageField.Click();
            searchMessageField.SendKeys(targetUser);
            searchMessageField.SendKeys(Keys.Enter);
            return this;
        }

        public InboxPage chooseTheFirstOneSuggested()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(firstMessageSearchResult));
            firstMessageSearchResult.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(nextButton));
            nextButton.Click();
            return this;
        }

        public Boolean checkChat(string targetUser)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector(CHAT_NAME)));
            return chatName.GetAttribute("innerHTML").Contains(targetUser);
        }

        public InboxPage sendMessage(string message)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(messageField));
            messageField.Click();
            messageField.SendKeys(message);
            messageField.SendKeys(Keys.Enter);
            return this;
        }

        public Boolean isErrorAbsent()
        {
            Thread.Sleep(5000);
            return driver.FindElements(By.CssSelector(ERROR)).Count == 0;
        }




        private const string SEARCH_BUTTON = ".coreSpriteSearchIcon";
        private const string SEARCH_INPUT = ".XTCLo";
        private const string HOME_BUTTON = ".Fifk5:nth-child(1) a";
        private const string INBOX_BUTTON = ".Fifk5:nth-child(2) a";
        private const string EXPLORE_BUTTON = ".Fifk5:nth-child(3) a";
        private const string ACTIVITY_BUTTON = ".Fifk5:nth-child(4) a";
        private const string PROFILE_BUTTON = ".Fifk5:nth-child(5) a";


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


    }
}
