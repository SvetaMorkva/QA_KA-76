using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Lab_2
{
    public class ProfilePage
    {
        private IWebDriver _driver;

        public ProfilePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.TagName, Using = "h1")]
        private IWebElement UserName;

        [FindsBy(How = How.CssSelector, Using = ".b-content-menu li:nth-of-type(2) a")]
        private IWebElement ProfileSettings;

        [FindsBy(How = How.Id, Using = "txtcity")]
        private IWebElement TextBoxCity;

        [FindsBy(How = How.Id, Using = "txtworkplace")]
        private IWebElement TextBoxWorkplace;

        [FindsBy(How = How.Id, Using = "btnSubmit")]
        private IWebElement SubmitButton;

        [FindsBy(How = How.ClassName, Using = "city")]
        private IWebElement CityField;

        [FindsBy(How = How.CssSelector, Using = ".descr span")]
        private IWebElement WorkplaceField;

        [FindsBy(How = How.CssSelector, Using = ".b-content-menu li:nth-of-type(2) a")]
        private IWebElement Subscriptions;

        [FindsBy(How = How.Id, Using = "id_newsletter")]
        private IWebElement CheckBoxNewsletter;

        [FindsBy(How = How.Id, Using = "id_receive_comment_digest")]
        private IWebElement CheckBoxDigest;

        [FindsBy(How = How.Id, Using = "id_allow_pm")]
        private IWebElement CheckBoxAllowPM;

        public string GetUserName() => UserName.Text;

        public ProfilePage GoToProfileSettings()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(ProfileSettings));
            ProfileSettings.Click();
            return this;
        }

        public ProfilePage FillCityTextBox(string CityName)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(TextBoxCity));
            TextBoxCity.Clear();
            Thread.Sleep(500);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(TextBoxCity));
            TextBoxCity.SendKeys(CityName);
            return this;
        }

        public ProfilePage FillWorkplaceTextBox(string WorkplaceName)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(TextBoxWorkplace));
            TextBoxWorkplace.Clear();
            Thread.Sleep(500);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(TextBoxWorkplace));
            TextBoxWorkplace.SendKeys(WorkplaceName);
            return this;
        }

        public ProfilePage SubmitChanges()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(SubmitButton));
            SubmitButton.Click();
            return this;
        }

        public string GetCityName()
        {
            string[] city_information = CityField.Text.Trim().Split(',');
            city_information = city_information[0].Split('\n');
            return city_information[1];
        }

        public string GetWorkplaceName() => WorkplaceField.Text;

        public ProfilePage GoToSubscriptions()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(Subscriptions));
            Subscriptions.Click();
            return this;
        }

        public bool NewsletterChecked() => CheckBoxNewsletter.Selected;

        public bool DigestChecked() => CheckBoxDigest.Selected;

        public bool AllowPMChecked() => CheckBoxAllowPM.Selected;

        public ProfilePage CheckNewsletterIfNecessary()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(CheckBoxNewsletter));
            if (NewsletterChecked())
                CheckBoxNewsletter.Click();
            return this;
        }

        public ProfilePage CheckDigestIfNecessary()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(CheckBoxDigest));
            if (DigestChecked())
                CheckBoxDigest.Click();
            return this;
        }

        public ProfilePage CheckAllowPMIfNecessary()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(CheckBoxAllowPM));
            if (!AllowPMChecked())
                CheckBoxAllowPM.Click();
            return this;
        }
    }
}
