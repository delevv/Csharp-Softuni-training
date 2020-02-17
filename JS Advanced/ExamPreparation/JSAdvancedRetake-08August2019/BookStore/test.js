const BookStore = require('./bookStore.js');
const assert = require('chai').assert;

describe('test BookStore class functionality', () => {
    let bookStore;
    beforeEach(() => bookStore = new BookStore('Burgas'));

    describe('test constructor', () => {
        it('should set name correct', () => {
            assert.equal(bookStore.name, 'Burgas');
        });

        it('should set deafult values correct', () => {
            assert.equal(JSON.stringify(bookStore.books), '[]');
            assert.equal(JSON.stringify(bookStore._workers), '[]');
        });
    });

    describe('test hire(name, position)', () => {
        it('should return correct message with new person', () => {
            assert.equal(bookStore.hire('name', 'seller'), 'name started work at Burgas as seller');
            assert.equal(bookStore.workers.length, 1);
            assert.equal(JSON.stringify(bookStore.workers[0]), '{"name":"name","position":"seller","booksSold":0}');
        });

        it('should throw error with existing person', () => {
            bookStore.hire('name', 'seller');
            assert.throws(() => bookStore.hire('name', 'seller'), Error, 'This person is our employee');
        });
    });

    describe('test fire(name)', () => {
        it('should return correct message with new person', () => {
            bookStore.hire('name', 'seller');
            assert.equal(bookStore.fire('name'), `name is fired`);
            assert.equal(bookStore.workers.length, 0);
        });

        it('should throw error with existing person', () => {
            assert.throws(() => bookStore.fire('name'), Error, `name doesn't work here`);
        });
    });

    describe('test stockBooks(newBooks)', () => {
        it('should add books correct', () => {
            assert.equal(bookStore.books.length, 0);
            assert.equal(JSON.stringify(bookStore.stockBooks(['asasa-me', 'fafafa-you'])), '[{"title":"asasa","author":"me"},{"title":"fafafa","author":"you"}]');
            assert.equal(bookStore.books.length, 2);
        })
    });

    describe('test sellBook(title, workerName)', () => {
        beforeEach(() => {
            bookStore.stockBooks(['asasa-me', 'fafafa-you']);
            bookStore.hire('name', 'seller');
        });

        it('should throw error with book out of stok', () => {
            assert.throws(() => bookStore.sellBook('wrong', 'name'), Error, 'This book is out of stock');
        });

        it('should throw error with wrong worker', () => {
            assert.throws(() => bookStore.sellBook('asasa', 'wrong'), Error, 'wrong is not working here');
        });

        it('should sell book correct', () => {
            bookStore.sellBook('asasa', 'name');
            assert.equal(bookStore.books.length, 1);
            assert.equal(bookStore.workers[0].booksSold, 1);
        });
    });

    describe('test printWorkers()', () => {
        it('test witout workers', () => {
            assert.equal(bookStore.printWorkers(), "");
        })

        it('test with workers', () => {
            bookStore.hire('Ivan', 'seller');
            bookStore.hire('Gosho', 'manager');
            assert.equal(bookStore.printWorkers(), `Name:Ivan Position:seller BooksSold:0\n` + `Name:Gosho Position:manager BooksSold:0`);
        })
    });
});