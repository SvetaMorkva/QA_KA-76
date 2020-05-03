using NUnit.Framework;
using OpenQA.Selenium.Chrome;

using Lab2.PageObjects;

namespace QA_Lab2
{
    [TestFixture]
    public class SignUp
    {
        private ChromeDriver Driver;
        private SignupPage _SignUpPage;

        [SetUp]
        public void Initialize()
        {
            Driver = new ChromeDriver();
            _SignUpPage = new SignupPage(Driver);

            _SignUpPage
                .OpenSignUpPage()
                .WaitUntilSignUpButtonClickable();
        }
        

        [Test]
        public void SignUp_WithoutFilling_ShouldMadeErrorVisible()
        {
            _SignUpPage
                .OnSignUpButtonClick()
                .WaitUntilErrorMsgCreated();

            
            Assert.IsTrue( _SignUpPage.CheckThatErrorMsgIsVisible() );
        }

        [Test]
        public void SignUp_ChangeCountry_ShouldMadeCountryVisible()
        {
            _SignUpPage
                .OnChangeCountryButtonClick();

            Assert.IsTrue( _SignUpPage.ChangeCountryDropDownIsVisible );
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Quit();
        }
    }
}
