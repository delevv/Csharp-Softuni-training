let isOddOrEven = require('./evenOrOdd.js');
let assert = require('chai').assert;

describe('test isOddOrEven()', () => {
    it('should return undefined with number', () => {
        assert.equal(isOddOrEven(1234), undefined);
    });

    it('should return undefined with object', () => {
        assert.equal(isOddOrEven({}), undefined);
    });

    it('should return odd with abc', () => {
        assert.equal(isOddOrEven('abc'), 'odd');
    });

    it('should return even with abcd', () => {
        assert.equal(isOddOrEven('abcd'), 'even');
    });

    it('should return even with empty string', () => {
        assert.equal(isOddOrEven(''), 'even');
    });
});