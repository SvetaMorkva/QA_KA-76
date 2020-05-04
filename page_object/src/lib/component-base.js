class ComponentBase {
    constructor(driver, webdriver, xPath) {
        this.driver = driver;
        this.webdriver = webdriver;
        this.xPath = xPath;
    }
    async click() {
        try {
            await this.driver.findElement(this.webdriver.By.xpath(this.xPath)).click();
        } catch (e) {
            console.log(e);
        }

    }
    async sendKeys(data) {
        await this.driver.findElement(this.webdriver.By.xpath(this.xPath)).sendKeys(data);
    }
    async getComponent() {
        return this.driver.findElement(this.webdriver.By.xpath(this.xPath));
    }
    async clear() {
        await this.driver.findElement(this.webdriver.By.xpath(this.xPath)).clear();
    }

}

module.exports = ComponentBase;