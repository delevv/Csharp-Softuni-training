const StringBuilder = require('./stringBulder.js');
const assert = require('chai').assert;

describe('test StringBuilder class functionality', () => {
    describe('test StringBuilder constructor', () => {
        it('should throw TypeError if argument type!=string', () => {
            assert.throws(() => new StringBuilder(123), TypeError, 'Argument must be string');
            assert.throws(() => new StringBuilder([]), TypeError, 'Argument must be string');
        });

        it('should set _stringArray correct if argument!=undefined', () => {
            let sb = new StringBuilder('abc');
            assert.equal(sb._stringArray[0], 'a');
            assert.equal(sb._stringArray[1], 'b');
            assert.equal(sb._stringArray[2], 'c');
        });

        it('should set _stringArray correct if argument=undefined', () => {
            let sb = new StringBuilder();
            assert.equal(JSON.stringify(sb._stringArray), '[]');
        });
    });

    let sbWithValue;
    let sbEmpty;

    beforeEach(() => {
        sbWithValue = new StringBuilder('start');
        sbEmpty = new StringBuilder();
    });

    describe('test StringBuilder.append', () => {
        it('should throw TypeError if argument type!=string', () => {
            assert.throws(() => sbWithValue.append(123), TypeError, 'Argument must be string');
            assert.throws(() => sbEmpty.append({}), TypeError, 'Argument must be string');
        });

        it('should work correct', () => {
            sbWithValue.append('def');
            assert.equal(sbWithValue.toString(), 'startdef');

            sbEmpty.append('def');
            assert.equal(sbEmpty.toString(), 'def');
        });
    });

    describe('test StringBuilder.prepend', () => {
        it('should throw TypeError if argument type!=string', () => {
            assert.throws(() => sbWithValue.prepend(123), TypeError, 'Argument must be string');
            assert.throws(() => sbEmpty.prepend({}), TypeError, 'Argument must be string');
        });

        it('should work correct', () => {
            sbWithValue.prepend('def');
            assert.equal(sbWithValue.toString(), 'defstart');

            sbEmpty.prepend('def');
            assert.equal(sbEmpty.toString(), 'def');
        });
    });

    describe('test StringBuilder.insertAt', () => {
        it('should throw TypeError if argument type!=string', () => {
            assert.throws(() => sbWithValue.insertAt(123, 0), TypeError, 'Argument must be string');
            assert.throws(() => sbEmpty.insertAt({}, 0), TypeError, 'Argument must be string');
        });

        it('should work correct', () => {
            sbWithValue.insertAt('insert', 2);
            assert.equal(sbWithValue.toString(), 'stinsertart', 'insert at Midle');

            sbWithValue = new StringBuilder('start');
            sbWithValue.insertAt('insert', 0);
            assert.equal(sbWithValue.toString(), 'insertstart', 'insert at begining');

            sbWithValue = new StringBuilder('start');
            sbWithValue.insertAt('insert', 5);
            assert.equal(sbWithValue.toString(), 'startinsert', 'insert at end');

            sbEmpty.insertAt('insert', 0);
            assert.equal(sbEmpty.toString(), 'insert');
        });
    });

    describe('test StringBuilder.remove', () => {
        it('should remove correct from start', () => {
            sbWithValue.remove(0, 1);
            assert.equal(sbWithValue.toString(), 'tart');
        });

        it('should remove correct from mid', () => {
            sbWithValue.remove(2, 1);
            assert.equal(sbWithValue.toString(), 'strt');
        });

        it('should remove all correct', () => {
            sbWithValue.remove(0, 5);
            assert.equal(sbWithValue.toString(), '');
        });

        it('should remove till end with invalid count', () => {
            sbWithValue.remove(0, 10);
            assert.equal(sbWithValue.toString(), '', 'from start');

            sbWithValue = new StringBuilder('start', 'from mid');
            sbWithValue.remove(2, 10);
            assert.equal(sbWithValue.toString(), 'st');
        });

        it('should do nothing with empty string', () => {
            sbEmpty.remove(0, 2);
            assert.equal(sbEmpty.toString(), '');
        })
    });
});