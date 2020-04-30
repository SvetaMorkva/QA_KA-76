const assert = require('assert').strict;
const { Given, When, Then } = require('cucumber');
const {By} = require('selenium-webdriver');




Given('I am not logged and want to log in', async function() {
    try {
        await this.driver.get('https://www.opencart.com/index.php?route=common/home');
        await this.driver.manage().window().setRect({ width: 1024, height: 768 });
    } catch (e) {
        await this.driver.quit();
    }
});

When('I click to button sign in open signIn page', async function () {
    try {
        await this.driver.findElement(By.xpath("//a[@href = 'https://www.opencart.com/index.php?route=account/login' and @class = 'btn btn-link navbar-btn']")).click();
    } catch (e) {
        await this.driver.quit();
    }
});




Given("I entered real data 'artur.borbela1122@gmail.com' in field name, 'borbelaopencart1122' in field password", async function()  {
    try {
        await this.driver.findElement(By.id('input-email')).sendKeys('artur.borbela1122@gmail.com');
        await this.driver.findElement(By.id('input-password')).sendKeys('borbelaopencart1122');
    } catch (e) {
        await this.driver.quit();
    }
});


Then('I redirect to security page', async function() {
    try {
        const currentURL = await this.driver.getCurrentUrl();
        const idx = currentURL.indexOf('member_token=');
        assert.equal(currentURL.slice(0, idx), `https://www.opencart.com/index.php?route=account/security&`);
    } finally {
        await this.driver.findElement(By.xpath("//a[@class = 'btn btn-black navbar-btn' and text() = 'Logout']")).click();
        await this.driver.quit();
    }
});





Given("I entered wrong data 'a.borbela1122@gmail.com' in field name, 'kartonopencart1122' in field password", async function() {
    try {
        await this.driver.findElement(By.id('input-email')).sendKeys('a.borbela1122@gmail.com');
        await this.driver.findElement(By.id('input-password')).sendKeys('kartonopencart1122');
    } catch (e) {
        await this.driver.quit();
    }
});

When('I press on sign in', async function() {
    try {
        await this.driver.findElement(By.xpath("//button[@type='submit' and text()= 'Login']")).click();
    } catch (e) {
        await this.driver.quit();
    }
});


Then('I get a notification wrong password or name', async function() {
    try {
        const currentURL = await this.driver.getCurrentUrl();
        const idx = currentURL.indexOf('member_token=');
        assert.notEqual(currentURL.slice(0, idx), `https://www.opencart.com/index.php?route=account/security&`);
    } finally {
        await this.driver.quit();
    }
});


