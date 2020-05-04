using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.ComponentModel;

namespace ImplementPageObject
{
    public class GagPage
    {
        private IWebDriver _driver;
        public  string categoryLink;
        
        public GagPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "darkmode-toggle")]
        public IWebElement DarkmodeToggle;

        [FindsBy(How = How.TagName, Using = "body")]
        public IWebElement Body;

        [FindsBy(How = How.XPath, Using = "//li[a[@href='/funny']]/a[@class='button']")]
        public IWebElement funnyCategory;

        [FindsBy(How = How.XPath, Using = "//li[a[@href='/coronavirus']]/a[@class='button']")]
        public IWebElement coronavirusCategory;
        
        [FindsBy(How = How.XPath, Using = "//li[a[@href='/animals']]/a[@class='button']")]
        public IWebElement animalsCategory;

        [FindsBy(How = How.XPath, Using = "//li[a[@href='/awesome']]/a[@class='button']")]
        public IWebElement awesomeCategory;

        [FindsBy(How = How.XPath, Using = "//li[a[@href='/gaming']]/a[@class='button']")]
        public IWebElement gamingCategory;

        [FindsBy(How = How.XPath, Using = "//section[@class = 'shortcut']")]
        public IList<IWebElement> categoriesInShortcut;

        [FindsBy(How = How.XPath, Using = "//article/div[ contains(@class, 'post-afterbar')]/ul/li/a[@class = 'up']")]
        public IWebElement upButton;

        [FindsBy(How = How.XPath, Using = "//article/div[ contains(@class, 'post-afterbar')]/ul/li/a[@class = 'down']")]
        public IWebElement downButton;

        [FindsBy(How = How.CssSelector, Using = "section[class = 'modal']")]
        public IList <IWebElement> modalWindow;

        [FindsBy(How = How.XPath, Using = "//section[@class = 'modal']/section/div/h2")]
        public IWebElement modalWindowCaption;

        [FindsBy(How = How.ClassName, Using = "post-page")]
        public IList<IWebElement> postPage;

        [FindsBy(How = How.XPath, Using = "//nav[@class='nav-menu']/ul/li[contains(a, 'Random')]")]
        public IWebElement navToRandomPost;




        public bool DarkmodeActivated => Body.GetAttribute("class").Equals("theme-dark");
        public bool CategorieIsStarred => categoriesInShortcut.Count() == 1;
        public bool InvitationToRegisterOrLoginIsVisible => modalWindow.Count() > 0;
        public bool CaptionContainsHeyThere => modalWindowCaption.Text.Contains("Hey there!");
        public bool PostPageIsVisible => postPage.Count() > 0;
        
        public GagPage SetDarkMode()
        {
            DarkmodeToggle.Click();
            return this;
        }

        public GagPage StarFunnyCategory()
        {
            funnyCategory.Click();
            return this;
        }

        public GagPage StarAwesomeCategory()
        {
            awesomeCategory.Click();
            return this;
        }

        public GagPage StarCoronavirusCategory()
        {
            coronavirusCategory.Click();
            return this;
        }

        public GagPage StarAnimalsCategory()
        {
            animalsCategory.Click();
            return this;
        }

        public GagPage StarGamingCategory()
        {
            gamingCategory.Click();
            return this;
        }

        public GagPage UnauthorisedUprate()
        {
            upButton.Click();
            return this;
        }

        public GagPage UnauthorisedDownrate()
        {
            downButton.Click();
            return this;
        }

        public GagPage OpenRandomPost()
        {
            navToRandomPost.Click();
            var tabs = _driver.WindowHandles;
            _driver.SwitchTo().Window(tabs[1]);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            return this;
        }
    }
}
