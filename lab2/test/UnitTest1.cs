using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace test
{
    public class UnitTest1
    {
        IWebDriver _driver = new ChromeDriver("./test/bin/Debug/netcoreapp3.1/");
        [Fact]
        public void Test1()
        {
            _driver.Navigate().GoToUrl("https://www.epam.com/");
            Assert.True(true);
        }
    }
}
