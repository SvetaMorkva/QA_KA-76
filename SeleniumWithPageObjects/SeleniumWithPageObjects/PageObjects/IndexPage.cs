using System.Threading;
using OpenQA.Selenium;

namespace SeleniumWithPageObjects.PageObjects
{
    public class IndexPage
    {
        private IWebDriver _driver;

        public IndexPage(IWebDriver driver)
        {
            _driver = driver;
        }
        
        public IWebElement EmailField => _driver.FindElement(By.XPath("(//input[@placeholder='Почта'])[1]"));
        
        public IWebElement PasswordField => _driver.FindElement(By.XPath("(//input[@placeholder='Пароль'])[1]"));
        
        public IWebElement SubmitButton => _driver.FindElement(By.XPath("(//div[@class='ui_form__fieldset'])[3]/input"));

        public IWebElement CreatePostButton => _driver.FindElement(By.XPath("//a[@class='creation_button__main']/../.."));

        public IWebElement SearchField => _driver.FindElement(By.XPath("//input[@placeholder='Поиск']"));

        public IndexPage EnterLoginForm()
        {
            _driver.FindElement(By.XPath("//div[@air-module='module.auth_possession']")).Click();
            Thread.Sleep(3000);
            _driver.FindElement(By.XPath("//div[@data-auth-target='signin-email']")).Click();
            Thread.Sleep(3000);
            return this;
        }
        
        public IndexPage SetEmail(string email)
        {
            if (email == null) return this;
            EmailField.SendKeys(email);
            return this;
        }
        
        public IndexPage SetPassword(string password)
        {
            if (password == null) return this;
            PasswordField.SendKeys(password);
            return this;
        }

        public IndexPage SubmitLoginForm()
        {
            SubmitButton.Click();
            return this;
        }

        public PostWritingPage CreatePost()
        {
            _driver.Navigate().GoToUrl("https://dtf.ru/writing");
            return new PostWritingPage(_driver);
        }

        public SearchResultPage Search(string text)
        {
            SearchField.SendKeys(text + Keys.Enter);
            Thread.Sleep(30000);
            return new SearchResultPage(_driver);
        }

        public bool IsUserLoggedIn(string userPageUrl)
        {
            try
            {
                _driver.FindElement(By.XPath($"//a[@href='{userPageUrl}']"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}