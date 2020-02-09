let mathEnforcer = require('./mathEnforcer.js');
let assert = require('chai').assert;

describe('test mathEnforcer functionality', () => {
    it('mathEnforcer should be object with 3 properties(addFive,subtractTen,sum)', () => {
        assert.equal(typeof mathEnforcer, 'object');
        assert.equal(Object.keys(mathEnforcer).length, 3);
        assert.property(mathEnforcer, 'addFive');
        assert.property(mathEnforcer, 'subtractTen');
        assert.property(mathEnforcer, 'sum');
    });

    describe('test mathEnforcer.addFive function', () => {
        it('should return undefined if argument is not a number', () => {
            assert.equal(mathEnforcer.addFive('abc'), undefined);
            assert.equal(mathEnforcer.addFive({}), undefined);
        });

        it('should return correct result with integer or decimal', () => {
            assert.equal(mathEnforcer.addFive(5), 10);
            assert.equal(mathEnforcer.addFive(0.5), 5.5);
            assert.equal(mathEnforcer.addFive(-5), 0);
            assert.equal(mathEnforcer.addFive(0.5), 5.5);
        });
    });

    describe('test mathEnforcer.subtractTen function', () => {
        it('should return undefined if argument is not a number', () => {
            assert.equal(mathEnforcer.subtractTen('abc'), undefined);
            assert.equal(mathEnforcer.subtractTen({}), undefined);
        });

        it('should return correct result with integer or decimal', () => {
            assert.equal(mathEnforcer.subtractTen(5), -5);
            assert.closeTo(mathEnforcer.subtractTen(10.7), 0.7, 0.01);
            assert.equal(mathEnforcer.subtractTen(21), 11);
            assert.equal(mathEnforcer.subtractTen(-10), -20);
        });
    });

    describe('test mathEnforcer.sum function', () => {
        it('should return undefined if first argument is not a number', () => {
            assert.equal(mathEnforcer.sum('abc', 1), undefined);
            assert.equal(mathEnforcer.sum({}, 1), undefined);
        });

        it('should return undefined if second argument is not a number', () => {
            assert.equal(mathEnforcer.sum(1, 'abc'), undefined);
            assert.equal(mathEnforcer.sum(1, {}), undefined);
        });

        it('should return correct result with integers or decimals', () => {
            assert.equal(mathEnforcer.sum(5, 5), 10);
            assert.equal(mathEnforcer.sum(-5, 5), 0);
            assert.equal(mathEnforcer.sum(2.5, 3.5), 6);
            assert.equal(mathEnforcer.sum(-5, -5), -10);
        });
    });
});