using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace lab2
{
    public class TextTranslationBug : IDisposable
    {
        /*
            The following tests are written according to scenerios
            defined in the bug_with_text_translation.feature file
            in the lab2/specs/features directory
        */
        IWebDriver driver;
        string url = "https://www.kpi.ua/";
        
        // Setup code.
        public TextTranslationBug()
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
        public void ThereShouldOnlyBeEnglish()
        {
        }
    }
}
