let SkiResort = require('./solution');
let assert = require('chai').assert;

describe('test SkiResort class funtionality', () => {
    let ski;
    beforeEach(() => ski = new SkiResort('bansko'));

    describe('test contstructor', () => {
        it('should initialize correct', () => {
            assert.equal(ski.name, 'bansko');
            assert.equal(ski.voters, 0);
            assert.equal(JSON.stringify(ski.hotels), '[]');
        });
    });

    describe('test build(name, beds)', () => {
        it('should throw error with invalid beds or name', () => {
            assert.throws(() => ski.build("", 10), Error, "Invalid input");
            assert.throws(() => ski.build("Best", 0), Error, "Invalid input");
        });

        it('should build hotel correct', () => {
            assert.equal(ski.build('Best', 10), 'Successfully built new hotel - Best');
            assert.equal(ski.hotels.length, 1);
            assert.equal(JSON.stringify(ski.hotels[0]), '{"name":"Best","beds":10,"points":0}');
        });
    });

    describe('test book(name, beds)', () => {
        it('should throw error with invalid beds or name', () => {
            assert.throws(() => ski.book("", 10), Error, "Invalid input");
            assert.throws(() => ski.book("Best", 0), Error, "Invalid input");
        });

        beforeEach(() => ski.build('Best', 10));

        it('should throw error if hotel is not found', () => {
            assert.throws(() => ski.book('error', 10), Error, "There is no such hotel");
        });

        it('should throw error if hotel dont have enough beds', () => {
            assert.throws(() => ski.book('Best', 11), Error, "There is no free space");
        });

        it('should book correct', () => {
            assert.equal(ski.book('Best', 8), "Successfully booked");
            assert.equal(ski.hotels[0].beds, 2);
        });
    });

    describe('test leave(name, beds, points)', () => {
        it('should throw error with invalid beds or name', () => {
            assert.throws(() => ski.leave("", 10, 0), Error, "Invalid input");
            assert.throws(() => ski.leave("Best", 0, 0), Error, "Invalid input");
        });

        it('should throw error if hotel is not found', () => {
            assert.throws(() => ski.leave('error', 10, 0), Error, "There is no such hotel");
        });

        it('should leave correct', () => {
            ski.build('Best', 10);
            ski.book('Best', 8);

            assert.equal(ski.leave('Best', 3, 2), '3 people left Best hotel');
            assert.equal(ski.hotels[0].points, 6);
            assert.equal(ski.hotels[0].beds, 5);
            assert.equal(ski.voters, 3);
        });
    });

    describe('test get bestHotel()', () => {
        it('should work correct without voters', () => {
            assert.equal(ski.bestHotel, "No votes yet");
        });

        it('should work correct with voters', () => {
            ski.build('Best', 10);
            ski.book('Best', 8);
            ski.leave('Best', 3, 2);
            assert.equal(ski.bestHotel, 'Best hotel is Best with grade 6. Available beds: 5');

            ski.build('Second', 12);
            ski.book('Second', 5);
            ski.leave('Second', 5, 2);

            assert.equal(ski.bestHotel, 'Best hotel is Second with grade 10. Available beds: 12');
        });
    });

    describe('test averageGrade()', () => {
        it('should work correct without voters', () => {
            assert.equal(ski.averageGrade(), "No votes yet");
        });

        it('should work correct with voters', () => {
            ski.build('Best', 10);
            ski.book('Best', 8);
            ski.leave('Best', 3, 2);

            ski.build('Second', 12);
            ski.book('Second', 5);
            ski.leave('Second', 5, 2);

            assert.equal(ski.averageGrade(), 'Average grade: 2.00')
        });
    })
});