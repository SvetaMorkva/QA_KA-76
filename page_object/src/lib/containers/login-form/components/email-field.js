const ComponentBase = require('./../../../component-base');

class EmailField extends ComponentBase{
    constructor(driver, webdriver) {
        const xPath = "//input[@id = 'input-email']";
        super(driver, webdriver, xPath);
    }

}

module.exports = EmailField;