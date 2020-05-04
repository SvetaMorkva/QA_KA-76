const ComponentBase = require('./../../../component-base');

class LoginButton extends ComponentBase{
    constructor(driver, webdriver) {
        const xPath = "//button[@type='submit' and text()= 'Login']";
        super(driver, webdriver, xPath);
    }
}

module.exports = LoginButton;