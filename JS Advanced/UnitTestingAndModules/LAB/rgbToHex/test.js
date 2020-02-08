let rgbToHexColor = require('./rgbToHex.js');
let assert = require('chai').assert;

describe('check the functionality of rgbToHex()', () => {
    it('should return undefined with invalid red color number', () => {
        assert.equal(rgbToHexColor(-1, 1, 1), undefined, 'check with integer less than zero');
        assert.equal(rgbToHexColor(1.2, 1, 1), undefined, 'check with decimal');
        assert.equal(rgbToHexColor(256, 1, 1), undefined, 'check with integer more than 255');
        assert.equal(rgbToHexColor('asd', 1, 1), undefined, 'check with invalid type');
        assert.equal(rgbToHexColor({}, 1, 1), undefined, 'check with invalid type');
    });

    it('should return undefined with invalid green color number', () => {
        assert.equal(rgbToHexColor(1, -1, 1), undefined, 'check with integer less than zero');
        assert.equal(rgbToHexColor(1, 1.2, 1), undefined, 'check with non integer');
        assert.equal(rgbToHexColor(1, 256, 1), undefined, 'check with integer more than 255');
        assert.equal(rgbToHexColor(1, 'asd', 1), undefined, 'check with invalid type');
        assert.equal(rgbToHexColor(1, {}, 1), undefined, 'check with invalid type');
    });

    it('should return undefined with invalid blue color number', () => {
        assert.equal(rgbToHexColor(1, 1, -1), undefined, 'check with integer less than zero');
        assert.equal(rgbToHexColor(1, 1, 1.2), undefined, 'check with non integer');
        assert.equal(rgbToHexColor(1, 1, 256), undefined, 'check with integer more than 255');
        assert.equal(rgbToHexColor(1, 1, 'asd'), undefined, 'check with invalid type');
        assert.equal(rgbToHexColor(1, 1, {}), undefined, 'check with invalid type');
    });

    it('should return valid hex', () => {
        assert.equal(rgbToHexColor(1, 1, 1), '#010101');
        assert.equal(rgbToHexColor(255, 255, 255), '#FFFFFF');
        assert.equal(rgbToHexColor(1, 100, 200), '#0164C8');
        assert.equal(rgbToHexColor(0, 0, 0), '#000000');
    });
});