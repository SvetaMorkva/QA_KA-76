using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Threading;
using SeleniumAutoTests.PageObjects;


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
			var home = new HomePage(driver);
			driver.Navigate().GoToUrl(homepage);
			home.Login(email, password);
		}

		[TearDown]
		public void TestFinalize()
		{
			driver.Quit();
		}




		[Test]
		public void TestLogin()
		{
			var home = new HomePage(driver);
			var actual = home.GetUserName();
			var expected = "wellcat";
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TestNewInfo()
		{
			var home = new HomePage(driver);
			var profile = new ProfilePage(driver);
			home.GoToProfilePage();
			var actual = profile.ChangeInfo("wellcat");
			var expected = "Данные профиля изменены";
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TestLookAtDownloadedFiles()
		{
			var home = new HomePage(driver);
			var profile = new ProfilePage(driver);
			home.GoToProfilePage();
			profile.GoToDownloadedFiles();
			var actual = profile.GetDownloadedFilesTitle();
			var expected = "Мои скачанные файлы";
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TestFAQAndLeaveComment()
		{
			var home = new HomePage(driver);
			var faq = new FAQPage(driver);
			home.GoToFAQPage();
			var comment = "Thanks for this site! Its great!";
		

			try
			{
				var actual = faq.LeaveComment(comment);
				var expected = comment;
				Assert.AreEqual(expected, actual);

			}
			catch (Exception)
			{
				var error = faq.GetErrorMessage();
				var errorMessage = "Вы не можете оставить комментарий на этой странице";
				Assert.AreEqual(errorMessage, error);
			}
			
		}

		[Test]
		public void TestCreatePostInAccount()
		{
			var home = new HomePage(driver);
			var profile = new ProfilePage(driver);
			home.GoToProfilePage();

			var rand = new Random();
			var title = "Test title" + rand.Next();
			var text = "Test text" + rand.Next();

			profile.GoToCreatePost();
			try
			{


			profile.CreatePost(title, text);
			var actual = profile.GetPostTitle();	
			var expected = title;
			Assert.AreEqual(expected, actual);
			}
			catch (Exception)
			{
				var error = profile.GetErrorMessage();
				var errorMessage = "Вы не можете создавать новые посты";
				Assert.AreEqual(errorMessage, error);
			}
		}
		[Test]
		public void TestAddCommentToProfile()
		{
			var home = new HomePage(driver);
			var publicAcc = new PublicProfilePage(driver);
			home.GoToPublicProfilePage();

			var comment = "Greate bro, thanks!";


			try
			{
				var actual = publicAcc.LeaveComment(comment);
				var expected = comment;
				Assert.AreEqual(expected, actual);

			}
			catch (Exception)
			{
				var error = publicAcc.GetErrorMessage();
				var errorMessage = "Вы не можете оставить комментарий на этой странице";
				Assert.AreEqual(errorMessage, error);
			}

		}


		[Test]
		public void TestAddOrEditStatus()
		{

			var home = new HomePage(driver);
			var publicAcc = new PublicProfilePage(driver);

			home.GoToPublicProfilePage();

			string status = "My cool status";
			var actual = publicAcc.AddOrEditStatus(status);
	
			var expected = status;
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TestDeleteStatusOrCheckDeleteButton()
		{
			var home = new HomePage(driver);
			var publicAcc = new PublicProfilePage(driver);

			home.GoToPublicProfilePage();
		
			try
			{
				bool isDeleted = publicAcc.DeleteComment();
				Assert.True(isDeleted);
			}
			catch (Exception)
			{
				string display = publicAcc.GetDeleteButtonDisplayProperty();
				Assert.AreEqual("none", display);
			}
		}

	}
}