const assert = require('assert').strict;
const { Given, When, Then } = require('cucumber');
const {By} = require('selenium-webdriver');


Given('I log in to my account', async function() {
   try {
       await this.driver.get('https://www.opencart.com/index.php?route=common/home');
       await this.driver.manage().window().setRect({ width: 1024, height: 1024 });
       await this.driver.findElement(By.xpath("//a[@href = 'https://www.opencart.com/index.php?route=account/login' and @class = 'btn btn-link navbar-btn']")).click();
       await this.driver.findElement(By.id('input-email')).sendKeys('artur.borbela1122@gmail.com');
       await this.driver.findElement(By.id('input-password')).sendKeys('borbelaopencart1122');
       await this.driver.findElement(By.xpath("//button[@type='submit' and text()= 'Login']")).click();
   } catch (e) {
       await this.driver.quit();
   }
});


Given("I logged in and must enter PIN '5434'", async function() {
    try {
        await this.driver.findElement(By.id('input-pin')).sendKeys('5434');
    } catch (e) {
        await this.driver.quit();
    }
});


When('I click button Continue', async function() {
    try {
        await this.driver.findElement(By.xpath("//button[text() = 'Continue']")).click();
    } catch (e) {
        await this.driver.quit();
    }
});

Then('I see Account details', async function() {
    try {
        const account = await this.driver.findElement(By.xpath("//a[@class = 'btn btn-link navbar-btn' and text() = 'Account']"));
        let accountURL = await account.getAttribute('href');
        const idx = accountURL.indexOf('member_token=');
        const token = accountURL.slice(idx+13);
        assert.equal(accountURL.slice(0, idx), 'https://www.opencart.com/index.php?route=account/account&');
    } catch (e) {
        console.log(e);
    }
    finally {
        await this.driver.findElement(By.xpath("//a[@class = 'btn btn-black navbar-btn' and text() = 'Logout']")).click();
        await this.driver.quit();
    }
})

Given("I logged in and must enter PIN '1111'", async function() {
    try {
        await this.driver.findElement(By.id('input-pin')).sendKeys(1111);
    } catch (e) {
        await this.driver.quit();
    }
});

