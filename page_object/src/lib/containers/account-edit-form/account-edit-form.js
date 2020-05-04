const UsernameField = require('./components/usernameField');
const SubmitButton = require('./components/submitButton');
const WarnMessage = require('./components/warn-message');

class AccountEditForm {
    constructor(driver, webdriver) {
        this.UsernameField = new UsernameField(driver, webdriver);
        this.SubmitButton = new SubmitButton(driver, webdriver);
        this.WarnMessage = new WarnMessage(driver, webdriver);
    }
}

module.exports = AccountEditForm;