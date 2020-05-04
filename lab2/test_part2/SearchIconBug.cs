using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace lab2
{
    public class SearchIconBug : IDisposable
    {
        /*
            The following tests are written according to scenerios
            defined in the bug_in_search.feature file
            in the lab2/specs/features directory. This class is an
            improved version of the NavigationPanelBug class in the
            test_part1 folder. The PageObjects namespace was used
            to improve the class.
        */
        IWebDriver driver;
        string url = "https://kpi.ua/";
        
        // Setup code.
        public SearchIconBug()
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

        [Fact]
        public void TestSearchIcon()
        {
            var kpiUaPage = new KpiUaPage(driver);
            // Click on the 'Відпочинок' icon
            kpiUaPage.relaxIcon.Click();
            // Click on the search icon (magnifier)
            Assert.True(kpiUaPage.searchIcon.Enabled);
        }
    }
}
