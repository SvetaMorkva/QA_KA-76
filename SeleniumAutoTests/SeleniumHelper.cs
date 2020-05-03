using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAutoTests
{
	class SeleniumHelper
	{
		public static void waitUntilExistsByXPath(IWebDriver driver, string selector)
		{
			new WebDriverWait(driver, TimeSpan.FromSeconds(2)).
				Until(ExpectedConditions.ElementExists(By.XPath(selector)));
		}
		public static IWebElement smartFind(IWebDriver driver, string selector)
		{
			waitUntilExistsByXPath(driver, selector);
			return driver.FindElement(By.XPath(selector));
		}
		public static void waitFor(IWebDriver driver, IWebElement element)
		{
			new WebDriverWait(driver, TimeSpan.FromSeconds(2))
			.Until(ExpectedConditions.ElementToBeClickable(element));
		}
	}
}
