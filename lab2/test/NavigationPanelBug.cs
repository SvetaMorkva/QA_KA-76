using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace lab2
{
    public class NavigationPanelBug
    {
        /*
            The following tests are written according to scenerios
            defined in the bug_navigation_panel.feature file
            in the lab2/specs/features directory
        */
        IWebDriver driver;
        string url = "https://www.kpi.ua/";

        [Fact]
        public void TestScheduleLink()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl($"{url}/en");
            // Click on the Schedule icon
            driver.FindElement(By.XPath("//a[@class='icon rozklad']")).Click();
            // Select the Class Schedule option
            driver.FindElement(By.XPath("//a[contains(text(), 'Class Schedule')]")).Click();
            int actual = driver.FindElements(By.XPath("//input")).Count;

            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.XPath("//a[@class='icon rozklad']")).Click();
            driver.FindElement(By.XPath("//a[contains(text(), 'Розклад занять')]")).Click();
            int expected = driver.FindElements(By.XPath("//input")).Count;
            // Since there is a bug on the website this values will not be equal
            Assert.NotEqual(expected, actual);
            driver.Close();
        }

        // [Fact]
        // public void TestCampusLink()
        // {
        //     var driver = new ChromeDriver();
        //     driver.Navigate().GoToUrl($"{this.url}/en");
        //     // Click on the ECampus icon
        //     driver.FindElementByXPath("//a[@class='icon ecampus']").Click();
        //     // In the popup menu select E-Campus option
        //     driver.FindElementByXPath("//a[contains(text(), 'E-Campus')]").Click();
        //     // Find navigation bar
        //     int actual = driver.FindElementsByXPath("//nav/a[@class='navbar-brand']").Count;

        //     driver.Navigate().GoToUrl(url);
        //     driver.FindElementByXPath("//a[@class='icon ecampus']").Click();
        //     driver.FindElementByXPath("//div[@id='ecampusModal']//a[contains(text(), 'Електронний кампус')]").Click();
        //     int expected = driver.FindElementsByXPath("//nav/a[@class='navbar-brand']").Count;
        //     // Since there is a bug on the website values will not be equal
        //     Assert.NotEqual(expected, actual);
            // driver.Close();
        // }

        // [Fact]
        // public void TestMediaLink()
        // {
        //     var driver = new ChromeDriver();
        //     driver.Navigate().GoToUrl(url);
        //     // Find the Media icon on the web page and click on it
        //     driver.FindElementByXPath("//a[@class='icon wcams']").Click();
        //     // When a manu occures select 'Web-камери' option
        //     driver.FindElementByXPath("//a[contains(text(), 'Web-камери')]").Click();
        //     // Check if the page contains links to web cams
        //     int num_cams_ua = 0;
        //     for(int i=1; i<7 && i!=4; i++)
        //     {   // Note that there is no web cam 4 on the web page
        //         num_cams_ua += driver.FindElementsByXPath($"//a[@href='/cam{i}']").Count;
        //     }
        //     driver.Navigate().GoToUrl($"{this.url}/en");
        //     // Find the Media icon on the web page and click on it
        //     driver.FindElementByXPath("//a[@class='icon wcams']").Click();
        //     // When a manu occures select 'Web-камери' option
        //     driver.FindElementByXPath("//a[contains(text(), 'Webcams')]").Click();
        //     // Check if the page contains links to web cams
        //     int num_cams_en = 0;
        //     for(int i=1; i<7 && i!=4; i++)
        //     {   // Note that there is no web cam 4 on the web page
        //         num_cams_en += driver.FindElementsByXPath($"//a[@href='/cam{i}']").Count;
        //     }
        //     // If there is not the same number of web cams, then there is a bug
        //     Assert.NotEqual(num_cams_ua, num_cams_en);
        // driver.Close();
        // }
    }
}
