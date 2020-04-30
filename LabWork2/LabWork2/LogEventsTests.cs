using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;

namespace LabWork2
{
    [TestFixture]
    public class LogEventsTests
    {
        private HubSpot _hubSpot = new HubSpot();
        [Test]
        [Obsolete]
        public void TestLogMeeting()
        {
            _hubSpot.driver = new ChromeDriver();
            if (!_hubSpot.IsLoggedIn())
            {
                _hubSpot.Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2");
            }
            int contactID = 501;
            String meetingDescription = "Meeting Descripti1on";

            int result = _hubSpot.LogMeeting(contactID, meetingDescription);

            Assert.AreEqual(1, result);
        }

        [Test]
        [Obsolete]
        public void TestLogCall()
        {
            _hubSpot.driver = new ChromeDriver();

            if (!_hubSpot.IsLoggedIn())
            {
                _hubSpot.Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2");
            }
            int contactID = 501;
            String callDescription = "Call Descriptio1n";

            int result = _hubSpot.LogCall(contactID, callDescription);

            Assert.AreEqual(1, result);
        }

        [Test]
        [Obsolete]
        public void TestLogEmail()
        {
            _hubSpot.driver = new ChromeDriver();

            if (!_hubSpot.IsLoggedIn())
            {
                _hubSpot.Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2");
            }
            int contactID = 501;
            String emailDescription = "Email Descript1ion";

            int result = _hubSpot.LogEmail(contactID, emailDescription);

            Assert.AreEqual(1, result);
        }
        [TearDown]
        public void CleanUp()
        {
            _hubSpot.driver.Quit();
        }

    }

}
