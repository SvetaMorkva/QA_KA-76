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
            in the lab2/specs/features directory
        */
        IWebDriver driver;
        string url = "https://www.kpi.ua/";
        
        // Setup code.
        public SearchIconBug()
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

        [Fact]
        public void TestSearchIcon()
        {
            // Click on the 'Відпочинок' icon
            driver.FindElement(By.XPath("//a[@class='icon relax']")).Click();
            // Click on the search icon (magnifier)
            driver.FindElement(By.XPath("//a[@id='main-nav-search-link']")).Click();
        }
    }
}
