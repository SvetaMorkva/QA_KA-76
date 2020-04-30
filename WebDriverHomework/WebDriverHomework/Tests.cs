using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace WebDriverHomework
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private PageObject mainPage;

        private string url = "https://www.instagram.com/";

        private string username = "brandd1re";
        private string password = "ImaBitchImaBoss";


        public static void waitUntilExists(IWebDriver driver, string selector)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(selector)));
        }

        public static IWebElement smartFind(IWebDriver driver, string selector)
        {
            waitUntilExists(driver, selector);
            return driver.FindElement(By.CssSelector(selector));
        }




        [SetUp]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(url);

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == url);

            //login
            smartFind(driver, ".FBi-h+ .-MzZI .zyHYP").SendKeys(username);
            smartFind(driver, ".-MzZI+ .-MzZI .zyHYP").SendKeys(password);
            smartFind(driver, ".-MzZI+ .DhRcB").Click();

            Thread.Sleep(3000);

            //There's a dumb notification dialog (-_-)
            if (driver.FindElements(By.CssSelector(".piCib")).Count != 0)
            {
                smartFind(driver, ".HoLwm").Click();
            }

            Thread.Sleep(10000);
            //waitUntilExists(driver, ".Fifk5 ._6q-tv");

            mainPage = new PageObject(driver);

            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        [TearDown]
        public void TestFinalize()
        {
            driver.Quit();
        }


        [TestCase("natalieportman")]
        public void findTheCelebrity_TheFirstSearchResultShouldHaveTheVerifiedBadgeInProfile(string celebrity)
        {
            mainPage.startSearchInput().SendKeys(celebrity);
            //choose the first search result
            Thread.Sleep(5000);
            smartFind(driver, ".yCE8d:nth-child(1)").Click();
            //wait until the profile is loaded
            waitUntilExists(driver, ".fDxYl");

            // Wow, you found an easter egg! Just text me in telegram @irremissibile
            // Your dream reward (1 chocolate bar) is waiting for you

            Assert.IsTrue(smartFind(driver, ".coreSpriteVerifiedBadge").Displayed);
        }


        [TestCase("et.irremissibile", "wazzup")]
        public void findTheParticularUserAndSendAMessage_ShouldBeNoErrorsInCorrespondingInboxChat(string targetUser, string message)
        {
            mainPage.openInboxPage();
            //find and click a "new message" button
            smartFind(driver, ".wpO6b").Click();
            //find an input search field and paste the username
            smartFind(driver, ".j_2Hd").SendKeys(targetUser);
            //choose the first one suggested
            Thread.Sleep(5000);
            smartFind(driver, ".-qQT3:nth-child(1) .HVWg4").Click();
            //click "next"
            smartFind(driver, ".cB_4K").Click();
            //the chat with the chosen person must be opened
            smartFind(driver, ".vy6Bb").GetAttribute("innerHTML").Contains(targetUser);
            //type a message
            smartFind(driver, ".ItkAi textarea").SendKeys(message);
            smartFind(driver, ".ItkAi textarea").SendKeys(Keys.Enter);
            //the message must be sent and there should be no "..." icon near the message
            Thread.Sleep(3000);
            
            Assert.IsTrue(driver.FindElements(By.CssSelector(".FeN85")).Count == 0);
        }


        [TestCase("et.irremissibile")]
        public void likeTheUsersMostRecentPost_TestAccountShouldAppearInTheListOfPeopleWhoHasLikedThisPost(string targetUser)
        {
            mainPage.startSearchInput().SendKeys(targetUser);
            //choose the first search result
            Thread.Sleep(5000);
            smartFind(driver, ".yCE8d:nth-child(1)").Click();
            //wait until the profile is loaded
            waitUntilExists(driver, ".fDxYl");
            //click the most recent post
            smartFind(driver, ".weEfm:nth-child(1) ._bz0w:nth-child(1) ._9AhH0").Click();

            //check if the post has been already liked
            if (smartFind(driver, ".ltpMr .fr66n .wpO6b svg").GetAttribute("aria-label") == "Unlike")
            {
                //gotta "re-like"
                smartFind(driver, ".ltpMr .fr66n .wpO6b").Click();
                Thread.Sleep(3000);
            }
            smartFind(driver, ".ltpMr .fr66n .wpO6b").Click();
            Thread.Sleep(3000);

            //we should see the test account in the list of people who has liked this post
            smartFind(driver, ".Nm9Fw button").Click();
            Assert.AreEqual(username, smartFind(driver, ".rBNOH:nth-child(1) .IwRSH .eGOV_ div div div div")
                    .GetAttribute("innerHTML"));
        }


        [TestCase("et.irremissibile", "Малышка любит дилера")]
        public void commentTheUsersMostRecentPost_TestCommentMustAppearInTheCommentsSection(string targetUser, string comment)
        {
            mainPage.startSearchInput().SendKeys(targetUser);
            //choose the first search result
            Thread.Sleep(5000);
            smartFind(driver, ".yCE8d:nth-child(1)").Click();
            //wait until the profile is loaded
            waitUntilExists(driver, ".fDxYl");
            //click the most recent post
            smartFind(driver, ".weEfm:nth-child(1) ._bz0w:nth-child(1) ._9AhH0").Click();

            //write and send the comment
            smartFind(driver, ".X7cDz textarea").Click();
            smartFind(driver, ".X7cDz textarea").SendKeys(comment);
            smartFind(driver, ".X7cDz textarea").SendKeys(Keys.Enter);

            //Gotta wait for instagram to process the comment
            Thread.Sleep(5000);

            Assert.AreEqual(comment, smartFind(driver, ".Mr508:last-child .C4VMK span").GetAttribute("innerHTML"));
        }


        [TestCase("et.irremissibile")]
        public void shareRandomPostFromExploreToTargetUser_PostShouldAppearInTheChatWithTargetUser(string targetUser)
        {
            mainPage.openExplorePage();

            //open and share the first post in "explore"
            smartFind(driver, ".-muEz+ .pKKVh ._9AhH0").Click();
            smartFind(driver, ".ltpMr button:nth-child(3)").Click();
            smartFind(driver, ".HVWg4 .-qQT3:nth-child(1)").Click();

            //find an input search field and paste the username
            smartFind(driver, ".j_2Hd").SendKeys(targetUser);
            Thread.Sleep(5000);
            //choose the first one suggested
            smartFind(driver, ".-qQT3:nth-child(1) .eGOV_:nth-child(2)").Click();
            //click "send"
            smartFind(driver, ".cB_4K").Click();

            //wait for instagram to process and close
            Thread.Sleep(5000);
            smartFind(driver, ".fm1AK  ._8-yf5").Click();

            //open inbox
            mainPage.openInboxPage();

            //then the last message should be "You sent a post" and time should be "N s" (n seconds ago)
            //language dependent!!!
            Assert.IsTrue(smartFind(driver, ".R19PB ~ time").GetAttribute("innerHTML").Contains("s") ||
                    smartFind(driver, ".R19PB ~ time").GetAttribute("innerHTML").Contains("с"));

            Assert.IsTrue("You sent a post".Equals(smartFind(driver, ".R19PB span").GetAttribute("innerHTML")) ||
                    "Вы отправили публикацию".Equals(smartFind(driver, ".R19PB span").GetAttribute("innerHTML")));
        }


        [TestCase("et.irremissibile")]
        public void followTargetUser_TargetUserShouldAppearInTheListOfFollowingPeople(string targetUser)
        {
            mainPage.startSearchInput().SendKeys(targetUser);
            //choose the first search result
            Thread.Sleep(5000);
            smartFind(driver, ".yCE8d:nth-child(1)").Click();
            //wait until the profile is loaded
            waitUntilExists(driver, ".fDxYl");

            //press "follow" button
            smartFind(driver, "._6VtSN").Click();
            Thread.Sleep(1000);

            //now lets check if this account appears in the "following"
            mainPage.openProfilePage();
            Thread.Sleep(3000);

            smartFind(driver, ".Y8-fY~ .Y8-fY+ .Y8-fY .-nal3").Click();
            Assert.AreEqual(targetUser, smartFind(driver, "._0imsa").GetAttribute("innerHTML"));

        }


        [TestCase("Jim Morrison")]
        //[TestCase("Riley Reid")]
        //[TestCase("Marshall Mathers")]
        //[TestCase("Selenium Tester")]
        public void changeAccountName_NewNameShouldBeDisplayedInTheProfile(string newName)
        {
            mainPage.openProfilePage();
            Thread.Sleep(5000);
            smartFind(driver, ".thEYr button").Click();
            smartFind(driver, "#pepName").Click();
            smartFind(driver, "#pepName").Clear();
            smartFind(driver, "#pepName").SendKeys(newName);
            Thread.Sleep(1000);
            smartFind(driver, ".L3NKy").Click();
            mainPage.openProfilePage();
            Thread.Sleep(2000);

            Assert.AreEqual(newName, smartFind(driver, ".rhpdm").GetAttribute("innerHTML"));
        }


        [TestCase("The legend")]
        //[TestCase("Super sexy little girl")]
        //[TestCase("Rap god")]
        //[TestCase("I have been beaten by my mum")]
        public void changeAccountBio_NewBioShouldBeDisplayedInTheProfile(string newBio)
        {
            mainPage.openProfilePage();
            Thread.Sleep(5000);
            smartFind(driver, ".thEYr button").Click();
            smartFind(driver, "#pepBio").Click();
            smartFind(driver, "#pepBio").Clear();
            smartFind(driver, "#pepBio").SendKeys(newBio);
            Thread.Sleep(1000);
            smartFind(driver, ".L3NKy").Click();
            mainPage.openProfilePage();
            Thread.Sleep(2000);

            Assert.AreEqual(newBio, smartFind(driver, ".-vDIg span").GetAttribute("innerHTML"));
        }


        [TestCase("heaven.org")]
        //[TestCase("pornhub.com")]
        //[TestCase("genius.com")]
        //[TestCase("dypka.ua")]
        public void changeAccountWebsite_NewWebsiteShouldBeDisplayedInTheProfile(string newWebsite)
        {
            mainPage.openProfilePage();
            Thread.Sleep(5000);
            smartFind(driver, ".thEYr button").Click();
            smartFind(driver, "#pepWebsite").Click();
            smartFind(driver, "#pepWebsite").Clear();
            smartFind(driver, "#pepWebsite").SendKeys(newWebsite);
            Thread.Sleep(1000);
            smartFind(driver, ".L3NKy").Click();
            mainPage.openProfilePage();
            Thread.Sleep(2000);

            Assert.AreEqual(newWebsite, smartFind(driver, ".yLUwa").GetAttribute("innerHTML"));
        }
    }
}
