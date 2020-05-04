const assert = require('assert').strict;
const { Given, When, Then } = require('cucumber');



When('I click button Log out', async function() {
    try {
        await this.SecurityPage.Header.Logout.click();
    } catch (e) {
        console.log(e);
    }
});

Then('I see button Login', async function() {
    try {
        const login = await this.HomePage.Header.Login.getComponent();
        assert.ok(login);
        } catch (e) {
            console.log(e);
        }
});
