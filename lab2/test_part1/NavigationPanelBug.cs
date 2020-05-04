using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace lab2
{
    public class NavigationPanelBug : IDisposable
    // The IDisposable interface is used to define cleanup code.
    {
        /*
            The following tests are written according to scenerios
            defined in the bug_navigation_panel.feature file
            in the lab2/specs/features directory.
        */
        IWebDriver driver;
        string url = "https://www.kpi.ua/";

        // Setup code.
        public NavigationPanelBug()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(url);
            // Wait until browser loads.
            // new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => d.Url == url);
        }

        // Cleanup code.
        public void Dispose()
        {
            driver.Dispose();
        }

        // Tests.
        [Fact]
        public void ScheduleLinkShouldRedirectToPageWithInputFieldForGroup()
        {
            // Act
            // Click on the Розклад icon.
            driver.FindElement(By.XPath("//a[@class='icon rozklad']")).Click();
            // Select the Розклад занять option.
            driver.FindElement(By.XPath("//a[contains(text(), 'Розклад занять')]")).Click();
            // Find the input field for entering the name of the group.
            // If there is an input field, Count will be not 0 (should be 1 in this case).
            int expected = driver.FindElements(By.XPath("//input")).Count;

            // Go to the English version of the website.
            // Clicking on the language switcher at top right side of the screen. 
            driver.Navigate().GoToUrl($"{url}/en");
            // driver.FindElement(By.XPath("//a[@href='/en']")).Click();
            // Click on the Schedule icon.            
            driver.FindElement(By.XPath("//a[@class='icon rozklad']")).Click();
            // Select the Class Schedule option.
            driver.FindElement(By.XPath("//a[contains(text(), 'Class Schedule')]")).Click();
            // There should be an input field just like on the Ukrainian version of the website but
            // there is not, thus Count will be zero.
            int actual = driver.FindElements(By.XPath("//input")).Count;

            // Assert
            // Since there is a bug on the website this values will not be equal
            Assert.NotEqual(expected, actual);
        }

        [Fact]
        public void TestCampusLink()
        {
            // Click on the Кампус icon.
            driver.FindElement(By.XPath("//a[@class='icon ecampus']")).Click();
            // Select Електронний кампус option from the list.
            driver.FindElement(By.XPath("//div[@id='ecampusModal']//a[contains(text(), 'Електронний кампус')]")).Click();
            // On the correct version of the Campus webpage there is a navigation bar.
            int expected = driver.FindElements(By.XPath("//nav/a[@class='navbar-brand']")).Count;

            driver.Navigate().GoToUrl($"{url}/en");
            // Click on the ECampus icon
            driver.FindElement(By.XPath("//a[@class='icon ecampus']")).Click();
            // In the popup menu select E-Campus option
            driver.FindElement(By.XPath("//a[contains(text(), 'E-Campus')]")).Click();
            // Find navigation bar
            int actual = driver.FindElements(By.XPath("//nav/a[@class='navbar-brand']")).Count;

            // Since there is a bug on the website values will not be equal
            Assert.NotEqual(expected, actual);
        }

        [Fact]
        public void TestMediaLink()
        {
            // Find the Медіа icon on the web page and click on it
            driver.FindElement(By.XPath("//a[@class='icon wcams']")).Click();
            // When a menu occures select 'Web-камери' option
            driver.FindElement(By.XPath("//a[contains(text(), 'Web-камери')]")).Click();
            // Check if the page contains links to web cams
            int num_cams_ua = 0;
            for(int i=1; i<7 && i!=4; i++)
            {   // Note that there is no web cam 4 on the web page
                num_cams_ua += driver.FindElements(By.XPath($"//a[@href='/cam{i}']")).Count;
            }
            driver.Navigate().GoToUrl($"{url}/en");
            // Find the Media icon on the web page and click on it
            driver.FindElement(By.XPath("//a[@class='icon wcams']")).Click();
            // When a menu occures select Webcams option
            driver.FindElement(By.XPath("//a[contains(text(), 'Webcams')]")).Click();
            // Check if the page contains links to web cams
            int num_cams_en = 0;
            for(int i=1; i<7 && i!=4; i++)
            {   // Note that there is no web cam 4 on the web page
                num_cams_en += driver.FindElements(By.XPath($"//a[@href='/cam{i}']")).Count;
            }
            // If there is not the same number of web cams, then there is a bug.
            // And indeed kpi.ua/en is almost completely blank
            Assert.NotEqual(num_cams_ua, num_cams_en);
        }
    }
}
