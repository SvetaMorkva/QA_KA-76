using NUnit.Framework;
using OpenQA.Selenium;

using Lab2.PageObjects;

namespace QA_Lab2
{
    [TestFixture]
    class ProfileEdit : Base
    {

        [Test]
        public void EditClick_ShouldMadeLineEditVisible()
        {
            GoToProfile();

            ProfilePage _ProfilesPage = new ProfilePage(Driver);

            _ProfilesPage
                .WaitUntilEditProfileButtonClickable()
                .OnEditProfileButtonClick()
                .WaitUntilEditProfileButtonRemoved();


            Assert.IsTrue(
                _ProfilesPage.ProfileChangeEditlinesIsVisible()
                && _ProfilesPage.ProfileChangeEditlinesCountIsRight);
        }

        private void GoToProfile()
        {
            new LoginPage(Driver).OnNextButtonClick();


            UserAppsPage _UserAppsPage = new UserAppsPage(Driver);

            _UserAppsPage
                .OnUserAccountButtonClick()
                .GoToMyAccountSettings();

            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        }
    }
}
