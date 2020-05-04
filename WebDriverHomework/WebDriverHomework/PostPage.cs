using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WebDriverHomework
{
    public class PostPage
    {
        private IWebDriver driver;

        public PostPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public const string LIKE_BUTTON = ".ltpMr .fr66n .wpO6b";
        public const string LIST_OF_PEOPLE_WHO_LIKED = ".Nm9Fw button";
        public const string COMMENT_INPUT = ".X7cDz textarea";
        public const string LAST_COMMENT = ".Mr508:last-child .C4VMK span";
        public const string CLOSE_BUTTON = ".fm1AK  ._8-yf5";

        [FindsBy(How = How.CssSelector, Using = LIKE_BUTTON)]
        private IWebElement likeButton;
        [FindsBy(How = How.CssSelector, Using = LIST_OF_PEOPLE_WHO_LIKED)]
        private IWebElement listOfPeopleWhoLiked;
        [FindsBy(How = How.CssSelector, Using = COMMENT_INPUT)]
        private IWebElement commentInput;
        [FindsBy(How = How.CssSelector, Using = LAST_COMMENT)]
        private IWebElement lastComment;
        [FindsBy(How = How.CssSelector, Using = CLOSE_BUTTON)]
        private IWebElement closeButton;

        public PostPage likePost()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(LIKE_BUTTON)));
            likeButton.Click();
            return this;
        }

        public PostPage openListOfPeopleWhoLiked()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(listOfPeopleWhoLiked));
            listOfPeopleWhoLiked.Click();
            return this;
        }

        public PostPage sendComment(string comment)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(COMMENT_INPUT)));
            commentInput.Click();
            commentInput.SendKeys(comment);
            commentInput.SendKeys(Keys.Enter);
            return this;
        }

        public Boolean isLastComment(string comment)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(LAST_COMMENT)));
            return lastComment.GetAttribute("innerHTML").Equals(comment);
        }

        public PostPage sharePostToUser(String targetUser)
        {
            smartFind(driver, ".ltpMr button:nth-child(3)").Click();
            smartFind(driver, ".HVWg4 .-qQT3:nth-child(1)").Click();

            //find an input search field and paste the username
            smartFind(driver, ".j_2Hd").SendKeys(targetUser);
            Thread.Sleep(5000);
            //choose the first one suggested
            smartFind(driver, ".-qQT3:nth-child(1) .eGOV_:nth-child(2)").Click();
            //click "send"
            smartFind(driver, ".cB_4K").Click();

            return this;
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

        public HomePage close()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(CLOSE_BUTTON)));
            closeButton.Click();
            return new HomePage(driver);
        }
    }
}
