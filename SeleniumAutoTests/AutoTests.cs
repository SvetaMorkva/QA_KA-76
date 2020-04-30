using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Threading;


namespace SeleniumAutoTests
{
	[TestFixture]
	public class AutoTests
	{
		private string homepage = "https://www.twirpx.com/";
		private string email = "wellcat@ukr.net";
		private string password = "epamtesting";
		private string profileId = "41308682";

		private IWebDriver driver;


		[SetUp]
		public void TestInitialize()
		{
			driver = new ChromeDriver(Environment.CurrentDirectory);
			driver.Navigate().GoToUrl(homepage);
			driver.FindElement(By.Id("AuthEmail")).SendKeys(email);
			var input = driver.FindElement(By.Id("AuthPassword"));
			input.SendKeys(password);
			input.Submit();
		}

		[TearDown]
		public void TestFinalize()
		{
			driver.Quit();
		}

	
		public static void waitUntilExistsByXPath(IWebDriver driver, string selector)
		{
			new WebDriverWait(driver, TimeSpan.FromSeconds(10)).
				Until(ExpectedConditions.ElementExists(By.XPath(selector)));
		}
		public static IWebElement smartFind(IWebDriver driver, string selector)
		{
			waitUntilExistsByXPath(driver, selector);
			return driver.FindElement(By.XPath(selector));
		}




		[Test]
		public void TestLogin()
		{

			var actual = driver.FindElement(By.XPath("//div[@class = 'welcome-box']/ul/li[1]/ins")).GetAttribute("innerText").Trim();
			var expected = "wellcat";
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TestNewInfo()
		{
			driver.Navigate().GoToUrl(homepage + "private/");
			driver.FindElement(By.XPath("//a[@href ='/private/info-update/']")).Click();
			var input = driver.FindElement(By.Name("Title"));
			input.Clear();
			input.SendKeys("wellcat");
			input.Submit();

			var actual = driver.FindElement(By.XPath("//div[contains(@class, 'content-container')]/h1")).GetAttribute("innerText").Trim();
			var expected = "Данные профиля изменены";
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TestLookAtDownloadedFiles()
		{
			driver.Navigate().GoToUrl(homepage + "private/");
			driver.FindElement(By.XPath("//a[@href ='/private/files-downloaded/']")).Click();
			var actual = driver.FindElement(By.TagName("h1")).GetAttribute("innerText").Trim();
			var expected = "Мои скачанные файлы";
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TestFAQAndLeaveComment()
		{
			driver.FindElement(By.XPath("//a[@href ='/about/faq/']")).Click();
			driver.FindElement(By.XPath("//div[@class = 'add-link']/a")).Click();
			//sleep
			//???
			var comment = "Thanks for this site! Its great!";
			var input = driver.FindElement(By.XPath("//textarea[@class = 'markItUpEditor']"));
			input.SendKeys(comment);
			input.Submit();
			try
			{
				var error = driver.FindElement(By.XPath("//div[@class = 'validation-summary-valid']/ul/li[1]"));
				var errorMessage = "Вы добавили слишком много комментариев за короткий промежуток времени, пожалуйста подождите некоторое время перед отправкой";
				Assert.AreEqual(errorMessage, error.Text);
			}
			catch (Exception)
			{

				var actual = driver.FindElement(By.XPath($"//div[@data-sender-id = '{profileId}']/div[contains(@class, 'bb')]")).GetAttribute("innerText").Trim();
				var expected = comment;
				Assert.AreEqual(expected, actual);
			}
			
		}

		[Test]
		public void TestCreatePostInAccount()
		{
			driver.Navigate().GoToUrl(homepage + "private/");
			driver.FindElement(By.XPath("//a[@href ='/post/add/']")).Click();
			var rand = new Random();
			var title = "Test title" + rand.Next();
			var text = "Test text" + rand.Next();

			driver.FindElement(By.XPath("//input[@id = 'Title']")).SendKeys(title);
			var input = driver.FindElement(By.XPath("//textarea[@id = 'BB']"));
			input.SendKeys(text);
			input.Submit();

			var actual = driver.FindElement(By.XPath("//h1[@itemprop = 'name']")).GetAttribute("innerText").Trim();
			var expected = title;
			Assert.AreEqual(expected, actual);
		}
		[Test]
		public void TestAddCommentToProfile()
		{
			//Given
			driver.Navigate().GoToUrl(homepage + $"user/{profileId}/");
			//When
			driver.FindElement(By.XPath("//div[@class = 'add-link']/a")).Click();
			//Then
			var comment = "Greate bro, thanks!";
			var input = driver.FindElement(By.XPath("//textarea[@class = 'markItUpEditor']"));
			input.SendKeys(comment);
			input.Submit();

			var actual = driver.FindElement(By.XPath($"//div[@data-sender-id = '{profileId}']/div[contains(@class, 'bb')]")).GetAttribute("innerText").Trim();
			var expected = comment;
			Assert.AreEqual(expected, actual);

		}


		[Test]
		public void TestAddOrEditStatus()
		{
			//a[@data-dispatch = 'userheadline-add']
			driver.Navigate().GoToUrl(homepage + $"user/{profileId}/");
			IWebElement link;
			try
			{
				driver.FindElement(By.XPath("//div[@data-empty = 'True']"));
				link = smartFind(driver, "//a[@data-dispatch = 'userheadline-add']");
			}
			catch (Exception)
			{
				link = smartFind(driver, "//a[@data-dispatch = 'userheadline-edit']");
			}
			link.Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

			var status = "My cool status";
			var input = smartFind(driver, "//fieldset/textarea");

			input.Clear();
			input.SendKeys(status);

			smartFind(driver, "//fieldset[@class = 'buttons']/a[contains(@class, 'blue')]").Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
			var actual = smartFind(driver, "//div[@class = 'headline-text']").GetAttribute("innerText").Trim();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
			var expected = status;
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TestDeleteStatusOrCheckDeleteButton()
		{

			driver.Navigate().GoToUrl(homepage + $"user/{profileId}/");

			try
			{
				var status = driver.FindElement(By.XPath("//div[@data-empty = 'False']"));
				driver.FindElement(By.XPath("//a[@data-dispatch = 'userheadline-delete']")).Click();
				IAlert jsAlert = driver.SwitchTo().Alert();
				jsAlert.Accept();
				//check  driver.FindElement(By.XPath("//div[@class = 'headline-text']")) is null
				try
				{
					driver.FindElement(By.XPath("//div[@class = 'headline-text']"));
					Assert.True(true);
				}
				catch (NoSuchElementException ex)
				{
					Assert.True(false);
				}
			}
			catch (Exception)
			{
				var link = driver.FindElement(By.XPath("//a[@data-dispatch = 'userheadline-delete']"));
				string display = link.GetCssValue("display");
				Assert.AreEqual("none", display);
			}


		}

	}
}