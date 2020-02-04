class Rat {
    constructor(name) {
        this.name = name;
        this.unitedRats = [];
    }

    unite(otherRat) {
        if (otherRat instanceof Rat) {
            this.unitedRats.push(otherRat);
            otherRat.unitedRats.push(this);
        }
    }

    getRats() {
        return this.unitedRats;
    }

    toString() {
        let result = this.name;

        this.unitedRats.forEach(rat => {
            result += `\n##${rat.name}`;
        });

        return result;
    }
}