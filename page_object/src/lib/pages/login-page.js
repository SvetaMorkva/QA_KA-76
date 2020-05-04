const PageBase = require('./../page-base');
const Header = require('../containers/header/Header');
const LoginForm = require('./../containers/login-form/login-form');

class LoginPage extends PageBase{
    constructor(driver, webdriver) {
        const URL = 'https://www.opencart.com/index.php?route=account/login';
        super(driver, webdriver, URL);

        this.Header = new Header(driver, webdriver);
        this.LoginForm = new LoginForm(driver, webdriver);
    }
}

module.exports = LoginPage;