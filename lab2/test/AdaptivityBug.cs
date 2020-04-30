using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace lab2
{
    public class AdaptivityBug : IDisposable
    {
        /*
            The following tests are written according to scenerios
            defined in the bug_in_adaptivity.feature file
            in the lab2/specs/features directory
        */

        IWebDriver driver;
        string url = "https://www.kpi.ua/";

        // Setup code.
        public AdaptivityBug()
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

        // Tests
        [Fact]
        public void TestSearchIcon()
        {
            Console.WriteLine("I am working!");
            for(int i=0; i<8; i++)
            {
                ZoomOut();
            }
        }

        // Utility functions.
        public void ZoomIn()
        {
            new Actions(driver)
                .SendKeys(Keys.Control)
                .SendKeys(Keys.Add)
                .Perform();
        }

        public void ZoomOut()
        {
            new Actions(driver)
                .SendKeys(Keys.Control).SendKeys(Keys.Subtract)
                .Perform();
        }
    }
}
