using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace PageObjects
{
    class CareersPage
    {
        private IWebDriver driver;

        public CareersPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private const string SKILL_LIST = ".multi-select-filter.validation-focus-target.job-search__departments";
        private const string SKILL = "//*[@id='main']/div[1]/div[2]/section/div/div[2]/div/form/div[3]/div/div[2]/div/ul[1]/li[1]/label/span";
        private const string SUBMIT = ".recruiting-search__submit";
        private const string TITLE = "//*[@id='main']/div[1]/div[1]/section/div/div[1]/div/section/ul/li[1]/div[1]/h5/a";

        [FindsBy(How = How.CssSelector, Using = SKILL_LIST)]
        private IWebElement skillList;
        [FindsBy(How = How.XPath, Using = SKILL)]
        private IWebElement skill;
        [FindsBy(How = How.CssSelector, Using = SUBMIT)]
        private IWebElement submit;
        [FindsBy(How = How.XPath, Using = TITLE)]
        private IWebElement title;

        public string getJobTitle()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(skillList));
            skillList.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(skill));
            skill.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(submit));
            submit.Click();
            string res = title.GetAttribute("innerHTML");
            return res;
        }
        
    }
}
