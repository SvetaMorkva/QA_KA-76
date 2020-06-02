using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace PageObjects
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private const string LOGO = ".header__logo-container";
        private const string OUR_WORK_TAB = ".top-navigation__item:nth-child(3) .top-navigation__item-link";
        private const string SLIDER_TITLE = ".title-slider__slide-row";
        private const string CONTACT_US = ".cta-button__text";
        private const string PHONE_NUMBER = ".color-light-blue b a";
        private const string COOKIE_BUTTON = ".cookie-disclaimer__button .button__content";
        private const string LOCATION_BUTTON = ".location-selector__button";
        private const string RUSSIAN_LANGUAGE = ".location-selector__item:nth-child(9) .location-selector__link";
        private const string EUROPE_OFFICES = ".tabs__title:nth-child(2) .js-tabs-link";
        private const string AUSTRIA_OFFICE = "//*[@id='id-d4f6ba92-c566-388d-9892-03fe1a33ce5b']/div[3]/div/div/div[1]/div[1]/div/div[8]/div/button/div[1]";
        private const string INSIGHTS_TAB = ".top-navigation__item:nth-child(4) .top-navigation__item-link";
        private const string INST = ".footer__social-item:nth-child(4) .footer__social-link";
        private const string SEARCH_ICON = ".header-search__button.header__icon";
        private const string FREQUENT_SEARCH_ITEM = "//*[@id='wrapper']/div[2]/div[1]/header/div/ul/li[3]/div/div/form/div/div/ul/li[1]";
        private const string SUBMIT_SEARCH = ".header-search__submit";
        private const string KEY_WORD_SEARCH = ".search-results__auto-correct-term";
        private const string CAREERS_TAB = ".top-navigation__item:nth-child(6) .top-navigation__item-link";

        [FindsBy(How = How.CssSelector, Using = LOGO)]
        private IWebElement logoButton;
        [FindsBy(How = How.CssSelector, Using = OUR_WORK_TAB)]
        private IWebElement workTabButton;
        [FindsBy(How = How.CssSelector, Using = SLIDER_TITLE)]
        private IWebElement homePageCheckerElement;
        [FindsBy(How = How.CssSelector, Using = CONTACT_US)]
        private IWebElement contactUsButton;
        [FindsBy(How = How.CssSelector, Using = PHONE_NUMBER)]
        private IWebElement phoneNumberElement;
        [FindsBy(How = How.CssSelector, Using = COOKIE_BUTTON)]
        private IWebElement cookieButton;
        [FindsBy(How = How.CssSelector, Using = LOCATION_BUTTON)]
        private IWebElement locationElement;
        [FindsBy(How = How.CssSelector, Using = RUSSIAN_LANGUAGE)]
        private IWebElement russianLanguageElement;
        [FindsBy(How = How.CssSelector, Using = EUROPE_OFFICES)]
        private IWebElement europeOffice;
        [FindsBy(How = How.CssSelector, Using = INSIGHTS_TAB)]
        private IWebElement insightsTab;
        [FindsBy(How = How.CssSelector, Using = INST)]
        private IWebElement instagramButton;
        [FindsBy(How = How.CssSelector, Using = SEARCH_ICON)]
        private IWebElement searchIcon;
        [FindsBy(How = How.CssSelector, Using = KEY_WORD_SEARCH)]
        private IWebElement keyWordSearch;
        [FindsBy(How = How.CssSelector, Using = SUBMIT_SEARCH)]
        private IWebElement submitSearch;
        [FindsBy(How = How.XPath, Using = AUSTRIA_OFFICE)]
        private IWebElement austriaOffice;
        [FindsBy(How = How.XPath, Using = FREQUENT_SEARCH_ITEM)]
        private IWebElement frequesntSearchItem;
        [FindsBy(How = How.CssSelector, Using = CAREERS_TAB)]
        private IWebElement careersTab;

        public HomePage openHomePage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(logoButton));
            logoButton.Click();
            return new HomePage(driver);
        }

        public HomePage openWorkPage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(workTabButton));
            workTabButton.Click();
            return new HomePage(driver);
        }

        public string getDriverUrl()
        { 
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(homePageCheckerElement));
            string res = driver.Url;
            return res;
        }

        public HomePage openContactUsPage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(contactUsButton));
            contactUsButton.Click();
            return new HomePage(driver);
        }

        public string findPhoneNumber()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == "https://www.epam.com/about/who-we-are/contact");
            string res = phoneNumberElement.GetAttribute("innerHTML");
            return res;
        }

        public HomePage agreeWithCookies()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(cookieButton));
            cookieButton.Click();
            return new HomePage(driver);
        }

        public HomePage changeLanguage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(locationElement));
            locationElement.Click();
            
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(russianLanguageElement));
            russianLanguageElement.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == "https://www.epam-group.ru/");
            return new HomePage(driver);
        }

        public string findAustria()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(europeOffice));
            europeOffice.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(austriaOffice));
            string res = austriaOffice.GetAttribute("innerHTML");
            return res;
        }

        public HomePage toInsights()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(insightsTab));
            insightsTab.Click();
            return new HomePage(driver);
        }

        public string toInst()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(instagramButton));
            string res = instagramButton.GetAttribute("href");
            return res;
        }

        public string searchInfo()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(searchIcon));
            searchIcon.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(frequesntSearchItem));
            frequesntSearchItem.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(submitSearch));
            submitSearch.Click();
            
            string res = keyWordSearch.GetAttribute("innerHTML");
            return res;
        }

        public HomePage applyCandydacy()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(careersTab));
            careersTab.Click();

            return new HomePage(driver);
        }


    }
}
