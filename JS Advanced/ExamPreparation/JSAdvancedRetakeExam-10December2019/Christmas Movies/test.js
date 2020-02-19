let ChristmasMovies = require('./christmasMovies.js');
let assert = require('chai').assert;

describe('test ChristmasMovies class functionality', () => {
    let christmas;
    beforeEach(() => christmas = new ChristmasMovies());

    describe('test constructor', () => {
        it('should initialize deafault values', () => {
            assert.equal(JSON.stringify(christmas.movieCollection), '[]');
            assert.equal(JSON.stringify(christmas.watched), '{}');
            assert.equal(JSON.stringify(christmas.actors), '[]');
        });
    });

    describe('test buyMovie(movieName, actors)', () => {
        it('should add new movie correct', () => {
            assert.equal(christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']), `You just got Home Alone to your collection in which Macaulay Culkin, Joe Pesci, Daniel Stern are taking part!`);
            assert.equal(christmas.movieCollection.length, 1);
            assert.equal(JSON.stringify(christmas.movieCollection[0]), '{"name":"Home Alone","actors":["Macaulay Culkin","Joe Pesci","Daniel Stern"]}');
        });

        it('should add new movie correct with repeated actors', () => {
            assert.equal(christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']), `You just got Home Alone to your collection in which Macaulay Culkin, Joe Pesci, Daniel Stern are taking part!`);
            assert.equal(christmas.movieCollection.length, 1);
            assert.equal(JSON.stringify(christmas.movieCollection[0]), '{"name":"Home Alone","actors":["Macaulay Culkin","Joe Pesci","Daniel Stern"]}');
        });

        it('shold throw error if movie exists', () => {
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            assert.throws(() => christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']), Error, 'You already own Home Alone in your collection!');
        })
    });

    describe('test discardMovie(movieName)', () => {
        it('should throw error if movie doesnt exists', () => {
            assert.throws(() => christmas.discardMovie('error'), Error, 'error is not at your collection!');
        });

        it('should throw error if movie isnt watched', () => {
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            assert.throws(() => christmas.discardMovie('Home Alone'), Error, 'Home Alone is not watched!');
        });

        it('should remove movie correct', () => {
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            christmas.watchMovie('Home Alone');

            assert.equal(christmas.discardMovie('Home Alone'), 'You just threw away Home Alone!');
            assert.equal(christmas.movieCollection.length, 0);
            assert.equal(JSON.stringify(christmas.watched), '{}');
        });
    });

    describe('test watchMovie(movieName)', () => {
        it('should throw error when movie doesnt exists', () => {
            assert.throws(() => christmas.watchMovie('error'), Error, 'No such movie in your collection!');
        });

        it('should watch movie correct', () => {
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);

            christmas.watchMovie('Home Alone');
            assert.equal(JSON.stringify(christmas.watched), '{"Home Alone":1}');

            christmas.watchMovie('Home Alone');
            assert.equal(JSON.stringify(christmas.watched), '{"Home Alone":2}');
        });
    });

    describe('test favouriteMovie()', () => {
        it('should throw error when watched.length===0', () => {
            assert.throws(() => christmas.favouriteMovie(), Error, 'You have not watched a movie yet this year!');
        });

        it('should return correct message', () => {
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            christmas.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);

            christmas.watchMovie('Home Alone');
            christmas.watchMovie('Home Alone');
            christmas.watchMovie('The Grinch');

            assert.equal(christmas.favouriteMovie(), 'Your favourite movie is Home Alone and you have watched it 2 times!');
        });
    });

    describe('test mostStarredActor()', () => {
        it('should throw error when watched.length===0', () => {
            assert.throws(() => christmas.mostStarredActor(), Error, 'You have not watched a movie yet this year!');
        });

        it('should return correct message', () => {
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            christmas.buyMovie('Home Alone 2', ['Macaulay Culkin']);

            christmas.watchMovie('Home Alone');
            christmas.watchMovie('Home Alone');
            christmas.watchMovie('Home Alone 2');

            assert.equal(christmas.mostStarredActor(), 'The most starred actor is Macaulay Culkin and starred in 2 movies!');
        });
    });
});