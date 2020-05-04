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
            in the lab2/specs/features directory. This class is an
            improved version of the NavigationPanelBug class in the
            test_part1 folder. The PageObjects namespace was used
            to improve the class.
        */
        IWebDriver driver;
        string url = "https://kpi.ua/";

        // Setup code.
        public NavigationPanelBug()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(url);
            // Wait until browser loads.
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => d.Url == url);
        }

        // Cleanup code.
        public void Dispose()
        {
            driver.Dispose();
        }

        // Tests.
        [Fact]
        public void ScheduleLinkShouldRedirectToPageWithInputField()
        {
            // Arrange.
            var kpiUaPage_ua = new KpiUaPage(driver);
            string id = "rozkladModal";
            int actual = 0;
            int expected = 0;

            // Act.
            kpiUaPage_ua = kpiUaPage_ua.clickOnHeaderIcon(id);
            for(int i=1; i <= 3; i++)
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                .Until(d => d.Url != url);
                kpiUaPage_ua.clickOnTheIthLink(id, i);
                expected += kpiUaPage_ua.Contains("//input");            
                driver.Navigate().Back();
            }

            driver.Navigate().GoToUrl($"{url}/en");
            kpiUaPage_ua = kpiUaPage_ua.clickOnHeaderIcon(id);
            for(int i=1; i <= 3; i++)
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                .Until(d => d.Url != $"{url}/en");
                kpiUaPage_ua.clickOnTheIthLink(id, i);
                actual += kpiUaPage_ua.Contains("//input");            
                driver.Navigate().Back();
            }

            // Assert.
            // Not equal since there is a bug on the page.
            Assert.NotEqual(actual, expected);
        }

        // [Fact]
        // public void TestLibraLink()
        // {
        //     // Arrange.
        //     var kpiUaPage_ua = new KpiUaPage(driver);
        //     string id = "libraModal";
        //     string [] titles = new string[3];
        //     titles[0] = "Науково-технічна бiблiотека ім. Г. І. Денисенка |";
        //     titles[1] = "KPI01 - Простий пошук";
        //     titles[2] = "ELAKPI: Home";

        //     // Act.
        //     kpiUaPage_ua = kpiUaPage_ua.clickOnHeaderIcon(id);

        //     for(int i=0; i<3; i++)
        //     {
        //         kpiUaPage_ua.clickOnTheIthLink(id, i+1);
        //         // Assert.
        //         Assert.True(driver.Title == titles[i]);
        //         driver.Navigate().Back();
        //     }
        // }

        [Fact]
        public void TestCampusLink()
        {
            // Arrange.
            var kpiUaPage_ua = new KpiUaPage(driver);
            string id = "ecampusModal";
            int actual = 0;
            int expected = 0;

            // Act.
            kpiUaPage_ua = kpiUaPage_ua.clickOnHeaderIcon(id);
            kpiUaPage_ua.clickOnTheIthLink(id, 1);
            expected += kpiUaPage_ua.Contains("//input");

            driver.Navigate().GoToUrl($"{url}/en");
            kpiUaPage_ua = kpiUaPage_ua.clickOnHeaderIcon(id);
            kpiUaPage_ua.clickOnTheIthLink(id, 1);
            actual += kpiUaPage_ua.Contains("//input");

            // Assert.
            Assert.NotEqual(expected, actual);
        }

        [Fact]
        public void TestMediaLink()
        {
            // Arrange.
            var kpiUaPage_ua = new KpiUaPage(driver);
            string id = "mediaModal";
            int actual = 0;
            int expected = 0;

            // Act.
            kpiUaPage_ua = kpiUaPage_ua.clickOnHeaderIcon(id);
            kpiUaPage_ua.clickOnTheIthLink(id, 1);

            // Check if the page contains links to web cams
            for(int i=1; i<7 && i!=4; i++)
            {   // Note that there is no web cam 4 on the web page
                expected += kpiUaPage_ua.hasIthWebCam(i);
            }

            driver.Navigate().GoToUrl($"{url}/en");
            kpiUaPage_ua = kpiUaPage_ua.clickOnHeaderIcon(id);
            kpiUaPage_ua.clickOnTheIthLink(id, 1);
            
            for(int i=1; i<7 && i!=4; i++)
            {   // Note that there is no web cam 4 on the web page
                actual += kpiUaPage_ua.hasIthWebCam(i);
            }
            // // If there is not the same number of web cams, then there is a bug.
            // // And indeed kpi.ua/en is almost completely blank
            Assert.NotEqual(expected, actual);
        }
    }
}
