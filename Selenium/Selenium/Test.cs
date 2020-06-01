using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace Selenium
{
    [TestFixture]
    public class Test
    {
        private IWebDriver driver;
        private string url = "https://www.epam.com/";

        public static void waitUntilExists(IWebDriver driver, string selector)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(selector)));
        }

        public static IWebElement smartFind(IWebDriver driver, string selector)
        {
            waitUntilExists(driver, selector);
            return driver.FindElement(By.CssSelector(selector));
        }

        public static IWebElement smartFindCollection(IWebDriver driver, string selector, int position)
        {
            waitUntilExists(driver, selector);
            return driver.FindElements(By.CssSelector(selector)).ElementAt(position);
        }

        [SetUp]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(url);

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == url);

            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        [TearDown]
        public void TestFinalize()
        {
            driver.Quit();
        }


        [Test]
        public void GoToMainPage()
        {
            IWebElement randomLink = smartFind(driver, ".top-navigation__item:nth-child(3) .top-navigation__item-link");
            randomLink.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == "https://www.epam.com/our-work");
            IWebElement logo = smartFind(driver, ".header__logo-container");
            logo.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".title-slider__slide-row")));

            string res = driver.Url;
            Assert.AreEqual(res, url);
        }

        [Test]
        public void ContactUs()
        {
            IWebElement randomLink = smartFind(driver, ".cta-button__text");
            randomLink.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == "https://www.epam.com/about/who-we-are/contact");
            IWebElement phoneNumber = smartFind(driver, ".color-light-blue b a");
            IWebElement form = smartFind(driver, "#_content_epam_en_about_who-we-are_contact_jcr_content_content-container_section_section-par_form_constructor .layout-box__wrapper");
            
            Assert.AreEqual(phoneNumber.GetAttribute("innerHTML"), "+1-267-759-8989");
        }

        [Test]
        public void ChangeLanguage()
        {
            IWebElement languageButton = smartFind(driver, ".location-selector__button");
            languageButton.Click();

            IWebElement russianLanguage = smartFind(driver, ".location-selector__item:nth-child(9) .location-selector__link");
            russianLanguage.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == "https://www.epam-group.ru/");
            IWebElement russianWord = smartFind(driver, ".top-navigation__item:nth-child(1) .top-navigation__item-link");
            
            Assert.AreEqual(russianWord.GetAttribute("innerHTML"), "Услуги");
        }

        [Test]
        public void ToDifferentOffices()
        {
            IWebElement cookieAcceptance = smartFind(driver, ".cookie-disclaimer__button .button__content");
            cookieAcceptance.Click();

            IWebElement europeOffices = smartFind(driver, ".tabs__title:nth-child(2) .js-tabs-link");
            europeOffices.Click();
            
            IWebElement austria = smartFindCollection(driver, ".tabs__item.js-tabs-item.active .locations-viewer__country-title", 14);

            Assert.AreEqual(austria.GetAttribute("innerHTML"), "Austria");
        }

        [Test]
        public void FilterContentType()
        {
            IWebElement cookieAcceptance = smartFind(driver, ".cookie-disclaimer__button .button__content");
            cookieAcceptance.Click();

            IWebElement insightsLink = smartFind(driver, ".top-navigation__item:nth-child(4) .top-navigation__item-link");
            insightsLink.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == "https://www.epam.com/insights");

            Thread.Sleep(2000);
            IWebElement industriesField = smartFindCollection(driver, ".multi-select-filter.validation-focus-target", 0);
            industriesField.Click();

            Thread.Sleep(2000);
            IWebElement industrie = smartFindCollection(driver, ".multi-select-filter.validation-focus-target .checkbox-custom-label", 0);
            industrie.Click();

            Thread.Sleep(2000);
            IWebElement blogFinance = smartFindCollection(driver, ".detail-pages-list__tag", 1);

            Assert.AreEqual(blogFinance.GetAttribute("innerHTML"), "Financial Services");
        }
		
		[Test]
        public void SocialNetworks()
        {
            IWebElement cookieAcceptance = smartFind(driver, ".cookie-disclaimer__button .button__content");
            cookieAcceptance.Click();

            IWebElement instagram = smartFind(driver, ".footer__social-item:nth-child(4) .footer__social-link");
            Assert.AreEqual(instagram.GetAttribute("href"), "https://www.instagram.com/epamsystems/");
        }

        [Test]
        public void SearchInfo()
        {
            IWebElement cookieAcceptance = smartFind(driver, ".cookie-disclaimer__button .button__content");
            cookieAcceptance.Click();

            IWebElement search = smartFind(driver, ".header-search__button.header__icon");
            search.Click();

            Thread.Sleep(2000);
            IWebElement searchItem = smartFindCollection(driver, ".frequent-searches__item", 0);
            searchItem.Click();

            IWebElement submit = smartFind(driver, ".header-search__submit");
            submit.Click();

            IWebElement keyWord = smartFind(driver, ".search-results__auto-correct-term");
            Assert.AreEqual(keyWord.GetAttribute("innerHTML"), "blockchain");
        }
		
		[Test]
        public void ApplyJobVacancy()
        {
            IWebElement cookieAcceptance = smartFind(driver, ".cookie-disclaimer__button .button__content");
            cookieAcceptance.Click();

            IWebElement randomLink = smartFind(driver, ".top-navigation__item:nth-child(6) .top-navigation__item-link");
            randomLink.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == "https://www.epam.com/careers");

            Thread.Sleep(3000);
            IWebElement skillList = smartFind(driver, ".multi-select-filter.validation-focus-target.job-search__departments");
            skillList.Click();

            Thread.Sleep(3000);
            IWebElement skill = smartFindCollection(driver, ".multi-select-filter.validation-focus-target.job-search__departments.open .multi-select-dropdown .checkbox-custom-label", 0);
            skill.Click();
            
            IWebElement submit = smartFind(driver, ".recruiting-search__submit");
            submit.Click();
            
            IWebElement vacancy = smartFindCollection(driver, ".search-result__item-name", 0);

            Assert.AreEqual(vacancy.GetAttribute("innerHTML"), "E-learning Specialist");
        }
    }
}
