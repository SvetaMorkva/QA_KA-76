const ComponentBase = require('./../../../component-base');

class UsernameField extends ComponentBase{
    constructor(driver, webdriver) {
        const xPath = "//input[@id = 'input-username']";
        super(driver, webdriver, xPath);
    }
}

module.exports = UsernameField;