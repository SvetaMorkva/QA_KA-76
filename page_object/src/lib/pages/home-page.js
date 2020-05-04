const PageBase = require('./../page-base');
const Header = require('../containers/header/Header');

class HomePage extends PageBase{
    constructor(driver, webdriver) {
        const URL = 'https://www.opencart.com/index.php?route=common/home';
        super(driver, webdriver, URL);
        this.Header = new Header(driver, webdriver);
    }
}

module.exports = HomePage;