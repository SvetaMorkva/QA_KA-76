const ComponentBase = require('./../../../component-base');

class Logout extends ComponentBase{
    constructor(driver, webdriver) {
        const xPath = "//a[@class = 'btn btn-black navbar-btn' and text() = 'Logout']";
        super(driver, webdriver, xPath);
    }
}


module.exports = Logout;