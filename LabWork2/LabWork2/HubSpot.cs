using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
namespace LabWork2
{
    class HubSpot
    {
        public ChromeDriver driver;
        public String userID;

        [Obsolete]
        public void Login(String email, String password)
        {
            driver.Navigate().GoToUrl("https://app.hubspot.com/login");


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));

            var username = driver.FindElementById("username");
            username.Clear();
            username.SendKeys(email);

            var password_field = driver.FindElementById("password");
            password_field.Clear();
            password_field.SendKeys(password);
            driver.FindElementById("loginBtn").Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("account-menu")));

            String[] currentUrlLParametres = driver.Url.Split('/');
            userID = currentUrlLParametres[currentUrlLParametres.Length - 1];
        }
        public bool IsLoggedIn()
        {
            String[] currentUrlLParametres = driver.Url.Split('/');
            if (currentUrlLParametres.Contains(userID))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        [Obsolete]
        public void CreateContact(String firstName, String lastName, String email, String jobTitle = "", String phoneNumber = "")
        {
            driver.Navigate().GoToUrl("https://app.hubspot.com/contacts/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("ReactTable")));

            driver.FindElementByCssSelector("button[data-button-use='primary']").Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("UIFormControl-26")));

            driver.FindElementByCssSelector("input[data-field='email']").SendKeys(email);
            driver.FindElementByCssSelector("input[data-field='firstname']").SendKeys(firstName);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[data-field='jobtitle']")));
            driver.FindElementByCssSelector("input[data-field='jobtitle']").SendKeys(jobTitle);
            driver.FindElementByCssSelector("input[data-field='phone']").SendKeys(phoneNumber);


            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[class='uiButton private-button private-button--primary private-button--default private-loading-button private-button--primary private-button--non-link']")));
            driver.FindElementByCssSelector("button[class='uiButton private-button private-button--primary private-button--default private-loading-button private-button--primary private-button--non-link']").Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='text-center']")));
        }

        [Obsolete]
        public void CreateComany(String domainName, String name, String description = " ")
        {
            driver.Navigate().GoToUrl($"https://app.hubspot.com/contacts/{userID}/companies/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("ReactTable")));

            driver.FindElementByCssSelector("button[data-button-use='primary']").Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("UIFormControl-26")));

            driver.FindElementByCssSelector("input[data-field='domain']").SendKeys(domainName);
            driver.FindElementByCssSelector("input[data-field='name']").SendKeys(name);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("textarea[data-field='description']")));
            driver.FindElementByCssSelector("textarea[data-field='description']").SendKeys(description);

            //wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-selenium-test='base - dialog - confirm - btn']")));
            driver.FindElementByCssSelector("li[class='uiListItem private-list__item p-bottom-1']").Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='text-center']")));
        }

        [Obsolete]
        public void CreateTask(String taskName, String taskDetails = "", String contactID = "851")
        {
            driver.Navigate().GoToUrl($"https://app.hubspot.com/contacts/7486179/contact/{contactID}/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-selenium-test='create-engagement-task-button']")));

            driver.FindElementByCssSelector("button[data-selenium-test='create-engagement-task-button']").Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[data-selenium-test='communicator__task-title-input']")));
            driver.FindElementByCssSelector("input[data-selenium-test='communicator__task-title-input']").SendKeys(taskName);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-selenium-test='task-interaction__save-btn']")));
            driver.FindElementByCssSelector("button[data-selenium-test='task-interaction__save-btn']").Click();
            Thread.Sleep(2000);
        }

        [Obsolete]
        public int DeleteContact(int amount2Delete)
        {
            driver.Navigate().GoToUrl("https://app.hubspot.com/contacts/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("ReactTable")));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("span[class='private-checkbox__indicator']")));
            Thread.Sleep(5000);

            var contactsCheckboxes_before = driver.FindElementsByCssSelector("span[class='private-checkbox__indicator']");

            if (amount2Delete > contactsCheckboxes_before.Count())
            {
                throw new Exception("Trying to delete more contacts than exist");
            }

            for (int i = 1; i < amount2Delete + 1; i++)
            {
                contactsCheckboxes_before[i].Click();
            }


            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button[data-selenium-test='bulk-action-delete']")));
            driver.FindElementByCssSelector("button[data-selenium-test='bulk-action-delete']").Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("textarea[data-selenium-test='delete-dialog-match']")));
            driver.FindElementByCssSelector("textarea[data-selenium-test='delete-dialog-match']").SendKeys(amount2Delete.ToString());

            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-selenium-test='delete-dialog-confirm-button']")));
            driver.FindElementByCssSelector("button[data-selenium-test='delete-dialog-confirm-button']").Click();


            Thread.Sleep(2000);
            var contactsCheckboxes_after = driver.FindElementsByCssSelector("span[class='private-checkbox__indicator']");
            return contactsCheckboxes_before.Count() - contactsCheckboxes_after.Count();
        }

        [Obsolete]
        public int DeleteTask(int contactID, int amount2Delete)
        {
            driver.Navigate().GoToUrl($"https://app.hubspot.com/contacts/{userID}/contact/{contactID}/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("span[data-selenium-test='timeline-editable-title']")));

            var tasksCheckboxes_before = driver.FindElementsByCssSelector("button[data-selenium-test='timeline-header-actions__delete']");

            if (amount2Delete > tasksCheckboxes_before.Count())
            {
                throw new Exception("Trying to delete more contacts than exist");
            }

            for (int i = 1; i < amount2Delete + 1; i++)
            {
                tasksCheckboxes_before[i].Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-selenium-test='delete-dialog-confirm-button']")));
                driver.FindElementByCssSelector("button[data-selenium-test='delete-dialog-confirm-button']").Click();

            }

            Thread.Sleep(2000);
            var contactsCheckboxes_after = driver.FindElementsByCssSelector("button[data-selenium-test='timeline-header-actions__delete']"); ;
            return tasksCheckboxes_before.Count() - contactsCheckboxes_after.Count();
        }

        [Obsolete]
        public void EditContactLastName(int contactID, String newLastName)
        {
            driver.Navigate().GoToUrl($"https://app.hubspot.com/contacts/{userID}/contact/{contactID}/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[data-selenium-test='property-input-lastname']")));

            driver.FindElementByCssSelector("input[data-selenium-test='property-input-lastname']").Click();
            driver.FindElementByCssSelector("input[data-selenium-test='property-input-lastname']").SendKeys(Keys.Control + "a");
            driver.FindElementByCssSelector("input[data-selenium-test='property-input-lastname']").SendKeys(Keys.Backspace);
            driver.FindElementByCssSelector("input[data-selenium-test='property-input-lastname']").SendKeys(newLastName);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-selenium-test='UniversalSaveBar-button-primary']")));
            driver.FindElementByCssSelector("button[data-selenium-test='UniversalSaveBar-button-primary']").Click();
            Thread.Sleep(2000);
        }


        [Obsolete]
        public int LogMeeting(int contactID, String meetingDescription)
        {

            driver.Navigate().GoToUrl($"https://app.hubspot.com/contacts/{userID}/contact/{contactID}/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-selenium-test='timeline-editable-section']")));
            Thread.Sleep(10000);

            var tasksCheckboxes_before = driver.FindElementsByCssSelector("div[data-selenium-test='timeline-editable-section']");

            driver.FindElementByCssSelector("button[data-selenium-test='create-engagement-logged-call-button']").Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-selenium-test='create-engagement-log-meeting']")));
            driver.FindElementByCssSelector("button[data-selenium-test='create-engagement-log-meeting']").Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='notranslate public-DraftEditor-content']")));
            driver.FindElementByCssSelector("div[class='notranslate public-DraftEditor-content']").SendKeys(meetingDescription);


            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-selenium-test='rich-text-editor-controls__save-btn']")));
            driver.FindElementByCssSelector("button[data-selenium-test='rich-text-editor-controls__save-btn']").Click();
            Thread.Sleep(2000);

            var tasksCheckboxes_after = driver.FindElementsByCssSelector("div[data-selenium-test='timeline-editable-section']");
            return tasksCheckboxes_after.Count() - tasksCheckboxes_before.Count();
        }

        [Obsolete]
        public int LogCall(int contactID, String callDescription)
        {

            driver.Navigate().GoToUrl($"https://app.hubspot.com/contacts/{userID}/contact/{contactID}/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-selenium-test='timeline-editable-section']")));
            Thread.Sleep(10000);

            var tasksCheckboxes_before = driver.FindElementsByCssSelector("div[data-selenium-test='timeline-editable-section']");

            driver.FindElementByCssSelector("button[data-selenium-test='create-engagement-logged-call-button']").Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-selenium-test='create-engagement-log-email']")));
            driver.FindElementByCssSelector("button[data-selenium-test='create-engagement-log-email']").Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='notranslate public-DraftEditor-content']")));
            driver.FindElementByCssSelector("div[class='notranslate public-DraftEditor-content']").SendKeys(callDescription);


            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-selenium-test='rich-text-editor-controls__save-btn']")));
            driver.FindElementByCssSelector("button[data-selenium-test='rich-text-editor-controls__save-btn']").Click();
            Thread.Sleep(2000);

            var tasksCheckboxes_after = driver.FindElementsByCssSelector("div[data-selenium-test='timeline-editable-section']");
            return tasksCheckboxes_after.Count() - tasksCheckboxes_before.Count();
        }

        [Obsolete]
        public int LogEmail(int contactID, String emailDescription)
        {

            driver.Navigate().GoToUrl($"https://app.hubspot.com/contacts/{userID}/contact/{contactID}/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-selenium-test='timeline-editable-section']")));
            Thread.Sleep(10000);
            var tasksCheckboxes_before = driver.FindElementsByCssSelector("div[data-selenium-test='timeline-editable-section']");

            driver.FindElementByCssSelector("button[data-selenium-test='create-engagement-logged-call-button']").Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-selenium-test='create-engagement-log-call']")));
            driver.FindElementByCssSelector("button[data-selenium-test='create-engagement-log-call']").Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='notranslate public-DraftEditor-content']")));
            driver.FindElementByCssSelector("div[class='notranslate public-DraftEditor-content']").SendKeys(emailDescription);


            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-selenium-test='rich-text-editor-controls__save-btn']")));
            driver.FindElementByCssSelector("button[data-selenium-test='rich-text-editor-controls__save-btn']").Click();
            Thread.Sleep(2000);

            var tasksCheckboxes_after = driver.FindElementsByCssSelector("div[data-selenium-test='timeline-editable-section']");
            return tasksCheckboxes_after.Count() - tasksCheckboxes_before.Count();
        }

        [Obsolete]
        public string SearchInGoogle(int contactID)
        {
            driver.Navigate().GoToUrl($"https://app.hubspot.com/contacts/{userID}/contact/{contactID}/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-selenium-test='create-engagement-logged-call-button']")));

            driver.FindElementByCssSelector("button[data-selenium-test='profile-settings-actions-btn']").Click();
            String googleRedirectUrl = driver.FindElementByCssSelector("a[data-selenium-test='profile-settings-profileSettings.searchGoogleLink']").GetAttribute("href");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[data-selenium-test='profile-settings-profileSettings.searchGoogleLink']")));
            driver.FindElementByCssSelector("a[data-selenium-test='profile-settings-profileSettings.searchGoogleLink']").Click();

            driver.SwitchTo().Window(driver.WindowHandles[1]);
            return googleRedirectUrl;
        }

        [Obsolete]
        public void SignOut()
        {
            driver.Navigate().GoToUrl("https://app.hubspot.com/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("account-menu")));

            driver.FindElementById("account-menu").Click();
            driver.FindElementById("signout").Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("username")));

        }
    }


}

