
const { setWorldConstructor, setDefaultTimeout } = require('cucumber')
const seleniumWebdriver = require('selenium-webdriver')

setDefaultTimeout(60 * 1000);


function CustomWorld() {
    try {
        this.driver = new seleniumWebdriver.Builder()
            .forBrowser('firefox')
            .build()
        this.webdriver = seleniumWebdriver;

    } catch (e) {
        console.log("Error webdriver or driver");
    }

}

setWorldConstructor(CustomWorld);