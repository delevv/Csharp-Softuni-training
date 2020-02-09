const lookupChar = require('./lookupChar.js');
const assert = require('chai').assert;

describe('test lookupChar()', () => {
    it('should return undefined if first argument type!=string', () => {
        assert.equal(lookupChar({}, 0));
        assert.equal(lookupChar(123, 1));
    });

    it('should return undefined if second argument is not integer', () => {
        assert.equal(lookupChar('abc', 1.2), undefined);
        assert.equal(lookupChar('abc', 'abc'), undefined);
    });

    it('should return "Incorrect index" if index is not valid', () => {
        assert.equal(lookupChar('abc', -1), 'Incorrect index');
        assert.equal(lookupChar('abc', 3), 'Incorrect index');
    });

    it('should return correct result', () => {
        assert.equal(lookupChar('abc', 0), 'a');
        assert.equal(lookupChar('abc', 2), 'c');
        assert.equal(lookupChar('123', 1), '2');
        assert.equal(lookupChar('', 0), 'Incorrect index');
    });
});