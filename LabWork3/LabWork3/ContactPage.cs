using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LabWork3.Pages
{
    public class ContactPage
    {
        private IWebDriver _driver;

        public const string LOGIN_BUTTON_ID = "loginBtn";
        public const string COMPANIES_MENU_ID = "nav-secondary-companies";
        public const string COMPANY_TITLE_CSS = "div[class='text-center']";
        public const string CONTACT_TITLE_CSS = "div[class='text-center']";
        public const string ALL_TASKS_TITLES_CSS = "span[data-selenium-test='timeline-editable-title']";
        public const string CREATE_TASK_CSS = "button[data-selenium-test='task-interaction__save-btn']";
        public const string TASK_TITLE_FIELD_CSS = "input[data-selenium-test='communicator__task-title-input']";
        public const string CREATE_TASK_BUTTON_CSS = "button[data-selenium-test='create-engagement-task-button']";
        public const string DELETE_TASK_BUTTONS_CSS = "button[data-selenium-test='timeline-header-actions__delete']";
        public const string PROFILE_SETTINGS_BUTTON_CSS = "button[data-selenium-test='profile-settings-actions-btn']";
        public const string SEARCH_IN_GOOGLE_BUTTON_CSS = "a[data-selenium-test='profile-settings-profileSettings.searchGoogleLink']";
        public const string CONFIRM_TASK_DELETION_CSS = "button[class='uiButton private-button private-button--destructive private-button--default private-button--non-link']";
        public const string ALL_EVENTS_TITLES_CSS = "div[data-selenium-test='timeline-editable-section']";

        public const string CREATE_EVENT_BUTTON_CSS = "button[data-selenium-test='create-engagement-logged-call-button']";
        public const string ADD_MEETING_EVENT_BUTTON_CSS = "button[data-selenium-test='create-engagement-log-meeting']";
        public const string EVENT_TITLE_FIELD_CSS = "div[class='notranslate public-DraftEditor-content']";
        public const string SAVE_EVENT_BUTTON_CSS = "button[data-selenium-test='rich-text-editor-controls__save-btn']";
        public const string ADD_EMAIL_EVENT_BUTTON_CSS = "button[data-selenium-test='create-engagement-log-email']";
        public const string ADD_CALL_EVENT_BUTTON_CSS = "button[data-selenium-test='create-engagement-log-call']";



        [FindsBy(How = How.Id, Using = COMPANIES_MENU_ID)]
        public IWebElement openCompaniesListButton;

        [FindsBy(How = How.Id, Using = LOGIN_BUTTON_ID)]
        public IWebElement signOut;

        [FindsBy(How = How.CssSelector, Using = CREATE_TASK_BUTTON_CSS)]
        public IWebElement createTaskButton;

        [FindsBy(How = How.CssSelector, Using = TASK_TITLE_FIELD_CSS)]
        public IWebElement taskTitleField;

        [FindsBy(How = How.CssSelector, Using = CREATE_TASK_CSS)]
        public IWebElement createTask;

        [FindsBy(How = How.CssSelector, Using = PROFILE_SETTINGS_BUTTON_CSS)]
        public IWebElement profileSettingsButton;

        [FindsBy(How = How.CssSelector, Using = CONFIRM_TASK_DELETION_CSS)]
        public IWebElement confirmTasksDeletionButton;

        [FindsBy(How = How.CssSelector, Using = SEARCH_IN_GOOGLE_BUTTON_CSS)]
        public IWebElement searchInGoogleButton;


        [FindsBy(How = How.CssSelector, Using = CREATE_EVENT_BUTTON_CSS)]
        public IWebElement createEventButton;

        [FindsBy(How = How.CssSelector, Using = ADD_MEETING_EVENT_BUTTON_CSS)]
        public IWebElement AddMeetingButton;

        [FindsBy(How = How.CssSelector, Using = EVENT_TITLE_FIELD_CSS)]
        public IWebElement eventTitleField;

        [FindsBy(How = How.CssSelector, Using = SAVE_EVENT_BUTTON_CSS)]
        public IWebElement saveEventButton;

        [FindsBy(How = How.CssSelector, Using = ADD_EMAIL_EVENT_BUTTON_CSS)]
        public IWebElement addEmailButton;

        [FindsBy(How = How.CssSelector, Using = ADD_CALL_EVENT_BUTTON_CSS)]
        public IWebElement addCallButton;



        [FindsBy(How = How.CssSelector, Using = ALL_EVENTS_TITLES_CSS)]
        public IList<IWebElement> allEvents;

        [FindsBy(How = How.CssSelector, Using = ALL_TASKS_TITLES_CSS)]
        public IList<IWebElement> allTasks;

        [FindsBy(How = How.CssSelector, Using = DELETE_TASK_BUTTONS_CSS)]
        public IList<IWebElement> deleteTaskButtons;

        public ContactPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public String GetCurrntUrl() => _driver.Url;


        public ContactPage AddTask(String taskTitle, String taskDescription)
        {
            createTaskButton.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector(TASK_TITLE_FIELD_CSS)));
            taskTitleField.SendKeys(taskTitle);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector(CREATE_TASK_CSS)));
            createTask.Click();
            Thread.Sleep(2000);
            return this;
        }

        public ContactPage DeleteTasks(int amount2Delete)
        {
            Thread.Sleep(10000);

            if (amount2Delete > deleteTaskButtons.Count())
            {
                throw new Exception("Trying to delete more contacts than exist");
            }

            for (int i = 1; i < amount2Delete + 1; i++)
            {
                deleteTaskButtons[i].Click();
                Thread.Sleep(10000);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector(CONFIRM_TASK_DELETION_CSS)));
                confirmTasksDeletionButton.Click();
            }

            Thread.Sleep(2000);
            return this;
        }

        public GoogleSearchResultsPage SearchInGoogle()
        {
            profileSettingsButton.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(SEARCH_IN_GOOGLE_BUTTON_CSS)));
            searchInGoogleButton.Click();
            Thread.Sleep(5000);
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            return new GoogleSearchResultsPage(_driver);
        }

        public string GetGoogleSearchLink()
        {
            profileSettingsButton.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(SEARCH_IN_GOOGLE_BUTTON_CSS)));
            return searchInGoogleButton.GetAttribute("href");
        }

        public ContactPage LogMeeting(String meetingDesription)
        {
            createEventButton.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(ADD_MEETING_EVENT_BUTTON_CSS)));
            AddMeetingButton.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(EVENT_TITLE_FIELD_CSS)));
            eventTitleField.SendKeys(meetingDesription);

            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(SAVE_EVENT_BUTTON_CSS)));
            saveEventButton.Click();
            Thread.Sleep(2000);

            return this;
        }

        public ContactPage LogCall(String meetingDesription)
        {
            createEventButton.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(ADD_CALL_EVENT_BUTTON_CSS)));
            addCallButton.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(EVENT_TITLE_FIELD_CSS)));
            eventTitleField.SendKeys(meetingDesription);

            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(SAVE_EVENT_BUTTON_CSS)));
            saveEventButton.Click();
            Thread.Sleep(2000);

            return this;
        }


        public ContactPage LogEmail(String meetingDesription)
        {
            createEventButton.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(ADD_EMAIL_EVENT_BUTTON_CSS)));
            addEmailButton.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(EVENT_TITLE_FIELD_CSS)));
            eventTitleField.SendKeys(meetingDesription);

            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(SAVE_EVENT_BUTTON_CSS)));
            saveEventButton.Click();
            Thread.Sleep(2000);

            return this;
        }

        public IList<IWebElement> GetAllEvents()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector(ALL_EVENTS_TITLES_CSS)));
            Thread.Sleep(10000);
            return allEvents;
        }
        public IList<IWebElement> GetAllTasks()
        {
            return allTasks;
        }

    }
}
