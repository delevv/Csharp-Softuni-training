class Person {
    constructor(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get firstName() {
        return this._firstName;
    }

    set firstName(value) {
        this._firstName = value;
    }

    get lastName() {
        return this._lastName;
    }

    set lastName(value) {
        this._lastName = value;
    }

    get fullName() {
        return `${this.firstName} ${this.lastName}`;
    }

    set fullName(value) {
        let names = value.split(" ");

        if (names.length === 2 && names[0] !== undefined && names[1] !== undefined) {
            this.firstName = names[0];
            this.lastName = names[1];
        }
    }
}

let person = new Person("Albert", "Simpson");
console.log(person.fullName);//Albert Simpson
person.firstName = "Simon";
console.log(person.fullName);//Simon Simpson
person.fullName = "Peter";
console.log(person.firstName) // Simon
console.log(person.lastName) // Simpson