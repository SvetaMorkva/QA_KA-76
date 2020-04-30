using System;
using Xunit;
using OpenQA.Selenium.Chrome;

namespace lab2
{
    public class SearchIconBug
    {
        /*
            The following tests are written according to scenerios
            defined in the bug_in_search.feature file
            in the lab2/specs/features directory
        */
        [Fact]
        public void TestSearchIcon()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.kpi.ua/");
            // Click on the 'Відпочинок' icon
            driver.FindElementByXPath("//a[@class='icon relax']").Click();
            // Click on the search icon (magnifier)
            driver.FindElementByXPath("//a[@id='main-nav-search-link']").Click();
        }
    }
}
