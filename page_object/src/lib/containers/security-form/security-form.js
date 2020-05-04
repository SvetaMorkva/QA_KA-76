const PINField = require('./components/PIN-field');
const ContinueButton = require('./components/continue-button');

class SecurityForm {
    constructor(driver, webdriver) {
        this.PINField = new PINField(driver, webdriver);
        this.ContinueButton = new ContinueButton(driver, webdriver);
    }
}

module.exports = SecurityForm;