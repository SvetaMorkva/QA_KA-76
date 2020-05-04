using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace _3ona51_E2ETestProject
{
    class SignInNotification
    {
        private IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "body.fancybox-active.compensate-for-scrollbar:nth-child(2) div.fancybox-container.fancybox-is-open.fancybox-can-swipe:nth-child(25) div.fancybox-inner div.fancybox-stage div.fancybox-slide.fancybox-slide--html.fancybox-slide--current.fancybox-slide--complete div.homeModals.modals.p-2.fancybox-content div.customCloseFixed > button.fancybox-button.fancybox-close-small.customClose.xButton.green")]
        
        private IWebElement CloseNotificationButton { get; set; }

        public SignInNotification(IWebDriver driver)
        {
            try
            {
                _driver = driver;
                PageFactory.InitElements(driver, this);
            }
            catch { }
        }

        public SignInNotification CloseNotification()
        {
            try
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(CloseNotificationButton));
                CloseNotificationButton.Click();
            }
            catch { }
            return this;
        }
    }
}
