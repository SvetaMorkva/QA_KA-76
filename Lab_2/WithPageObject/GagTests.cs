using ImplementPageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UsePageObject
{
    [TestFixture]
    public class GagTests
    {
        private IWebDriver driver;
        private GagPage gagPage;
        private string _url = "https://9gag.com/";

        [SetUp]
        public void TestInit()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(_url);
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => d.Url = _url);
            gagPage = new GagPage(driver);
        }
        [TearDown]
        public void TestFinalize()
        {
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void DarkTheme()
        {
            
            gagPage.SetDarkMode();

            using (new AssertionScope())
            {
                gagPage.DarkmodeActivated.Should().BeTrue();
            }


        }
        [Test]
        public void FunnyCategoryIsStarred()
        {
            gagPage.StarFunnyCategory();

            using (new AssertionScope())
            {
                gagPage.CategorieIsStarred.Should().BeTrue();
            }
        }
        [Test]
        public void AwesomeCategoryIsStarred()
        {
            gagPage.StarAwesomeCategory();

            using (new AssertionScope())
            {
                gagPage.CategorieIsStarred.Should().BeTrue();
            }
        }

        [Test]
        public void CoronavirusCategoryIsStarred()
        {
            gagPage.StarCoronavirusCategory();

            using (new AssertionScope())
            {
                gagPage.CategorieIsStarred.Should().BeTrue();
            }
        }

        [Test]
        public void GamingCategoryIsStarred()
        {
            gagPage.StarGamingCategory();

            using (new AssertionScope())
            {
                gagPage.CategorieIsStarred.Should().BeTrue();
            }
        }

        [Test]
        public void AnimalsCategoryIsStarred()
        {
            gagPage.StarAnimalsCategory();

            using (new AssertionScope())
            {
                gagPage.CategorieIsStarred.Should().BeTrue();
            }
        }

        [Test]
        public void UnregisteredUprateAttempt()
        {
            gagPage.UnauthorisedUprate();

            using (new AssertionScope())
            {
                gagPage.InvitationToRegisterOrLoginIsVisible.Should().BeTrue();
                gagPage.CaptionContainsHeyThere.Should().BeTrue();
            }
        }

        [Test]
        public void UnregisteredDownrateAttempt()
        {
            gagPage.UnauthorisedDownrate();

            using (new AssertionScope())
            {
                gagPage.InvitationToRegisterOrLoginIsVisible.Should().BeTrue();
                gagPage.CaptionContainsHeyThere.Should().BeTrue();
            }
        }

        [Test]
        public void RandomPostNextPost()
        {
            gagPage.OpenRandomPost();

            using (new AssertionScope())
            {
                gagPage.PostPageIsVisible.Should().BeTrue();
            }
        }
    }
 }
