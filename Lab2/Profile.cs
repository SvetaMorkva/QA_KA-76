using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace QA_Lab2
{
    [TestFixture]
    class ProfileEdit : Base
    {
        private IWebElement editButton;

        [Test]
        public void EditClick_ShouldMadeLineEditVisible()
        {
            FillDataForLogin();
            GoToProfile();

            var profileEditLine = driver.FindElements(By.CssSelector("form div[class$=' hide']"));
            wait.Until(d => !editButton.Displayed);
            bool editLineIsVisible = true;

            foreach (var p in profileEditLine)
            {
                if (!p.Displayed)
                {
                    editLineIsVisible = false;
                    break;
                }
            }

            Assert.AreEqual(3, profileEditLine.Count);
            Assert.IsTrue(editLineIsVisible);
        }

        private void GoToProfile()
        {
            nextButton.Click();

            wait.Until(d => driver.FindElement(By.CssSelector("[class*='ztb-p']")));
            driver.FindElement(By.CssSelector("[class*='ztb-p']")).Click();

            wait.Until(d => driver.FindElement(By.Id("ztb-myaccount")));
            System.Threading.Thread.Sleep(3000);
            var myAccount = driver.FindElement(By.Id("ztb-myaccount"));
            myAccount.Click();

            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);

            wait.Until(d => driver.FindElement(By.Id("editprofile")));
            editButton = driver.FindElement(By.Id("editprofile"));
            wait.Until(d => editButton.Enabled && editButton.Displayed);

            editButton.Click();
        }
    }
}
