using OpenQA.Selenium;

namespace SeleniumWithPageObjects.PageObjects
{
    public class RubricPage
    {
        public IWebDriver _driver;

        public string _inactiveSubscriptionClass = "subsite_subscribe_button--state-inactive";
        
        public RubricPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsUserSubscribed()
        {
            string buttonClasses = _driver.FindElement(By.XPath("//div[@air-module='module.subsite_subscribe']"))
                .GetAttribute("class");
            if (buttonClasses.Contains(_inactiveSubscriptionClass))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

