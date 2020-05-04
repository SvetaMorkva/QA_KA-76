class PageBase {
    constructor(driver, webdriver, url) {
        this.driver = driver;
        this.webdriver = webdriver;
        this.url = url;
    }
    refresh() {

    }
}


module.exports = PageBase;