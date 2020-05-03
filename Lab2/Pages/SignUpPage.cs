using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lab2.Pages
{
    public class SignUpPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public SignUpPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "cookieClose")]
        public IWebElement cookieCloseBtn;

        [FindsBy(How = How.Id, Using = "namefield")]
        public IWebElement nameField;

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement emailField;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement passField;

        [FindsBy(How = How.Id, Using = "mobile")]
        public IWebElement phoneField;

        [FindsBy(How = How.Id, Using = "signup-termservice")]
        public IWebElement termsCheckbox;

        [FindsBy(How = How.Id, Using = "signupbtn")]
        public IWebElement signUpButton;

        [FindsBy(How = How.Id, Using = "cobdiv")]
        public IWebElement welcomePopup;

        [FindsBy(How = How.Id, Using = "headerUName")]
        public IWebElement accountNameLabel;


        public void GoToUrl()
        {
            _driver.Navigate().GoToUrl("https://www.zoho.com/crm/");
            _wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void SkipCookies()
        {
            if (cookieCloseBtn.Displayed && cookieCloseBtn.Enabled)
            {
                cookieCloseBtn.Click();
            }
        }

        public void FillDataAndSignUp(string name, string mail, string password, string phone)
        {
            nameField.SendKeys(name);
            emailField.SendKeys(mail);
            passField.SendKeys(password);
            phoneField.SendKeys(phone);
            _wait.Until(ExpectedConditions.ElementToBeClickable(termsCheckbox));
            System.Threading.Thread.Sleep(1000);
            termsCheckbox.Click();
            signUpButton.Click();
        }

        public bool CheckSignUpSucces(string expectedName)
        {
            System.Threading.Thread.Sleep(10000); // wait for Zoho to create account
            _wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

            return (welcomePopup.Displayed && welcomePopup.Enabled && accountNameLabel.Text == expectedName);
        }
    }
}
