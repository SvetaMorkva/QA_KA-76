using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;

namespace LabWork2
{
    [TestFixture]
    public class GeneralTests
    {
        private HubSpot _hubSpot = new HubSpot();

        [Test]
        [Obsolete]
        public void TestLogin()
        {
            _hubSpot.driver = new ChromeDriver();

            _hubSpot.Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2");


            String currentURL = _hubSpot.driver.Url;
            Assert.AreEqual("https://app.hubspot.com/getting-started/7486179", currentURL);

            _hubSpot.driver.Close();
        }

        [Test]
        [Obsolete]
        public void TestAddCompany()
        {
            _hubSpot.driver = new ChromeDriver();

            if (!_hubSpot.IsLoggedIn())
            {
                _hubSpot.Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2");
            }
            int index = 35;
            _hubSpot.CreateComany($"test{index}.company", $"Test Company {index}", $"Test Description {index}");

            String[] urlParametres = _hubSpot.driver.Url.Split('/');
            Console.WriteLine(_hubSpot.driver);
            Assert.AreEqual("company", urlParametres[urlParametres.Length - 2]);
        }

        [Test]
        [Obsolete]
        public void TestSearchInGoogle()
        {
            _hubSpot.driver = new ChromeDriver();

            if (!_hubSpot.IsLoggedIn())
            {
                _hubSpot.Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2");
            }
            int contactId = 501;
            String[] googleRedirectUrl = _hubSpot.SearchInGoogle(contactId).Split('=');
            String[] currentUrl = _hubSpot.driver.Url.Split('=');
            Assert.AreEqual(googleRedirectUrl[googleRedirectUrl.Length - 1], currentUrl[currentUrl.Length - 1]);
        }


        [Test]
        [Obsolete]
        public void TestSignOut()
        {
            _hubSpot.driver = new ChromeDriver();

            if (!_hubSpot.IsLoggedIn())
            {
                _hubSpot.Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2");
            }
            _hubSpot.SignOut();
            Assert.AreEqual(_hubSpot.driver.Url, "https://app.hubspot.com/login");
        }

        [TearDown]
        public void CleanUp()
        {
            _hubSpot.driver.Quit();
        }
    }
}
