const PageBase = require('./../page-base');
const Header = require('../containers/header/Header');
const SecurityForm = require('./../containers/security-form/security-form');

class SecurityPage extends PageBase{
    constructor(driver, webdriver) {
        const URL = 'https://www.opencart.com/index.php?route=account/security&member_token=';
        super(driver, webdriver, URL);

        this.Header = new Header(driver, webdriver);
        this.SecurityForm = new SecurityForm(driver, webdriver);
    }
}

module.exports = SecurityPage;