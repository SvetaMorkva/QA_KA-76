using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;

namespace LabWork2
{
    [TestFixture]
    public class ContactsTests
    {
        private HubSpot _hubSpot = new HubSpot();

        [Test]
        [Obsolete]
        public void TestAddContact()
        {
            _hubSpot.driver = new ChromeDriver();
            // arange
            if (!_hubSpot.IsLoggedIn())
            {
                _hubSpot.Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2");
            }
            int index = 35;

            // act
            _hubSpot.CreateContact($"Test{index}", $"User{index}", $"test{index}@email.com", "Front-End developer");

            //assert
            String[] urlParametres = _hubSpot.driver.Url.Split('/');
            Assert.AreEqual("contact", urlParametres[urlParametres.Length - 2]);
        }


        [Test]
        [Obsolete]
        public void TestAddTask()
        {
            _hubSpot.driver = new ChromeDriver();
            if (!_hubSpot.IsLoggedIn())
            {
                _hubSpot.Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2");
            }
            int index = 21;
            String taskTitle = $"Test Task {index}";
            _hubSpot.CreateTask(taskTitle, $"Test Description {index}");

            var taskTitles = _hubSpot.driver.FindElementsByCssSelector("span[data-selenium-test='timeline-editable-title']");
            Assert.AreEqual(taskTitles[0].Text, taskTitle);
        }

        [Test]
        [Obsolete]
        public void TestDeleteContact()
        {
            _hubSpot.driver = new ChromeDriver();
            if (!_hubSpot.IsLoggedIn())
            {
                _hubSpot.Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2");
            }
            int amount2Delete = 1;
            int deletedAmount = _hubSpot.DeleteContact(amount2Delete);

            Assert.AreEqual(deletedAmount, amount2Delete);
        }


        [Test]
        [Obsolete]
        public void TestDeleteTasks()
        {
            _hubSpot.driver = new ChromeDriver();
            if (!_hubSpot.IsLoggedIn())
            {
                _hubSpot.Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2");
            }
            int contactID = 851;
            int amount2Delete = 1;
            int deletedAmount = _hubSpot.DeleteTask(contactID, amount2Delete);

            Assert.AreEqual(deletedAmount, amount2Delete);
        }

        [Test]
        [Obsolete]
        public void TestEditContact()
        {
            _hubSpot.driver = new ChromeDriver();
            if (!_hubSpot.IsLoggedIn())
            {
                _hubSpot.Login("vzalevskyi24@gmail.com", "P8naM$HWNe?JLC2");
            }
            int contactID = 851;
            String lastName2ChangeFor = "TestSecondName";

            _hubSpot.EditContactLastName(contactID, lastName2ChangeFor);

            String newLastName = _hubSpot.driver.FindElementByCssSelector("input[data-selenium-test='property-input-lastname']").GetAttribute("value");
            Assert.AreEqual(lastName2ChangeFor, newLastName);
        }
        [TearDown]
        public void CleanUp()
        {
            _hubSpot.driver.Quit();
        }
    }
}
