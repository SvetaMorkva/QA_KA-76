const AccountDetails = require('./components/account-details');

class AccountArea {
    constructor(driver, webdriver) {
        this.AccountsDetails = new AccountDetails(driver, webdriver);
    }
}

module.exports = AccountArea;

