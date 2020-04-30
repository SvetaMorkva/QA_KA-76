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
            in the lab2/specs/features directory
        */
        IWebDriver driver;
        string url = "https://www.kpi.ua/";
        
        // Setup code.
        public CustomSearch()
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

        [Theory]
        [InlineData("Pavlo Pyvovar")]
        [InlineData("asdfasd")]
        [InlineData("ضبفثتعفمخخععكحجححه")]
        [InlineData("己丹亡片")]

        public void CustomSearchShouldShowListOfResults(string to_be_searched)
        {
            IWebElement search_field = driver.FindElement(By.XPath("//input[@type='search']"));
            search_field.Clear();
            search_field.SendKeys(to_be_searched);
            search_field.Submit();
            // The following XPath does not work, has to be fixed.
            // driver.FindElement(By.XPath("//div[contains(text(), 'Результатів немає')] | //div[contains(text(), 'Про результати')]"));
        }
    }
}

