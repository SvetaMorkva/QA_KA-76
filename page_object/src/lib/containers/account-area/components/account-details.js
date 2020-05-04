const ComponentBase = require('./../../../component-base');

class AccountDetails extends ComponentBase{
    constructor(driver, webdriver) {
        const xPath = "//a[text()= 'Account details']";
        super(driver, webdriver, xPath);

    }

}
module.exports = AccountDetails;