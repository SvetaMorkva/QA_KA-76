using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace QA_Lab2
{
    [TestFixture]
    public class Login : Base
    {
/*        [Test]
        public void WithoutFilling_ShouldMadeErrorVisible()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(nextButton));
            nextButton.Click();

            var errorMsg = driver.FindElement(By.CssSelector(".fielderror.errorlabel"));
            var errorLineEdit = driver.FindElement(By.CssSelector(".textbox.errorborder"));

            Assert.IsTrue(errorMsg.Displayed && errorLineEdit.Displayed);
        }

        [Test]
        public void PasswordEyeButton_ShouldMadePasswordVisible()
        {
            FillDataForLogin();

            driver.FindElement(By.CssSelector("[class$='show_hide_password']")).Click();

            wait.Until(d => driver.FindElements(By.CssSelector("[class$='show_hide_password']")).Count == 0);
            var iconShow = driver.FindElement(By.CssSelector(".icon-show"));

            Assert.IsTrue(iconShow.Displayed && passwordLineEdit.GetAttribute("type") == "text");
        }

        [Test]
        public void ValidEmailAndPassword_ShouldEnterInAccount()
        {
            FillDataForLogin();

            nextButton.Click();

            wait.Until(d => driver.FindElement(By.CssSelector("[class*='ztb-p']")));
            var userEmail = driver.FindElement(By.Id("ztb-user-id")).GetAttribute("ztooltip");

            Assert.AreEqual(myEmail, userEmail);
        }*/

    }
}
