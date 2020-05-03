using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace Lab2.Pages
{
    class HomePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public HomePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            PageFactory.InitElements(driver, this);
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _wait.Until(driver => ((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        [FindsBy(How = How.XPath, Using = "//body[@class=\"crmBodyWin\"]")]
        public IWebElement body;

        [FindsBy(How = How.Id, Using = "wms-hysearch")]
        public IWebElement smartChatWindow;

        [FindsBy(How = How.ClassName, Using = "wms-hysearch-resheading")]
        public IList<IWebElement> searchHeaders;


        [FindsBy(How = How.XPath, Using = "//div[@id=\"wms_menubar\"]/span[@title=\"Contacts\"]")]
        public IWebElement menuBar;

        [FindsBy(How = How.XPath, Using = "//div[@id=\"wms_menu\"]")]
        public IWebElement contactsMenu;

        [FindsBy(How = How.XPath, Using = "//div[@id=\"wms_menu_userstatus\"]")]
        public IWebElement statusLabel;

        public string statusValue => statusLabel.Text;

        [FindsBy(How = How.Id, Using = "wms_menu_statuseditor")]
        public IWebElement statusEditor;

        public void OpenSmartChat()
        {
            body.SendKeys(Keys.Control + Keys.Space);
            _wait.Until(dr => smartChatWindow.Displayed && smartChatWindow.Enabled);
        }

        public bool IsSmartChatOpened()
        {
            if(searchHeaders.Count != 2)
            {
                return false;
            }
            return searchHeaders[0].Text == "Chats" && searchHeaders[1].Text == "Contacts";
        }

        public void OpenStatusBar()
        {
            _wait.Until(dr => menuBar.Displayed && menuBar.Enabled);
            menuBar.Click();
            System.Threading.Thread.Sleep(2000);
            _wait.Until(dr => contactsMenu.Displayed && contactsMenu.Enabled);
            statusLabel.Click();
            System.Threading.Thread.Sleep(2000);
            _wait.Until(dr => statusEditor.Displayed && statusEditor.Enabled);
        }

        public void ChangeStatus(string statusToSet)
        {
            statusEditor.SendKeys(Keys.Control + "a");
            statusEditor.SendKeys(statusToSet);
            statusEditor.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(1000);
        }
    }
}
