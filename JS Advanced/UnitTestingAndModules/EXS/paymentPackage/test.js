let PaymentPackage = require('./paymentPackage');
let assert = require('chai').assert;

describe('test PaymentPackage class functionality', () => {
    it('constructor should initialize correct with default values', () => {
        let pack = new PaymentPackage('pack', 123);

        assert.equal(pack.name, 'pack');
        assert.equal(pack.value, 123);
        assert.equal(pack.VAT, 20);
        assert.equal(pack.active, true);
    });

    it('name should throw Error with invalid value', () => {
        assert.throws(() => new PaymentPackage(4444, 123), Error, 'Name must be a non-empty string');
        assert.throws(() => new PaymentPackage({}, 123), Error, 'Name must be a non-empty string');
        assert.throws(() => new PaymentPackage('', 123), Error, 'Name must be a non-empty string');
        assert.throws(() => new PaymentPackage(null, 123), Error, 'Name must be a non-empty string');
        assert.throws(() => new PaymentPackage(123), Error, 'Name must be a non-empty string');
    });

    it('value should throw Error with invalid value', () => {
        assert.throws(() => new PaymentPackage('name', -1), Error, 'Value must be a non-negative number');
        assert.throws(() => new PaymentPackage('name', 'asfaf'), Error, 'Value must be a non-negative number');
        assert.throws(() => new PaymentPackage('name', {}), Error, 'Value must be a non-negative number');
        assert.throws(() => new PaymentPackage('name', null), Error, 'Value must be a non-negative number');
        assert.throws(() => new PaymentPackage('name'), Error, 'Value must be a non-negative number');
    });

    it('VAT should throw Error with invalid value', () => {
        let pack = new PaymentPackage('name', 123);
        assert.throws(() => pack.VAT = 'asfaf', Error, 'VAT must be a non-negative number');
        assert.throws(() => pack.VAT = [], Error, 'VAT must be a non-negative number');
        assert.throws(() => pack.VAT = -1, Error, 'VAT must be a non-negative number');
        assert.throws(() => pack.VAT = null, Error, 'VAT must be a non-negative number');
    });

    it('active should throw Error with invalid value', () => {
        let pack = new PaymentPackage('name', 123);
        assert.throws(() => pack.active = 'asfaf', Error, 'Active status must be a boolean');
        assert.throws(() => pack.active = [], Error, 'Active status must be a boolean');
        assert.throws(() => pack.active = null, Error, 'Active status must be a boolean');
    });

    it('toString() should return correct string with active=true with default VAT', () => {
        let pack = new PaymentPackage('name', 1234);
        let expectedResult = `Package: name` + '' + '\n' +
            `- Value (excl. VAT): 1234` + '\n' +
            `- Value (VAT 20%): ${1234 * (1 + 20 / 100)}`;
        assert.equal(pack.toString(), expectedResult);
    });

    it('toString() should return correct string with active=false with default VAT', () => {
        let pack = new PaymentPackage('name1234', 6000);
        pack.active = false;
        let expectedResult = `Package: name1234` + ' (inactive)' + '\n' +
            `- Value (excl. VAT): 6000` + '\n' +
            `- Value (VAT 20%): ${6000 * (1 + 20 / 100)}`;
        assert.equal(pack.toString(), expectedResult);
    });

    it('toString() should return correct string with active=false with another VAT', () => {
        let pack = new PaymentPackage('easyPay', 3333);
        pack.VAT = 12;
        let expectedResult = `Package: easyPay` + '' + '\n' +
            `- Value (excl. VAT): 3333` + '\n' +
            `- Value (VAT 12%): ${3333 * (1 + 12 / 100)}`;
        assert.equal(pack.toString(), expectedResult);
    });

    it('test with VAT=0', () => {
        let pack = new PaymentPackage('easyPay', 3333);
        pack.VAT = 0;

        let expectedResult = `Package: easyPay` + '' + '\n' +
            `- Value (excl. VAT): 3333` + '\n' +
            `- Value (VAT 0%): ${3333 * (1 + 0 / 100)}`;

        assert.equal(pack.toString(), expectedResult);
    });

    it('test with value=0 and VAT=0', () => {
        let pack = new PaymentPackage('easyPay', 0);
        pack.VAT = 0;

        let expectedResult = `Package: easyPay` + '' + '\n' +
            `- Value (excl. VAT): 0` + '\n' +
            `- Value (VAT 0%): ${0 * (1 + 0 / 100)}`;

        assert.equal(pack.toString(), expectedResult);
    });

    it('test with value=0', () => {
        let pack = new PaymentPackage('easyPay', 0);

        let expectedResult = `Package: easyPay` + '' + '\n' +
            `- Value (excl. VAT): 0` + '\n' +
            `- Value (VAT 20%): ${0 * (1 + 20 / 100)}`;

        assert.equal(pack.toString(), expectedResult);
    });

    it('should work correct with decimal numbers', () => {
        let pack = new PaymentPackage('name', 1000.22);
        pack.VAT = 12.5;

        let expectedResult = `Package: name` + '' + '\n' +
            `- Value (excl. VAT): 1000.22` + '\n' +
            `- Value (VAT 12.5%): ${1000.22 * (1 + 12.5 / 100)}`;

        assert.equal(pack.toString(), expectedResult);
    });
});