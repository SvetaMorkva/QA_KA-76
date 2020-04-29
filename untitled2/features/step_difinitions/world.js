/*const {setWorldConstructor} = require('cucumber');
const chrome = require('selenium-webdriver/chrome');
const {Capabilities} = require('selenium-webdriver');
require('chromedriver');

async function browserChromeCreator() {
    const caps = new Capabilities();
    caps.setPageLoadStrategy("normal");
    try {
        this.driver = await new Builder()
            .withCapabilities(caps)
            .forBrowser('chrome')
            .build()
    } catch (e) {
        console.log('Browser not working ' + e);
    }
}
*/

const { setWorldConstructor } = require('cucumber')
const seleniumWebdriver = require('selenium-webdriver')
const {setDefaultTimeout} = require('cucumber');
setDefaultTimeout(60 * 1000);


function CustomWorld() {
    this.driver = new seleniumWebdriver.Builder()
        .forBrowser('chrome')
        .build()

    // Returns a promise that resolves to the element
    this.waitForElement = function(locator) {
        const condition = seleniumWebdriver.until.elementLocated(locator)
        return this.driver.wait(condition)
    }
}

setWorldConstructor(CustomWorld);