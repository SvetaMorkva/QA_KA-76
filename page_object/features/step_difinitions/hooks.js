
const { After, Before} = require('cucumber');


const HomePage = require('../../src/lib/pages/home-page');
const LoginPage = require('../../src/lib/pages/login-page');
const SecurityPage = require('../../src/lib/pages/security-page');
const AccountPage = require('../../src/lib/pages/account-page');
const AccountEditPage = require('../../src/lib/pages/account-edit');


Before({ tags: '@login' }, async function () {
    this.HomePage = new HomePage(this.driver, this.webdriver);
    this.LoginPage = new LoginPage(this.driver, this.webdriver);
    this.SecurityPage = new SecurityPage(this.driver, this.webdriver);

});

Before({ tags: '@security' }, async function () {
    this.HomePage = new HomePage(this.driver, this.webdriver);
    this.LoginPage = new LoginPage(this.driver, this.webdriver);
    this.SecurityPage = new SecurityPage(this.driver, this.webdriver);
    this.AccountPage = new AccountPage(this.driver, this.webdriver);

});

Before({ tags: '@edit-profile' }, async function () {
    this.HomePage = new HomePage(this.driver, this.webdriver);
    this.LoginPage = new LoginPage(this.driver, this.webdriver);
    this.SecurityPage = new SecurityPage(this.driver, this.webdriver);
    this.AccountPage = new AccountPage(this.driver, this.webdriver);
    this.AccountEditPage = new AccountEditPage(this.driver, this.webdriver);

});

Before(async function () {
    await this.driver.get('https://www.opencart.com/index.php?route=common/home');
    await this.driver.manage().window().setRect({ width: 1024, height: 1024 });
})


After(async function () {
    await this.driver.quit();
});