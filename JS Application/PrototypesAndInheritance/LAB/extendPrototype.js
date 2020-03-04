function extendPrototype(currClass) {
    currClass.prototype.species = 'Human';

    currClass.prototype.toSpeciesString = function () {
        return `I am a ${this.species}. ${this.toString()}`;
    }
}