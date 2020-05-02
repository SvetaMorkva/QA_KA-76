using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lab2
{
    public class CoursesPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public CoursesPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "fa-caret-down")]
        private IWebElement CitiesArrowDown;

        [FindsBy(How = How.CssSelector, Using = ".language-switcher a")]
        private IWebElement LangSwitcher;

        [FindsBy(How = How.ClassName, Using = "courses-list-prelabel")]
        private IWebElement CoursesPrelabel;
        
        [FindsBy(How = How.XPath, Using = "//div[@class='right-part']/a[contains(text(), 'MY GREEN FOREST')]")]
        private IWebElement MyGF;

        [FindsBy(How = How.CssSelector, Using = ".logo a")]
        private IWebElement MyGFLogo;

        [FindsBy(How = How.CssSelector, Using = ".bottom-offset span")]
        private IWebElement MyGFTitle;

        [FindsBy(How = How.ClassName, Using = "details")]
        private IWebElement CoursesArrowDown;

        [FindsBy(How = How.CssSelector, Using = "#city_2166 .phone a")]
        private IWebElement CallCenterNumber;


        public CoursesPage SelectCity(string CityRus)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(CitiesArrowDown));
            CitiesArrowDown.Click();
            Thread.Sleep(3000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//div[@class='cities-switch']//ul//a[contains(text(), '{CityRus}')]")));
            driver.FindElement(By.XPath($"//div[@class='cities-switch']//ul//a[contains(text(), '{CityRus}')]")).Click();
            Thread.Sleep(3000);

            return this;
        }

        public string GetCoursesPrelabel() => CoursesPrelabel.Text;

        public CoursesPage SwitchLang()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(LangSwitcher));
            LangSwitcher.Click();
            Thread.Sleep(1000);
            return this;
        }

        public CoursesPage GoToMyGF()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementToBeClickable(MyGF));
            MyGF.Click();
            Thread.Sleep(3000);

            driver.SwitchTo().Window(driver.WindowHandles.Last());

            wait.Until(ExpectedConditions.ElementToBeClickable(MyGFLogo));
            MyGFLogo.Click();

            return this;
        }

        public string GetMyGFTtileText() => MyGFTitle.Text;

        public CoursesPage ViewAllCourses()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            
            wait.Until(ExpectedConditions.ElementToBeClickable(CoursesArrowDown));
            CoursesArrowDown.Click();
            Thread.Sleep(3000);
            return this;
        }

        public List<string> GetAllCoursesNames()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            List<IWebElement> Courses = new List<IWebElement>();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("title")));
            Courses.AddRange(driver.FindElements(By.ClassName("title")));

            List<string> CoursesNames = new List<string>();
            foreach (IWebElement element in Courses)
                CoursesNames.Add(element.Text.Trim().ToLower());
            return CoursesNames;
        }

        public string GetCallCenterNumber() => CallCenterNumber.Text;
    }
}
