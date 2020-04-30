const assert = require('assert').strict;
const { Given, When, Then } = require('cucumber');
const {By} = require('selenium-webdriver');


When('I click button Log out', async function() {
    try {
        await this.driver.findElement(By.xpath("//a[@class = 'btn btn-black navbar-btn' and text() = 'Logout']")).click();
    } catch (e) {
        await this.driver.quit();
    }
});

Then('I see button Login', async function() {
    try {
        const login = await driver.findElement(By.xpath("//a[text() = 'Login' and @class = 'btn btn-link navbar-btn']"));
        assert.equal(await login.getAttribute('href'), 'https://www.opencart.com/index.php?route=account/login');
        } catch (e) {
        await this.driver.quit();
    }
});