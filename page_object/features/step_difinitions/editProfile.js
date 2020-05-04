const assert = require('assert').strict;
const { Given, When, Then } = require('cucumber');




Given('I enter security PIN {int}', async function(pin) {
    try {
        await this.SecurityPage.SecurityForm.PINField.sendKeys(pin);
        await this.SecurityPage.SecurityForm.ContinueButton.click();
    } catch (e) {
        console.log(e);
    }
});



Given('I pass to editProfile page', async function() {
    try {
        await this.AccountPage.AccountArea.AccountsDetails.click();
    } catch (e) {
        console.log(e);
    }
})

Then("I show my username {string}", async function(text) {
    try {
        const username = await this.AccountEditPage.AccountEditForm.UsernameField.getComponent();
        assert.equal(await username.getAttribute('value'), text);
    } catch (e) {
        console.log(e);
    }

});

Given("I writting {string}", async function(text) {
    try {
        await this.AccountEditPage.AccountEditForm.UsernameField.clear();
        await this.AccountEditPage.AccountEditForm.UsernameField.sendKeys(text);
    } catch (e) {
        console.log(e);
    }
});

When('I press button submit', async function() {
    try {
        await this.AccountEditPage.AccountEditForm.SubmitButton.click();
    } catch (e) {
        console.log(e);
    }
});

Then('I show message successful', async function () {
    try {
        const message = await this.AccountPage.SuccessMessage.Message.getComponent();
        assert.ok(message);
    } catch (e) {
        console.log(e);
    }
});



Then('I show warning message', async function() {
    try {
        const warn = await this.AccountEditPage.AccountEditForm.WarnMessage.getComponent();
        assert.ok(warn);
    } catch (e) {
        console.log(e);
    }
});