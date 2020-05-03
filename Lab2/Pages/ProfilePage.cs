using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lab2.Pages
{
    class ProfilePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public ProfilePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "editprofile")]
        public IWebElement editprofileBtn;

        [FindsBy(How = How.Id, Using = "profile_Fname_edit")]
        public IWebElement firstNameInput;

        [FindsBy(How = How.Id, Using = "profile_Lname_edit")]
        public IWebElement secondNameInput;

        [FindsBy(How = How.Id, Using = "profile_nickname")]
        public IWebElement nickNameInput;

        [FindsBy(How = How.Id, Using = "saveprofile")]
        public IWebElement saveBtn;

        [FindsBy(How = How.Id, Using = "profile_name_edit")]
        public IWebElement fullNameLabel;

        [FindsBy(How = How.Id, Using = "profile_nickname")]
        public IWebElement nickNameLabel;

        public string fullNameLabelValue => fullNameLabel.GetAttribute("value");
        public string nickNameLabelValue => nickNameLabel.GetAttribute("value");


        public void EditProfile(string firstName, string secondName, string nickName)
        {
            editprofileBtn.Click();
            firstNameInput.Clear();
            firstNameInput.SendKeys(firstName);

            secondNameInput.Clear();
            secondNameInput.SendKeys(secondName);

            nickNameInput.Clear();
            nickNameInput.SendKeys(nickName);

            saveBtn.Click();
        }

        public void GoToUrl()
        {
            _driver.Navigate().GoToUrl("https://accounts.zoho.com/home#profile/personal");
            _wait.Until(driver => ((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
