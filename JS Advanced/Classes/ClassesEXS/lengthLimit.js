class Stringer {
    constructor(string, length) {
        this.innerString = string;
        this.innerLength = length;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        if (this.innerLength - length >= 0) {
            this.innerLength -= length;
        }
        else {
            this.innerLength = 0;
        }
    }

    toString() {
        if (this.innerLength < this.innerString.length) {
            return this.innerString.slice(0, this.innerLength) + '...';
        }
        return this.innerString;
    }
}