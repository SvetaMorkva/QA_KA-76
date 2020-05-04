const PageBase = require('./../page-base');
const Header = require('./../containers/header/Header');
const AccountArea = require('./../containers/account-area/account-area');
const SuccessMessage = require('./../containers/success-message/success-message');

class AccountPage extends PageBase{
    constructor(driver, webdriver) {
        const URL = 'https://www.opencart.com/index.php?route=account/account&member_token=';
        super(driver, webdriver, URL);

        this.Header = new Header(driver, webdriver);
        this.AccountArea = new AccountArea(driver, webdriver);
        this.SuccessMessage = new SuccessMessage(driver, webdriver);
    }
}

module.exports = AccountPage;