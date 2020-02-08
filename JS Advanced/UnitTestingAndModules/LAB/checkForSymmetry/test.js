let isSymmetric = require('./checkForSymmetry');
let assert = require('chai').assert;

describe('check the functionality of isSymmetric()', () => {
    it('should return false with uncorrect type', () => {
        assert.equal(isSymmetric(1234), false, 'check with number');
        assert.equal(isSymmetric('sadad'), false, 'check with string');
        assert.equal(isSymmetric({}), false, 'check with string');
    });

    it('should return false with non symmetric array', () => {
        assert.equal(isSymmetric([1, 2, 3, 4]), false, 'check with numbers');
        assert.equal(isSymmetric(['a', 'b', 'c']), false, 'check with strings');
    });

    it('should return true with symmetric array', () => {
        assert.equal(isSymmetric([1, 2, 3, 2, 1]), true, 'check with numbers');
        assert.equal(isSymmetric(['a', 'b', 'a']), true, 'check with strings');
        assert.equal(isSymmetric([1, 'a', 'b', 'a', 1]), true, 'check with numbers and strings');
        assert.equal(isSymmetric([{}, 1, 'a', 'b', 'a', 1, {}]), true, 'check with numbers,strings and object');
    });

    it('should return true with empty array', () => {
        assert.equal(isSymmetric([]), true);
    });

    it('should return true with single element in array', () => {
        assert.equal(isSymmetric([5]), true);
    });
})