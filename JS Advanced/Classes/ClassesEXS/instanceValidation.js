class CheckingAccount {
    constructor(clientId, email, firstName, lastName) {
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get clientId() {
        return this._clientId;
    }
    set clientId(value) {
        let regex = /^\d{6}$/;
        if (!value.match(regex)) {
            throw new TypeError('Client ID must be a 6-digit number');
        }
        this._clientId = value;
    }

    get email() {
        return this._email;
    }
    set email(value) {
        let regex = /\S+@[a-z]+.[a-z]*/;

        if (!value.match(regex)) {
            throw new TypeError('Invalid e-mail');
        }
        this._email = value;
    }

    get firstName() {
        return this._firstName;
    }
    set firstName(value) {
        this.checkName(value, 'First');
        this._firstName = value;
    }

    get lastName() {
        return this._lastName;
    }
    set lastName(value) {
        this.checkName(value, 'Last');
        this._lastName = value;
    }
    checkName(value, name) {
        let lengthReg = /\S{3,20}/;
        let charReg = /[a-b]+/;

        if (!value.match(lengthReg)) {
            throw new TypeError(`${name} name must be between 3 and 20 characters long`);
        }
        if (!value.match(charReg)) {
            throw new TypeError(`${name} name must contain only Latin characters`);
        }
    }
}