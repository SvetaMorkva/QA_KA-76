using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using Lab2.PageObjects;

namespace QA_Lab2
{
    public class Base
    {
        public ChromeDriver Driver;

        [SetUp]
        public void Initialize()
        {
            Driver = new ChromeDriver();
            LoginPage _LoginPage = new LoginPage(Driver);

            _LoginPage
                .OpenLoginPage()
                .SendKeysEmailLineEdit()
                .OnNextButtonClick()
                .SendKeysPasswordLineEdit();
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Quit();
        }
    }
}
