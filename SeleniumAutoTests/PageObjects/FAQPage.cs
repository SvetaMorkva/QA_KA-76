using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SeleniumAutoTests
{
	internal class FAQPage
	{
		private IWebDriver driver;

		public FAQPage(IWebDriver driver)
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


		[FindsBy(How = How.XPath, Using = "//div[@class = 'validation-summary-errors']/ul/li[1]")]
		private IWebElement ErrorMessage;

		internal string LeaveComment(string comment )
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
	}
}