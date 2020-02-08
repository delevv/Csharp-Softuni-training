let createCalculator = require('./createCalculator.js');
let assert = require('chai').assert;

describe('check the functionality or createCalculator()', () => {
    let calculator;
    beforeEach(() => {
        calculator = createCalculator();
    });

    describe('check return of createCalculator()', () => {
        it('return type must be object', () => {
            assert.isObject(calculator);
        });

        it('return type must be object with add,subtract,get properties', () => {
            assert.property(calculator, 'add');
            assert.property(calculator, 'subtract');
            assert.property(calculator, 'get');
        });
    });

    describe('calculator.add and calculator.get should work correct', () => {
        it('add integer', () => {
            calculator.add(5);
            assert.equal(calculator.get(), 5);

            calculator.add(22);
            assert.equal(calculator.get(), 27);
        });

        it('add decimal', () => {
            calculator.add(5.5);
            assert.equal(calculator.get(), 5.5);

            calculator.add(0.5);
            assert.equal(calculator.get(), 6);
        });

        it('add string', () => {
            calculator.add("1");
            assert.equal(calculator.get(), 1);

            calculator.add("0.5");
            assert.equal(calculator.get(), 1.5);

            calculator.add("10");
            assert.equal(calculator.get(), 11.5);
        });
    });

    describe('calculator.subtract and calculator.get should work correct', () => {
        beforeEach(() => {
            calculator.add(20);
        });

        it('subtract integer', () => {
            calculator.subtract(5);
            assert.equal(calculator.get(), 15);

            calculator.subtract(15);
            assert.equal(calculator.get(), 0);
        });

        it('subtract decimal', () => {
            calculator.subtract(5.5);
            assert.equal(calculator.get(), 14.5);

            calculator.subtract(0.5);
            assert.equal(calculator.get(), 14);
        });

        it('subtract string', () => {
            calculator.subtract("1");
            assert.equal(calculator.get(), 19);

            calculator.subtract("0.5");
            assert.equal(calculator.get(), 18.5);

            calculator.subtract("10");
            assert.equal(calculator.get(), 8.5);
        });
    });
});