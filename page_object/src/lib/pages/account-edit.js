const PageBase = require('./../page-base');
const AccountEditForm = require('./../containers/account-edit-form/account-edit-form');

class AccountEdit extends PageBase{
    constructor(driver, webdriver) {
        const URL = 'https://www.opencart.com/index.php?route=account/edit&member_token=';
        super(driver, webdriver, URL);

        this.AccountEditForm = new AccountEditForm(driver, webdriver);
    }
}

module.exports = AccountEdit;