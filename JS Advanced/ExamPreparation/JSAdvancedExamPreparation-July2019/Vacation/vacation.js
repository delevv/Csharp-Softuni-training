class Vacation {
    constructor(organizer, destination, budget) {
        this.organizer = organizer;
        this.destination = destination;
        this.budget = budget;
        this.kids = {};
    }

    get numberOfChildren() {
        return Object.values(this.kids).reduce((acc, curr) => acc + curr.length, 0);
    }
    registerChild(name, grade, budget) {
        let message = '';

        if (budget >= this.budget) {
            if (!this.kids[grade]) {
                this.kids[grade] = [];
            }

            if (this.kids[grade].includes(`${name}-${budget}`)) {
                message = `${name} is already in the list for this ${this.destination} vacation.`;
            }
            else {
                let kid = `${name}-${budget}`;
                this.kids[grade].push(kid);
                message = this.kids[grade];
            }
        }
        else {
            message = `${name}'s money is not enough to go on vacation to ${this.destination}.`;
        }

        return message;
    }

    removeChild(name, grade) {
        if (this.kids[grade]) {
            let currKid = this.kids[grade].find(k => k.split('-')[0] === name);

            if (currKid) {
                let index = this.kids[grade].indexOf(currKid);
                this.kids[grade].splice(index, 1);

                return this.kids[grade];
            }
            else {
                return `We couldn't find ${name} in ${grade} grade.`;
            }
        }
        else {
            return `We couldn't find ${name} in ${grade} grade.`;
        }
    }

    toString() {
        let result = `${this.organizer} will take ${this.numberOfChildren} children on trip to ${this.destination}\n`;

        Object.entries(this.kids).sort((a, b) => +a[0] - +b[0]).forEach(([grade, kids]) => {
            result += `Grade: ${grade}\n`;

            for (let i = 0; i < kids.length; i++) {
                result += `${i + 1}. ${kids[i]}\n`;

            }
        });

        if (this.numberOfChildren === 0) {
            result = `No children are enrolled for the trip and the organization of ${this.organizer} falls out...`;
        }

        return result;
    }
}

let vacation = new Vacation('Miss Elizabeth', 'Dubai', 2000);
console.log(vacation.toString());
