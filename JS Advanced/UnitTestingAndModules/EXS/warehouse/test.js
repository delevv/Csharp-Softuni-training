const Warehouse = require('./warehouse');
const assert = require('chai').assert;

describe('test Warehouse class functionality', () => {
    describe('test Warehouse constructor', () => {
        let warehouse = new Warehouse(10);

        it('capacity must be set correct', () => {
            assert.equal(warehouse.capacity, 10);
        });

        it('warehouse.availableProducts must be Object with 2 properties', () => {
            assert.isObject(warehouse.availableProducts);
            assert.equal(Object.keys(warehouse.availableProducts).length, 2);
            assert.property(warehouse.availableProducts, 'Food');
            assert.property(warehouse.availableProducts, 'Drink');
        });
    });

    describe('test Warehouse.capacity', () => {
        it('should throw `Invalid given warehouse space` with invalid value', () => {
            assert.throw(() => new Warehouse(-1), `Invalid given warehouse space`);
            assert.throw(() => new Warehouse(0), `Invalid given warehouse space`);
            assert.throw(() => new Warehouse('-1'), `Invalid given warehouse space`);
        });

        it('should set correct with valid values', () => {
            assert.equal(new Warehouse(2222).capacity, 2222);
            assert.equal(new Warehouse(0.5).capacity, 0.5);
        });
    });

    describe('test Warehouse.addProduct()', () => {
        it('should throw `There is not enough space or the warehouse is already full`', () => {
            assert.throw(() => new Warehouse(1).addProduct('Drink', 'cola', 2), `There is not enough space or the warehouse is already full`);
            assert.throw(() => new Warehouse(2).addProduct('Food', 'burger', 3), `There is not enough space or the warehouse is already full`);
        });

        it('should addProduct work correct', () => {
            let warehouse = new Warehouse(13);

            warehouse.addProduct('Drink', 'vodka', 1);
            assert.equal(warehouse.availableProducts.Drink.vodka, 1);

            warehouse.addProduct('Drink', 'vodka', 2);
            assert.equal(warehouse.availableProducts.Drink.vodka, 3);
        });

        it('should return correct object', () => {
            let warehouse = new Warehouse(10);

            assert.equal(JSON.stringify(warehouse.addProduct('Drink', 'vodka', 5)), JSON.stringify({ vodka: 5 }));
            assert.equal(JSON.stringify(warehouse.addProduct('Drink', 'tea', 5)), JSON.stringify({ vodka: 5, tea: 5 }));
        });
    });

    describe('test Warehouse.orderProducts()', () => {
        it('should order correct with products(different quantities)', () => {
            let warehouse = new Warehouse(16);
            warehouse.addProduct('Food', 'apple', 1);
            warehouse.addProduct('Food', 'carrot', 4);
            warehouse.addProduct('Food', 'pork', 5);

            let expectedResult = { pork: 5, carrot: 4, apple: 1 };
            let actualResult = warehouse.orderProducts('Food');

            assert.equal(JSON.stringify(actualResult), JSON.stringify(expectedResult));
            assert.equal(JSON.stringify(warehouse.availableProducts.Food), JSON.stringify(expectedResult));
        });

        it('should order correct with products(same quantities)', () => {
            let warehouse = new Warehouse(12);
            warehouse.addProduct('Drink', 'vodka', 1);
            warehouse.addProduct('Drink', 'rakia', 5);
            warehouse.addProduct('Drink', 'wine', 5);

            let expectedResult = { rakia: 5, wine: 5, vodka: 1 };
            let actualResult = warehouse.orderProducts('Drink');

            assert.equal(JSON.stringify(actualResult), JSON.stringify(expectedResult));
        });

        it('should return empty object without products', () => {
            let warehouse = new Warehouse(10);

            let expectedResult = {};
            let actualResult = warehouse.orderProducts('Drink');

            assert.equal(JSON.stringify(actualResult), JSON.stringify(expectedResult));
        });
    });

    describe('test Warehouse.revision()', () => {
        it('should return "The warehouse is empty" when there is no products', () => {
            let warehouse = new Warehouse(1);
            assert.equal(warehouse.revision(), 'The warehouse is empty');
        });

        it('should return correct string with unordered products', () => {
            let warehouse = new Warehouse(10);

            warehouse.addProduct('Food', 'hamburger', 1);
            warehouse.addProduct('Food', 'egg', 4);
            warehouse.addProduct('Drink', 'rakia', 5);

            let expectedResult = '';
            for (const type of Object.keys(warehouse.availableProducts)) {
                expectedResult += `Product type - [${type}]\n`;
                for (const [product, quantity] of Object.entries(warehouse.availableProducts[type])) {
                    expectedResult += `- ${product} ${quantity}\n`;
                }
            }
            expectedResult = expectedResult.trim();

            let actualResult = warehouse.revision();

            assert.equal(actualResult, expectedResult);
        });
    });

    describe('test Warehouse.scrapeAProduct()', () => {
        it('should throw `${ product } do not exists` when product is not found', () => {
            assert.throw(() => new Warehouse(2).scrapeAProduct('burger', 3), `burger do not exists`);
        });

        it('should set product quantity to 0 if we try to reduce it with more', () => {
            let warehouse = new Warehouse(100);
            warehouse.addProduct('Food', 'burger', 10);

            assert.equal(JSON.stringify(warehouse.scrapeAProduct('burger', 11)), JSON.stringify({ burger: 0 }));
        });

        it('should remove product quantities correct', () => {
            let warehouse = new Warehouse(100);

            warehouse.addProduct('Food', 'burger', 10);
            assert.equal(JSON.stringify(warehouse.scrapeAProduct('burger', 10)), JSON.stringify({ burger: 0 }));

            warehouse.addProduct('Food', 'grape', 11.4);
            assert.equal(JSON.stringify(warehouse.scrapeAProduct('grape', 1.4)), JSON.stringify({ burger: 0, grape: 10 }));
        });
    });
});