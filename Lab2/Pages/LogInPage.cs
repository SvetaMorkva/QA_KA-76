using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lab2.Pages
{
    class LogInPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public LogInPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "login_id")]
        public IWebElement loginLineEdit;

        [FindsBy(How = How.Id, Using = "nextbtn")]
        public IWebElement nextButton;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement passwordLineEdit;

        [FindsBy(How = How.ClassName, Using = "skip_btn")]
        public IWebElement skipWarningbtn;

        [FindsBy(How = How.Id, Using = "ztb-user-id")]
        public IWebElement userEmailLabel;

        public string EmailAfterLogin => userEmailLabel.GetAttribute("ztooltip");

        public void GoToUrl()
        {
            _driver.Navigate().GoToUrl("https://accounts.zoho.eu/signin?servicename=ZohoHome&signupurl=https://www.zoho.com/signup.html");
            _wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void LogIn(string email, string password)
        {
            loginLineEdit.SendKeys(email);
            nextButton.Click();
            System.Threading.Thread.Sleep(5000);
            passwordLineEdit.SendKeys(password);
            System.Threading.Thread.Sleep(1000);
            nextButton.Click();

            // to bypass warning on too many logins (thanks, zoho)
            IWebElement skipWarningbtn = null;
            try
            {
                skipWarningbtn = _driver.FindElement(By.ClassName("skip_btn"), 5);
            }
            catch (WebDriverException ex)
            {
                //do nothing
            }

            if (skipWarningbtn != null)
            {
                skipWarningbtn.Click();
                System.Threading.Thread.Sleep(2000);
            }
        }

    }
}
