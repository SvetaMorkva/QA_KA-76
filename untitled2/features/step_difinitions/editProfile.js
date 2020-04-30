const assert = require('assert').strict;
const { Given, When, Then } = require('cucumber');
const {By} = require('selenium-webdriver');


Given('I enter security PIN', async function() {
    try {
        await this.driver.findElement(By.id('input-pin')).sendKeys('5434');
        await this.driver.findElement(By.xpath("//button[text() = 'Continue']")).click();
    } catch (e) {
        await this.driver.quit();
    }
});



Given('I pass to editProfile page', async function() {
    try {
        await this.driver.findElement(By.xpath("//a[text()= 'Account details']")).click();
    } catch (e) {
        await this.driver.quit();
    }
})

Then("I show my username 'Art-kart-1122'", async function() {
    try {
        const username = await this.driver.findElement(By.id('input-username'));
        assert.equal(await username.getAttribute('value'), 'Art-kart-1122');
    } finally {
        await this.driver.findElement(By.xpath("//a[@class = 'btn btn-black navbar-btn' and text() = 'Logout']")).click();
        await this.driver.quit();
    }
});

Given("I writting 'Art-kart-1122'", async function() {
    try {
        const username = await this.driver.findElement(By.id('input-username'));
        await username.clear()
        await username.sendKeys("Art-kart-1122");
    } catch (e) {
        await this.driver.quit();
    }
});

When('I press button submit', async function() {
    try {
        await this.driver.findElement(By.xpath("//button[@type = 'submit' and text() = 'Submit']")).click();
    } catch (e) {
        await this.driver.quit();
    }
});

Then('I show message successful', async function () {
    try {
        const message = await this.driver.findElement(By.xpath("//div[@class = 'alert alert-success']"));
        assert.ok(message);
    } finally {
        await this.driver.findElement(By.xpath("//a[@class = 'btn btn-black navbar-btn' and text() = 'Logout']")).click();
        await this.driver.quit();
    }
});

Given("I writting 'Art-kart-1122Art-kart-1122'", async function() {
    try {
        const username = await this.driver.findElement(By.id('input-username'));
        await username.sendKeys("Art-kart-1122");
    } catch (e) {
        await this.driver.quit();
    }
});

Then('I show warning message', async function() {
    try {
        const warn = await this.driver.findElement(By.xpath("//div[@class = 'text-danger']"));
        assert.ok(warn);
    } finally {
        await this.driver.findElement(By.xpath("//a[@class = 'btn btn-black navbar-btn' and text() = 'Logout']")).click();
        await this.driver.quit();
    }
});