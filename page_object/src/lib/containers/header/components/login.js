const ComponentBase = require('./../../../component-base');

class Login extends ComponentBase{
    constructor(driver, webdriver) {
        const xPath = "//a[@href = 'https://www.opencart.com/index.php?route=account/login' and @class = 'btn btn-link navbar-btn']"
        super(driver, webdriver, xPath);
    }
}


module.exports = Login;