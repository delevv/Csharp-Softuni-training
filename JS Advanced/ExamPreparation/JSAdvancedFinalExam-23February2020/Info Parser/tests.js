let Parser = require("./solution.js");
let assert = require("chai").assert;

describe("test Parser class functionality", () => {
    let parser;
    beforeEach(() => parser = new Parser('[{"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]'));

    describe('test get data()', () => {
        it('should work correct', () => {
            assert.equal(JSON.stringify(parser.data), '[{"Nancy":"architect"},{"John":"developer"},{"Kate":"HR"}]');
            assert.equal(JSON.stringify(parser._log), '["0: getData"]');
            parser.removeEntry('Nancy');
            assert.equal(JSON.stringify(parser._log), '["0: getData","1: removeEntry"]');
            assert.equal(JSON.stringify(parser.data), '[{"John":"developer"},{"Kate":"HR"}]');
            assert.equal(JSON.stringify(parser._log), '["0: getData","1: removeEntry","2: getData"]');
        });
    });

    describe('test addEntries(entries)', () => {
        it('should return correct result', () => {
            assert.equal(parser.data.length, 3);
            assert.equal(parser.addEntries("Steven:tech-support Edd:administrator"), 'Entries added!');
            assert.equal(parser.data.length, 5);         
            assert.equal(JSON.stringify(parser.data), '[{"Nancy":"architect"},{"John":"developer"},{"Kate":"HR"},{"Steven":"tech-support"},{"Edd":"administrator"}]');
            assert.equal(JSON.stringify(parser._log), '["0: getData","1: addEntries","2: getData","3: getData"]');
        })
    });

    describe('test removeEntry(key) ', () => {
        it('should throw error if entry is not found', () => {
            assert.throw(() => parser.removeEntry('error'), Error, "There is no such entry!");
            assert.equal(JSON.stringify(parser._log), '[]');
        });

        it('should throw error if entry is alredy deleted', () => {
            parser.removeEntry('Nancy');
            
            assert.throw(() => parser.removeEntry('Nancy'), Error, "There is no such entry!");
            assert.equal(JSON.stringify(parser._log), '["0: removeEntry"]');
        });

        it('should work correct', () => {
            assert.equal(parser.removeEntry('Nancy'), "Removed correctly!");
            assert.equal(JSON.stringify(parser._log), '["0: removeEntry"]');
            assert.equal(JSON.stringify(parser._data), '[{"Nancy":"architect","deleted":true},{"John":"developer"},{"Kate":"HR"}]');
            assert.equal(parser._data[0].deleted, true)
        });
    });

    describe('test  print()', () => {
        it('should return correct result', () => {
            parser.removeEntry('Nancy');
            assert.equal(parser.print(), 'id|name|position\n0|John|developer\n1|Kate|HR');
        });

        it('should return correct with no entries', () => {
            parser.removeEntry('Nancy');
            parser.removeEntry('John');
            parser.removeEntry('Kate');
            assert.equal(parser.print(), 'id|name|position');
        });

        it('should return correct result', () => {
            let expected = parser.data.reduce((acc, x, index) => {
                acc.push(`${index}|${Object.keys(x)[0]}|${Object.values(x)[0]}`);
                return acc;
            }, ["id|name|position"]).join("\n");

            assert.equal(parser.print(), expected)
        });
    });

    describe('example test', () => {
        it('should work correct', () => {
            assert.equal(parser.addEntries("Steven:tech-support Edd:administrator"), 'Entries added!');
            assert.equal(JSON.stringify(parser.data), '[{"Nancy":"architect"},{"John":"developer"},{"Kate":"HR"},{"Steven":"tech-support"},{"Edd":"administrator"}]');
            assert.equal(JSON.stringify(parser.removeEntry("Kate")), '"Removed correctly!"');
            assert.equal(JSON.stringify(parser.data), '[{"Nancy":"architect"},{"John":"developer"},{"Steven":"tech-support"},{"Edd":"administrator"}]');
            assert.equal(parser.print(), 'id|name|position\n0|Nancy|architect\n1|John|developer\n2|Steven|tech-support\n3|Edd|administrator');
            assert.equal(JSON.stringify(parser._log), '["0: addEntries","1: getData","2: removeEntry","3: getData","4: print"]');
        });
    });
});