﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace LabWork3.Pages
{
    public class HomePage
    {
        private IWebDriver _driver;

        public const string ACCOUNT_MENU_ID = "account-menu";
        public const string SING_OUT_ID = "signout";
        public const string CONTACTS_MENU_ID = "nav-secondary-contacts";
        public const string COMPANIES_MENU_ID = "nav-secondary-companies";

        [FindsBy(How = How.Id, Using = ACCOUNT_MENU_ID)]
        public IWebElement accountMenu;

        [FindsBy(How = How.Id, Using = SING_OUT_ID)]
        public IWebElement signOut;

        [FindsBy(How = How.Id, Using = COMPANIES_MENU_ID)]
        public IWebElement openCompaniesListButton;

        [FindsBy(How = How.Id, Using = CONTACTS_MENU_ID)]
        public IWebElement openContactsListButton;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public String GetCurrntUrl() => _driver.Url;


        public CompaniesListPage OpenCompaniesList(int userID = 7486179)
        {
            _driver.Navigate().GoToUrl($"https://app.hubspot.com/contacts/{userID}/companies/");
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementIsVisible(By.ClassName(CompaniesListPage.COMPANIES_TABLE_CLASSNAME)));
            return new CompaniesListPage(_driver);
        }

        public ContactsListPage OpenContactsList()
        {
            _driver.Navigate().GoToUrl("https://app.hubspot.com/contacts/");
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementIsVisible(By.ClassName(CompaniesListPage.COMPANIES_TABLE_CLASSNAME)));
            return new ContactsListPage(_driver);
        }

        public LoginPage SignOut()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementIsVisible(By.Id(ACCOUNT_MENU_ID)));
            accountMenu.Click();
            signOut.Click();

            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementIsVisible(By.Id(LoginPage.USER_NAME_TEXT_FIELD_ID)));
            return new LoginPage(_driver);
        }


    }
}
