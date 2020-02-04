class Data {
    constructor(method, url, version, message) {
        this.method = method;
        this.uri = url;
        this.version = version;
        this.message = message;
        this.response = undefined;
        this.fulfilled = false;
    }
}