const ComponentBase = require('./../../../component-base');

class SubmitButton extends ComponentBase{
    constructor(driver, webdriver) {
        const xPath = "//button[@type = 'submit' and text() = 'Submit']";
        super(driver, webdriver, xPath);
    }
}

module.exports = SubmitButton;