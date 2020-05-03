using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAutoTests.PageObjects
{
	class HomePage
	{


		private IWebDriver driver;

		public HomePage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		internal void Login(string email, string password)
		{
			SeleniumHelper.waitFor(driver, EmailField);
			EmailField.SendKeys(email);
			SeleniumHelper.waitFor(driver, PasswordField);
			PasswordField.SendKeys(password);

			PasswordField.Submit();

		}

		[FindsBy(How = How.Id, Using = "AuthEmail")]
		IWebElement EmailField;
		[FindsBy(How = How.Id, Using = "AuthPassword")]
		IWebElement PasswordField;

		[FindsBy(How = How.XPath, Using = "//div[@class = 'welcome-box']/ul/li[1]/ins")]
		IWebElement UserName;

		[FindsBy(How = How.XPath, Using = "//a[@href ='/private/']")]
		IWebElement PrivateAccount;

		[FindsBy(How = How.XPath, Using = "//a[@href ='/about/faq/']")]
		IWebElement FAQ;

		[FindsBy(How = How.XPath, Using = "//a[@href = '/user/41308682/']")]
		IWebElement PublicProfile;


		internal object GetUserName()
		{
			return UserName.GetAttribute("innerText").Trim();
		}

		internal void GoToProfilePage()
		{
			PrivateAccount.Click();
		}

		internal void GoToFAQPage()
		{
			FAQ.Click();
		}

		internal void GoToPublicProfilePage()
		{
			PublicProfile.Click();
		}
	}
}
