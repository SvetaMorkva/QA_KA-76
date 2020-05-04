const ComponentBase = require('./../../../component-base');

class PasswordField extends ComponentBase{
    constructor(driver, webdriver) {
        const xPath = "//input[@id = 'input-password']";
        super(driver, webdriver, xPath);
    }
}

module.exports = PasswordField;