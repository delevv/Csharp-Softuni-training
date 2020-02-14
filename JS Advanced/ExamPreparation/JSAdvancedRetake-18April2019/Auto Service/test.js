let AutoService = require('./autoService.js');
let assert = require('chai').assert;

describe('test AutoService class functionality', () => {
    let service;
    beforeEach(() => {
        service = new AutoService(1);
    })

    it('constructor should intitialize class correct with default values', () => {
        assert.equal(service.garageCapacity, 1);
        assert.equal(JSON.stringify(service.workInProgress), '[]');
        assert.equal(JSON.stringify(service.backlogWork), '[]');
    });

    it('availableSpace should return correct result', () => {
        assert.equal(service.availableSpace, 1);
        service.signUpForReview('gosho', 'a5644a', {});
        assert.equal(service.availableSpace, 0);
    });

    it('signUpForReview(clientName, plateNumber, carInfo) should work correct', () => {
        service.signUpForReview('gosho', 'a5644a', {});
        assert.equal(service.workInProgress.length, 1);

        service.signUpForReview('asen', 'abasf', {});
        assert.equal(service.backlogWork.length, 1);
    });

    it('carInfo(plateNumber, clientName) should work correct', () => {
        service.signUpForReview('gosho', 'a5644a', {});
        assert.equal(JSON.stringify(service.carInfo('a5644a', 'gosho')), '{"plateNumber":"a5644a","clientName":"gosho","carInfo":{}}');

        assert.equal(service.carInfo('b', 'georgi'), 'There is no car with platenumber b and owner georgi.');

        service.signUpForReview('asen', 'asss', {});
        assert.equal(JSON.stringify(service.carInfo('asss', 'asen')), '{"plateNumber":"asss","clientName":"asen","carInfo":{}}');

    });

    it('repairCar should work correct', () => {
        assert.equal(service.repairCar(), 'No clients, we are just chilling...');

        service.signUpForReview('Peter', 'CA1234CA', { 'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'doors': 'broken', 'wheels': 'broken', 'tires': 'broken' });
        service.signUpForReview('Peter', 'CA1234CA', { 'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'doors': 'ok', 'wheels': 'ok', 'tires': 'ok' });

        assert.equal(service.workInProgress.length, 1);
        assert.equal(service.repairCar(), 'Your doors and wheels and tires were repaired.')
        assert.equal(service.workInProgress.length, 0);

        assert.equal(service.backlogWork.length, 1);
        assert.equal(service.repairCar(), 'Your car was fine, nothing was repaired.');
        assert.equal(service.backlogWork.length, 0);
    })
});