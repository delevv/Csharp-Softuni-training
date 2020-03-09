const Console = require('./specialConsole.js');
const assert = require('chai').assert;

describe('test Console class functionality', function () {
    describe('test Console.writeLine()', function () {
        it('should return correct result with string', function () {
            assert.equal(Console.writeLine('abc'), 'abc');
        });

        it('should return correct result with object', function () {
            let object = { abc: 123 };
            assert.equal(Console.writeLine(object), JSON.stringify(object));
        });

        it('should throw TypeError when first argument is not a string', function () {
            assert.throws(() => Console.writeLine({}, 'abc'), TypeError, 'No string format given!');
        });

        it('should throw RangeError when parameters are more or less than placeholders', function () {
            assert.throws(() => Console.writeLine('abc {0} {1}', 'a'), RangeError, 'Incorrect amount of parameters given!');
            assert.throws(() => Console.writeLine('abc {0} {1}', 'a', 'b', 'c'), RangeError, 'Incorrect amount of parameters given!');
        });

        it('should throw RangeError when placeholder indexes are wrong', function () {
            assert.throws(() => Console.writeLine('abc {0} {1} {4}', 'a', 'b', 'c'), RangeError, 'Incorrect placeholders given!');
            assert.throws(() => Console.writeLine('abc {7}', 'a'), RangeError, 'Incorrect placeholders given!');
        });

        it('should work correct with valid arguments', function () {
            assert.equal(Console.writeLine('abc {0} {1} {2}', 'a', 'b', 'c'), 'abc a b c');
        });

        it('check placeholder getter', () => {
            assert.deepEqual(Console.placeholder, /{\d+}/g);
        });
    });
});