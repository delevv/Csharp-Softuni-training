let sum = require('./sumOfNumbers.js');
let assert = require('chai').assert;

describe('Check sum() work', () => {
    it('Should work correct with array of integer numbers', () => {
        assert.equal(sum([1, 2, 3, 4]), 10);
    });

    it('Should return 0 with empty array', () => {
        assert.equal(sum([]), 0);
    });

    it('Should work correct with decimal numbers', () => {
        assert.equal(sum([0.5, 0.5, 1]), 2);
    });
})