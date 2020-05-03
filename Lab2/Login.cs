using NUnit.Framework;
using OpenQA.Selenium;

using Lab2.PageObjects;

namespace QA_Lab2
{
    [TestFixture]
    public class Login : Base
    {
        [Test]
        public void PasswordEyeButton_ShouldMadePasswordVisible()
        {
            LoginPage _LoginPage = new LoginPage(Driver);

            _LoginPage
                .WaitUntilShowPasswordButtonClickable()
                .OnShowPasswordButtonClick()
                .WaitUntilHidePasswordButtonClickable();

            Assert.IsTrue( 
                _LoginPage.CheckTypeOfDataInPasswordLineEdit("text")
                &&  _LoginPage.HidePasswordIconIsVisible);
        }

        [Test]
        public void ValidEmailAndPassword_ShouldEnterInAccount()
        {
            LoginPage _LoginPage = new LoginPage(Driver);

            _LoginPage
                .OnNextButtonClick();

            UserAppsPage _UserAppsPage = new UserAppsPage(Driver);

            _UserAppsPage
                .OnUserAccountButtonClick()
                .WaitUntilUserAccountEmailClickable();

            Assert.AreEqual( _LoginPage.myEmail, _UserAppsPage.UserAccountEmail );
        }

    }
}
