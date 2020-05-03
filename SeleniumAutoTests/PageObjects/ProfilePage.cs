using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;


namespace SeleniumAutoTests.PageObjects
{
	class ProfilePage
	{
		private IWebDriver driver;

		public ProfilePage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.XPath, Using = "//a[@href ='/private/info-update/']")]
		IWebElement ChangeInfoLink;

		[FindsBy(How = How.Name, Using = "Title")]
		IWebElement ChangeInfoTitle;

		[FindsBy(How = How.XPath, Using = "//div[contains(@class, 'content-container')]/h1")]
		IWebElement ChangeInfoResult;

		[FindsBy(How = How.XPath, Using = "//a[@href ='/private/files-downloaded/']")]
		IWebElement DownloadedFilesLink;

		[FindsBy(How = How.TagName, Using = "h1")]
		IWebElement DownloadedFilesTitle;


		[FindsBy(How = How.XPath, Using = "//a[@href ='/post/add/']")]
		IWebElement CreatePostLink;

		[FindsBy(How = How.XPath, Using = "//input[@id = 'Title']")]
		IWebElement PostTitle;

		[FindsBy(How = How.XPath, Using = "//textarea[@id = 'BB']")]
		IWebElement PostText;

		[FindsBy(How = How.XPath, Using = "//h1[@itemprop = 'name']")]
		IWebElement CreatedPostTitle;



		[FindsBy(How = How.XPath, Using = "//div[@class = 'validation-summary-errors']/ul/li[1]")]
		private IWebElement ErrorMessage;


		internal object ChangeInfo(string newUsername)
		{
			SeleniumHelper.waitFor(driver, ChangeInfoLink);
			ChangeInfoLink.Click();
			ChangeInfoTitle.Clear();
			ChangeInfoTitle.SendKeys(newUsername);
			ChangeInfoTitle.Submit();

			return ChangeInfoResult.GetAttribute("innerText").Trim();
		}

		internal void GoToDownloadedFiles()
		{
			SeleniumHelper.waitFor(driver, DownloadedFilesLink);
			DownloadedFilesLink.Click();
		}

		internal object GetDownloadedFilesTitle()
		{
			return DownloadedFilesTitle.GetAttribute("innerText").Trim();
		}

		internal void GoToCreatePost()
		{
			SeleniumHelper.waitFor(driver, CreatePostLink);
			CreatePostLink.Click();

		}

		internal void CreatePost(string title, string text)
		{
			SeleniumHelper.waitFor(driver, PostTitle);
			PostTitle.SendKeys(title);

			SeleniumHelper.waitFor(driver, PostText);
			PostText.SendKeys(text);
			PostText.Submit();
		}

		internal string GetPostTitle()
		{
			SeleniumHelper.waitFor(driver, CreatedPostTitle);
			return CreatedPostTitle.GetAttribute("innerText").Trim();
		}

		internal object GetErrorMessage()
		{
			SeleniumHelper.waitFor(driver, ErrorMessage);

			return ErrorMessage.GetAttribute("innerText").Trim();
		}

	}
}
