const ComponentBase = require('./../../../component-base');

class ContinueButton extends ComponentBase{
    constructor(driver, webdriver) {
        const xPath = "//button[text() = 'Continue']";
        super(driver, webdriver, xPath);
    }

}

module.exports = ContinueButton;