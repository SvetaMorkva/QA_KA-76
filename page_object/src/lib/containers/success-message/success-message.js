const Message = require('./components/message');


class SuccessMessage {
    constructor(driver, webdriver) {
        this.Message = new Message(driver, webdriver);
    }
}

module.exports = SuccessMessage;