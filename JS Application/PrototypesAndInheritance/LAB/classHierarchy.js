function solve() {
    class Figure {
        constructor(currUnit = 'cm') {
            this.unit = currUnit;
        }

        allUnits = { m: 0.01, cm: 1, mm: 10 };

        getCorrectValue(value) {
            return value * this.allUnits[this.unit];
        }

        get area() {
            return NaN;
        }

        changeUnits(unit) {
            this.unit = unit
        }

        toString() {
            return `Figures units: ${this.unit} Area: ${this.area}`;
        }
    }

    class Circle extends Figure {
        constructor(radius, unit) {
            super(unit);
            this.radius = radius;
        }

        get area() {
            return Math.PI * Math.pow(this.getCorrectValue(this.radius), 2);
        }

        toString() {
            return `${super.toString()} - radius: ${this.getCorrectValue(this.radius)}`;
        }
    }

    class Rectangle extends Figure {
        constructor(width, height, unit) {
            super(unit);
            this.width = width;
            this.height = height;
        }

        get area() {
            return this.getCorrectValue(this.width) * this.getCorrectValue(this.height);
        }

        toString() {
            return `${super.toString()} - width: ${this.getCorrectValue(this.width)}, height: ${this.getCorrectValue(this.height)}`;
        }
    }

    return {
        Figure,
        Circle,
        Rectangle
    }
}