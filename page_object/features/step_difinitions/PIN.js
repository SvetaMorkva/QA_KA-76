const assert = require('assert').strict;
const { Given, When, Then } = require('cucumber');



Given('I log in to my account', async function() {
   try {
       await this.HomePage.Header.Login.click();
       await this.LoginPage.LoginForm.emailField.sendKeys('artur.borbela1122@gmail.com');
       await this.LoginPage.LoginForm.passwordField.sendKeys('borbelaopencart1122');
       await this.LoginPage.LoginForm.LoginButton.click();
   } catch (e) {
       console.log(e);
   }
});



When('I click button Continue', async function() {
    try {
        await this.SecurityPage.SecurityForm.ContinueButton.click();
    } catch (e) {
        console.log(e);
    }
});

Then('I redirect to Account page', async function() {
    try {
        const currentURL = await this.driver.getCurrentUrl();
        const idx = currentURL.indexOf('member_token=');
        assert.equal(currentURL.slice(0, idx+13), this.AccountPage.url);
    } catch (e) {
        console.log(e);
    }
})

Given("I logged in and must enter PIN {int}", async function(pin) {
    try {
        await this.SecurityPage.SecurityForm.PINField.sendKeys(pin);
    } catch (e) {
        console.log(e);
    }
});

