const ComponentBase = require('./../../../component-base');

class WarnMessage extends ComponentBase{
    constructor(driver, webdriver) {
        const xPath = "//div[@class = 'text-danger']";
        super(driver, webdriver, xPath);
    }
}

module.exports = WarnMessage;