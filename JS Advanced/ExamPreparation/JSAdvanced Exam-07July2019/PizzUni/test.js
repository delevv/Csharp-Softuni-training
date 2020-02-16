let PizzUni = require('./pizzUni.js');
let assert = require('chai').assert;

describe('test PizzUni class functionality', () => {
    let pizz;
    beforeEach(() => pizz = new PizzUni());

    describe('test constructor', () => {
        it('should initialize registeredUsers with empty array', () => {
            assert.equal(JSON.stringify(pizz.registeredUsers), '[]');
        });

        it('should initialize availableProducts with object', () => {
            assert.isObject(pizz.availableProducts);

            assert.property(pizz.availableProducts, 'pizzas');
            assert.property(pizz.availableProducts, 'drinks');

            assert.equal(JSON.stringify(pizz.availableProducts.pizzas), '["Italian Style","Barbeque Classic","Classic Margherita"]');
            assert.equal(JSON.stringify(pizz.availableProducts.drinks), '["Coca-Cola","Fanta","Water"]');
        });

        it('should initialize orders with empty array', () => {
            assert.equal(JSON.stringify(pizz.orders), '[]');
        });
    });

    describe('test registerUser(email)', () => {
        it('test with new user', () => {
            assert.equal(JSON.stringify(pizz.registerUser('gosho')), '{"email":"gosho","orderHistory":[]}');
            assert.equal(pizz.registeredUsers.length, 1);
            assert.equal(JSON.stringify(pizz.registeredUsers[0]), '{"email":"gosho","orderHistory":[]}');
        });

        it('test with existing user should throw error', () => {
            pizz.registerUser('gosho');
            assert.throws(() => pizz.registerUser('gosho'), Error, 'This email address (gosho) is already being used!');
        });
    });

    describe('test  makeAnOrder(email, orderedPizza, orderedDrink)', () => {
        it('should throw error if user doesnt exist', () => {
            assert.throws(() => pizz.makeAnOrder('fake', 'Italian Style', 'Fanta'), Error, 'You must be registered to make orders!');
        });

        it('should create order with drink', () => {
            pizz.registerUser('gosho');
            assert.equal(JSON.stringify(pizz.makeAnOrder('gosho', 'Italian Style', 'Fanta')), 0)
            assert.equal(pizz.orders.length, 1);
            assert.equal(JSON.stringify(pizz.orders[0]), '{"orderedPizza":"Italian Style","orderedDrink":"Fanta","email":"gosho","status":"pending"}');
            assert.equal(JSON.stringify(pizz.registeredUsers[0]), '{"email":"gosho","orderHistory":[{"orderedPizza":"Italian Style","orderedDrink":"Fanta"}]}');
        });

        it('should create order without drink', () => {
            pizz.registerUser('gosho');
            assert.equal(JSON.stringify(pizz.makeAnOrder('gosho', 'Italian Style')), 0)
            assert.equal(pizz.orders.length, 1);
            assert.equal(JSON.stringify(pizz.orders[0]), '{"orderedPizza":"Italian Style","email":"gosho","status":"pending"}');
            assert.equal(JSON.stringify(pizz.registeredUsers[0]), '{"email":"gosho","orderHistory":[{"orderedPizza":"Italian Style"}]}');
        });

        it('should throw error if pizza doesnt exist', () => {
            pizz.registerUser('gosho');
            assert.throws(() => pizz.makeAnOrder('gosho', 'fake pizza'), Error, 'You must order at least 1 Pizza to finish the order.');
        })
    });

    describe('test completeOrder(id)', () => {
        it('should return order', () => {
            pizz.registerUser('gosho');
            pizz.makeAnOrder('gosho', 'Italian Style', 'Fanta');

            assert.equal(JSON.stringify(pizz.completeOrder(0)), '{"orderedPizza":"Italian Style","orderedDrink":"Fanta","email":"gosho","status":"completed"}');
            assert.equal(JSON.stringify(pizz.orders[0]), '{"orderedPizza":"Italian Style","orderedDrink":"Fanta","email":"gosho","status":"completed"}');
        });

        it('should return undefined without orders or when id doesnt exist', () => {
            assert.equal(pizz.completeOrder(0), undefined);
        });
    });

    describe('test detailsAboutMyOrder(id)', () => {
        it('should return correct message when order is found', () => {
            pizz.registerUser('gosho');
            pizz.makeAnOrder('gosho', 'Italian Style', 'Fanta');

            assert.equal(pizz.detailsAboutMyOrder(0), 'Status of your order: pending')
        })

        it('should return undefined without orders or when id doesnt exist', () => {
            assert.equal(pizz.detailsAboutMyOrder(0), undefined);
        });
    })
});