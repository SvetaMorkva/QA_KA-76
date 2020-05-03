using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAutoTests.PageObjects
{
	class PublicProfilePage
	{
		private IWebDriver driver;

		public PublicProfilePage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.XPath, Using = "//div[@class = 'add-link']/a")]
		private IWebElement AddCommentButton;

		[FindsBy(How = How.XPath, Using = "//textarea[@class = 'markItUpEditor']")]
		private IWebElement CommentTextArea;


		[FindsBy(How = How.XPath, Using = "//div[@data-sender-id = '41308682']/div[contains(@class, 'bb')]")]
		private IWebElement LeftComment;


		[FindsBy(How = How.XPath, Using = "//div[@class = 'validation-summary-valid']/ul/li[1]")]
		private IWebElement ErrorMessage;

		[FindsBy(How = How.XPath, Using = "//a[@data-dispatch = 'userheadline-add']")]
		IWebElement AddStatusButton;

		[FindsBy(How = How.XPath, Using = "//a[@data-dispatch = 'userheadline-edit']")]
		IWebElement EditStatusButton;

		[FindsBy(How = How.XPath, Using = "//a[@data-dispatch = 'userheadline-delete']")]
		IWebElement DeleteStatusButton;

		[FindsBy(How = How.XPath, Using = "//fieldset/textarea")]
		IWebElement StatusTextArea;

		[FindsBy(How = How.XPath, Using = "//fieldset[@class = 'buttons']/a[contains(@class, 'blue')]")]
		IWebElement ConfirmStatusButton;

		[FindsBy(How = How.XPath, Using = "//div[@class = 'headline-text']")]
		IWebElement StatusField;

		internal string LeaveComment(string comment)
		{
			SeleniumHelper.waitFor(driver, AddCommentButton);
			AddCommentButton.Click();
			SeleniumHelper.waitFor(driver, CommentTextArea);

			CommentTextArea.SendKeys(comment);
			CommentTextArea.Submit();

			SeleniumHelper.waitFor(driver, LeftComment);

			return LeftComment.GetAttribute("innerText").Trim();
		}

		internal object GetErrorMessage()
		{
			SeleniumHelper.waitFor(driver, ErrorMessage);

			return ErrorMessage.GetAttribute("innerText").Trim();
		}

		internal string AddOrEditStatus(string status)
		{
			IWebElement link;
			try
			{
				driver.FindElement(By.XPath("//div[@data-empty = 'True']"));
				SeleniumHelper.waitFor(driver, AddStatusButton);
				link = AddStatusButton;
			}
			catch (Exception)
			{
				SeleniumHelper.waitFor(driver, EditStatusButton);
				link = EditStatusButton;
			}

			link.Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

			SeleniumHelper.waitFor(driver, StatusTextArea);
			StatusTextArea.Clear();
			StatusTextArea.SendKeys(status);

			SeleniumHelper.waitFor(driver, ConfirmStatusButton);
			ConfirmStatusButton.Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

			SeleniumHelper.waitFor(driver, StatusField);
			return StatusField.GetAttribute("innerText").Trim();

		}

		internal bool DeleteComment()
		{
			var status = driver.FindElement(By.XPath("//div[@data-empty = 'False']"));

			SeleniumHelper.waitFor(driver, DeleteStatusButton);
			DeleteStatusButton.Click();

			IAlert jsAlert = driver.SwitchTo().Alert();
			jsAlert.Accept();
			try
			{
				StatusField.Click();
				return true;
			}
			catch (NoSuchElementException ex)
			{
				return false;
			}
		}

		internal string GetDeleteButtonDisplayProperty()
		{
			return DeleteStatusButton.GetCssValue("display");
		}
	}
}
