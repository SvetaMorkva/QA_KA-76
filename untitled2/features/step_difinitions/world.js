
const { setWorldConstructor } = require('cucumber')
const seleniumWebdriver = require('selenium-webdriver')
const {setDefaultTimeout} = require('cucumber');
setDefaultTimeout(60 * 1000);


function CustomWorld() {
    try {
        this.driver = new seleniumWebdriver.Builder()
            .forBrowser('firefox')
            .build()

        // Returns a promise that resolves to the element
        this.waitForElement = function(locator) {
            const condition = seleniumWebdriver.until.elementLocated(locator)
            return this.driver.wait(condition)
        }
    } catch (e) {
        console.log("Error create webdriver");
    }

}

setWorldConstructor(CustomWorld);