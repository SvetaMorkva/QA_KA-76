using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        //private string path = System.AppDomain.CurrentDomain.BaseDirectory + "Selenium";



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
            //options.AddArguments(@"user-data-dir=" + path);

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(url);

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == url);


            smartFind(driver, ".FBi-h+ .-MzZI .zyHYP").SendKeys(username);
            smartFind(driver, ".-MzZI+ .-MzZI .zyHYP").SendKeys(password);
            smartFind(driver, ".-MzZI+ .DhRcB").Click();

            Thread.Sleep(3000);

            //There's a dumb notification dialog (-_-)
            if (driver.FindElements(By.CssSelector(".piCib")).Count != 0)
            {
                smartFind(driver, ".HoLwm").Click();
            }


            waitUntilExists(driver, ".Fifk5 ._6q-tv");
            
            mainPage = new PageObject(driver);

            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        [TearDown]
        public void TestFinalize()
        {
            driver.Quit();
        }


        [Test]
        public void findNataliePortmanWithSearch()
        {
            mainPage.startSearchInput().SendKeys("natalieportman");
            smartFind(driver, ".yCE8d:nth-child(1)").Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver =>
                    driver.Url == "https://www.instagram.com/natalieportman/");

            IWebElement verificationBadge = smartFind(driver, ".coreSpriteVerifiedBadge");

            Assert.IsTrue(verificationBadge.Displayed);
        }

        [Test]
        public void sendMessageToAnotherAccount()
        {
            string messageReceiver = "et.irremissibile";

            mainPage.openInboxPage();
            //find and click a "new message" button
            smartFind(driver, ".wpO6b").Click();
            //find an input search field and paste the username
            smartFind(driver, ".j_2Hd").SendKeys(messageReceiver);
            //choose the first one suggested
            smartFind(driver, ".-qQT3:nth-child(1) .HVWg4").Click();
            //click "next"
            smartFind(driver, ".cB_4K").Click();
            //the dialog with the chosen person must be opened
            smartFind(driver, ".vy6Bb").GetAttribute("innerHTML").Contains(messageReceiver);
            //type a message
            smartFind(driver, ".ItkAi textarea").SendKeys("wazzup");
            smartFind(driver, ".ItkAi textarea").SendKeys(Keys.Enter);
            //the message must be sent and there should be no "..." icon near the message
            Thread.Sleep(3000);
            
            Assert.IsTrue(driver.FindElements(By.CssSelector(".FeN85")).Count == 0);
        }

        [Test]
        public void likeRandomPost()
        {
            string irra_url = "https://www.instagram.com/et.irremissibile/";
            //lets open my main account and like the first post
            driver.Navigate().GoToUrl(irra_url);
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
    }
}
