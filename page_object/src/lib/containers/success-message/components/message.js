const ComponentBase = require('./../../../component-base');

class Message extends ComponentBase{
    constructor(driver, webdriver) {
        const xPath = "//div[@class = 'alert alert-success']";
        super(driver, webdriver, xPath);
    }

}

module.exports = Message;