using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace lab2
{
    public class CustomSearch : IDisposable
    {
        /*
            The following tests are written according to scenerios
            defined in the bug_with_text_translation.feature file
            in the lab2/specs/features directory. This class is an
            improved version of the NavigationPanelBug class in the
            test_part1 folder. The PageObjects namespace was used
            to improve the class.
        */
        IWebDriver driver;
        string url = "https://kpi.ua/";
        
        // Setup code.
        public CustomSearch()
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

        [Theory]
        [InlineData("Pavlo Pyvovar", "Про результати")]
        [InlineData("asdfasd", "Результатів немає")]

        public void CustomSearchShouldShowListOfResults(string to_be_searched, string expected)
        {
            var kpiUaPage = new KpiUaPage(driver);
            kpiUaPage.searchField.Clear();
            kpiUaPage.searchField.SendKeys(to_be_searched);
            kpiUaPage.searchField.Submit();
            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
            .Until(driver => driver.FindElement(By.XPath($"//div[contains(text(), '{expected}')]")));
            Assert.True(kpiUaPage.DivContains(expected));
        }
    }
}

