using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
// The PageObjects class has become obsolete and was removed.
// The issue was described in the post at StackOverflow:
// https://stackoverflow.com/questions/48734097/the-name-pagefactory-does-not-exist-in-the-current-context
// using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

namespace lab2
{
    public class KpiUaPage
    {
        /*
            Page object pattern for kpi.ua
        */
        IWebDriver driver;
        public KpiUaPage(IWebDriver _driver)
        {
            driver = _driver;
            PageFactory.InitElements(driver, this);
        }

        // Navigation panel icons.
        [FindsBy(How = How.CssSelector, Using = "[class='icon hostelpay']")]
        public IWebElement hostelPayIcon;

        [FindsBy(How = How.CssSelector, Using = "[class='icon relax']")]
        public IWebElement relaxIcon;

        // Search icon for relax.kpi.ua.
        [FindsBy(How = How.XPath, Using = "//a[@id='main-nav-search-link']")]
        public IWebElement searchIcon;
        
        // Search field for custom search at kpi.ua.
        [FindsBy(How = How.CssSelector, Using = "[type='search']")]
        public IWebElement searchField;

        public bool DivContains(string str) => driver.FindElement(By.XPath($"//div[contains(text(), '{str}')]")).Enabled;

        public int Contains(string XPath) => driver.FindElements(By.XPath(XPath)).Count;
        public int hasIthWebCam(int i) => driver.FindElements(By.XPath($"//a[@href='/cam{i}']")).Count;
        public KpiUaPage clickOnHeaderIcon(string id)
        {
            driver.FindElement(By.XPath($"//a[@href='#{id}']")).Click();
            return this;
        }

        public KpiUaPage clickOnTheIthLink(string id, int i)
        {
            driver.FindElement(By.XPath($"//div[@id='{id}']//div//div/p[{i}]/a")).Click();
            return this;
        }
    }
}
