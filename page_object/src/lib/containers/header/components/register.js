const ComponentBase = require('./../../../component-base');

class Register extends ComponentBase{
    constructor(driver, webdriver) {
        const xPath = '//path';
        super(driver, webdriver, xPath);
    }
}


module.exports = Register;