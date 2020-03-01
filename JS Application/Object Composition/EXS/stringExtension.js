(() => {
    String.prototype.ensureStart = function (string) {
        if (!this.startsWith(string)) {
            return string + this;
        }
        return this.toString();
    };

    String.prototype.ensureEnd = function (string) {
        if (!this.endsWith(string)) {
            return this + string;
        }
        return this.toString();
    };

    String.prototype.isEmpty = function () {
        if (this.length === 0) {
            return true;
        }
        return false;
    };

    String.prototype.truncate = function (n) {
        if (n < 4) {
            return ".".repeat(n);
        }

        if (n >= this.length) {
            return this.toString();
        }

        let spaceIndex = this.substr(0, n - 2).lastIndexOf(" ");
        if (spaceIndex === -1) {
            return `${this.substr(0, n - 3)}...`;
        }
        else {
            return `${this.substr(0, spaceIndex)}...`;
        }
    };

    String.format = function (string) {
        for (i = 1; i < arguments.length; i++) {
            string = string.replace(`{${i - 1}}`, arguments[i]);
        }
        return string;
    };
})()