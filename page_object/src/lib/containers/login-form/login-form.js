const EmailField = require('./components/email-field');
const PasswordField = require('./components/password-field');
const LoginButton = require('./components/login-button');

class LoginForm {
    constructor(driver, webdriver) {
        this.emailField = new EmailField(driver, webdriver);
        this.passwordField = new PasswordField(driver, webdriver);
        this.LoginButton = new LoginButton(driver, webdriver);
    }
}

module.exports = LoginForm;