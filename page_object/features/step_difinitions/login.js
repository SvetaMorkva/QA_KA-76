const assert = require('assert').strict;
const { Given, When, Then } = require('cucumber');





Given('I am not logged and want to log in, I click to button LOGIN', async function() {
    try {
        await this.HomePage.Header.Login.click();
    } catch (e) {
        console.log(e);
    }
});





Given("I entered real data {string} in field name, {string} in field password", async function(login, password)  {
    try {
        await this.LoginPage.LoginForm.emailField.sendKeys(login);
        await this.LoginPage.LoginForm.passwordField.sendKeys(password);
    } catch (e) {
        console.log(e);
    }
});


Then('I redirect to security page', async function() {
    try {
        const currentURL = await this.driver.getCurrentUrl();
        const idx = currentURL.indexOf('member_token=');
        assert.equal(currentURL.slice(0, idx+13), this.SecurityPage.url);
    } catch (e) {
        console.log(e);
    }
});





Given("I entered wrong data {string} in field name, {string} in field password", async function(login, password) {
    try {
        await this.LoginPage.LoginForm.emailField.sendKeys(login);
        await this.LoginPage.LoginForm.passwordField.sendKeys(password);
    } catch (e) {
        console.log(e);
    }
});

When('I press on sign in', async function() {
    try {
        await this.LoginPage.LoginForm.LoginButton.click();
    } catch (e) {
        console.log(e);
    }
});


Then('I get a notification wrong password or name', async function() {
    try {
        const currentURL = await this.driver.getCurrentUrl();
        const idx = currentURL.indexOf('member_token=');
        assert.notEqual(currentURL.slice(0, idx+13), this.LoginPage.url);
    } catch (e) {
        console.log(e);
    }

});


