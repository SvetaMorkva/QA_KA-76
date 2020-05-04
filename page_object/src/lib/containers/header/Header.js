const Login = require('./components/login');
const Logout = require('./components/logout');
const Register = require('./components/register');

class Header {
    constructor(driver, webdriver) {
        this.Login = new Login(driver, webdriver);
        this.Logout = new Logout(driver, webdriver);
        this.Register = new Register(driver, webdriver);
    }

}

module.exports = Header;