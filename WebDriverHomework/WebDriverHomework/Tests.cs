using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace WebDriverHomework
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private PageObject mainPage;
        private HomePage homePage;

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
            if (driver.FindElements(By.CssSelector(".RnEpo")).Count != 0)
            {
                smartFind(driver, ".HoLwm").Click();
            }
            Thread.Sleep(3000);


            mainPage = new PageObject(driver);
            homePage = new HomePage(driver);

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
            ProfilePage profilePage = null;
            while (profilePage == null)
            {
                try
                {
                    profilePage = homePage.searchUser(celebrity)
                        .chooseTheFirstOneSuggested();
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    if (driver.FindElements(By.CssSelector(".RnEpo")).Count != 0)
                    {
                        smartFind(driver, ".HoLwm").Click();
                    }
                }
            }            
            Assert.IsTrue(profilePage.hasVerifiedBadge());

            // Wow, you found an easter egg! Just text me in telegram @irremissibile
            // Your dream reward (1 chocolate bar) is waiting for you
        }


        [TestCase("et.irremissibile", "wazzup")]
        public void findTheParticularUserAndSendAMessage_ShouldBeNoErrorsInCorrespondingInboxChat(string targetUser, string message)
        {
            InboxPage inboxPage = null;
            while (inboxPage == null)
            {
                try
                {
                    inboxPage = homePage.openInboxPage();
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    if (driver.FindElements(By.CssSelector(".RnEpo")).Count != 0)
                    {
                        smartFind(driver, ".HoLwm").Click();
                    }
                }
            }

            inboxPage.startNewMessageDialog()
                        .searchAddressee(targetUser)
                        .chooseTheFirstOneSuggested()
                        .sendMessage(message);
            Thread.Sleep(5000);

            Assert.IsTrue(inboxPage.checkChat(targetUser));
            Assert.IsTrue(inboxPage.isErrorAbsent());
        }


        [TestCase("et.irremissibile")]
        public void likeTheUsersMostRecentPost_TestAccountShouldAppearInTheListOfPeopleWhoHasLikedThisPost(string targetUser)
        {
            ProfilePage profilePage = null;
            while (profilePage == null)
            {
                try
                {
                    profilePage = homePage.searchUser(targetUser)
                        .chooseTheFirstOneSuggested();
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    if (driver.FindElements(By.CssSelector(".RnEpo")).Count != 0)
                    {
                        smartFind(driver, ".HoLwm").Click();
                    }
                }
            }
            PostPage postPage = profilePage.openMostRecentPost();
            Thread.Sleep(5000);

            postPage.likePost();
            Thread.Sleep(5000);

            postPage.openListOfPeopleWhoLiked();
            Thread.Sleep(5000);

            Assert.AreEqual(username, smartFind(driver, ".rBNOH:nth-child(1) .IwRSH .eGOV_ div div div div").GetAttribute("innerHTML"));
        }


        [TestCase("et.irremissibile", "Малышка любит дилера")]
        public void commentTheUsersMostRecentPost_TestCommentMustAppearInTheCommentsSection(string targetUser, string comment)
        {
            ProfilePage profilePage = null;
            while (profilePage == null)
            {
                try
                {
                    profilePage = homePage.searchUser(targetUser)
                        .chooseTheFirstOneSuggested();
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    if (driver.FindElements(By.CssSelector(".RnEpo")).Count != 0)
                    {
                        smartFind(driver, ".HoLwm").Click();
                    }
                }
            }
            PostPage postPage = profilePage.openMostRecentPost();
            Thread.Sleep(5000);

            postPage.sendComment(comment);
            Thread.Sleep(5000);

            Assert.IsTrue(postPage.isLastComment(comment));
        }


        [TestCase("et.irremissibile")]
        public void shareRandomPostFromExploreToTargetUser_PostShouldAppearInTheChatWithTargetUser(string targetUser)
        {
            PostPage postPage = null;
            while (postPage == null)
            {
                try
                {
                    postPage = homePage.openExplorePage()
                        .openFirstPost();
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    if (driver.FindElements(By.CssSelector(".RnEpo")).Count != 0)
                    {
                        smartFind(driver, ".HoLwm").Click();
                    }
                }
            }
            HomePage h1 = postPage.sharePostToUser(targetUser)
                .close();
            Thread.Sleep(5000);

            InboxPage inboxPage = h1.openInboxPage();

            Assert.IsTrue(inboxPage.lastMessageTimeContains("s") || inboxPage.lastMessageTimeContains("с"));
            Assert.IsTrue(inboxPage.lastMessageInfoContains("You sent a post") || inboxPage.lastMessageInfoContains("Вы отправили публикацию"));
        }


        [TestCase("et.irremissibile")]
        public void followTargetUser_TargetUserShouldAppearInTheListOfFollowingPeople(string targetUser)
        {
            ProfilePage profilePage = null;
            while (profilePage == null)
            {
                try
                {
                    profilePage = homePage.searchUser(targetUser)
                        .chooseTheFirstOneSuggested();
                    Thread.Sleep(100);
                }
                catch (ElementClickInterceptedException e)
                {
                    if (driver.FindElements(By.CssSelector(".RnEpo")).Count != 0)
                    {
                        smartFind(driver, ".HoLwm").Click();
                    }
                }
            }
            profilePage.follow()
                .openProfilePage();
            Thread.Sleep(5000);

            Assert.IsTrue(profilePage.isPresentInFollowing(targetUser));
        }


        [TestCase("Jim Morrison")]
        //[TestCase("Riley Reid")]
        //[TestCase("Marshall Mathers")]
        //[TestCase("Selenium Tester")]
        public void changeAccountName_NewNameShouldBeDisplayedInTheProfile(string newName)
        {
            ProfileSettingsPage settingsPage = null;
            while (settingsPage == null)
            {
                try
                {
                    settingsPage = homePage.openProfilePage()
                        .openProfileSettingsPage();
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    if (driver.FindElements(By.CssSelector(".RnEpo")).Count != 0)
                    {
                        smartFind(driver, ".HoLwm").Click();
                    }
                }
            }
            settingsPage.sendName(newName);
            Thread.Sleep(3000);
            settingsPage.clickSubmit();

            ProfilePage profilePage = settingsPage.openProfilePage();
            Thread.Sleep(5000);

            Assert.IsTrue(profilePage.profileNameEquals(newName));
        }


        [TestCase("The legend")]
        //[TestCase("Super sexy little girl")]
        //[TestCase("Rap god")]
        //[TestCase("I have been beaten by my mum")]
        public void changeAccountBio_NewBioShouldBeDisplayedInTheProfile(string newBio)
        {
            ProfileSettingsPage settingsPage = null;
            while (settingsPage == null)
            {
                try
                {
                    settingsPage = homePage.openProfilePage()
                        .openProfileSettingsPage();
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    if (driver.FindElements(By.CssSelector(".RnEpo")).Count != 0)
                    {
                        smartFind(driver, ".HoLwm").Click();
                    }
                }
            }
            settingsPage.sendBio(newBio);
            Thread.Sleep(3000);
            settingsPage.clickSubmit();

            ProfilePage profilePage = settingsPage.openProfilePage();
            Thread.Sleep(5000);

            Assert.IsTrue(profilePage.profileBioEquals(newBio));
        }


        [TestCase("heaven.org")]
        //[TestCase("pornhub.com")]
        //[TestCase("genius.com")]
        //[TestCase("dypka.ua")]
        public void changeAccountWebsite_NewWebsiteShouldBeDisplayedInTheProfile(string newWebsite)
        {
            ProfileSettingsPage settingsPage = null;
            while (settingsPage == null)
            {
                try
                {
                    settingsPage = homePage.openProfilePage()
                        .openProfileSettingsPage();
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    if (driver.FindElements(By.CssSelector(".RnEpo")).Count != 0)
                    {
                        smartFind(driver, ".HoLwm").Click();
                    }
                }
            }
            settingsPage.sendWebsite(newWebsite);
            Thread.Sleep(3000);
            settingsPage.clickSubmit();

            ProfilePage profilePage = settingsPage.openProfilePage();
            Thread.Sleep(5000);

            Assert.IsTrue(profilePage.profileWebsiteEquals(newWebsite));
        }
    }
}
