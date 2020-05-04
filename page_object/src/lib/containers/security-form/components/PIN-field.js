const ComponentBase = require('./../../../component-base');

class PINField extends ComponentBase{
    constructor(driver, webdriver) {
        const xPath = "//input[@id= 'input-pin']";
        super(driver, webdriver, xPath);
    }

}

module.exports = PINField;