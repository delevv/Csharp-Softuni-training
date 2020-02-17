class Library {
    constructor(libraryName) {
        this.libraryName = libraryName;
        this.subscribers = [];
        this.subscriptionTypes = {
            normal: libraryName.length,
            special: libraryName.length * 2,
            vip: Number.MAX_SAFE_INTEGER
        }
    }

    subscribe(name, type) {
        if (!Object.keys(this.subscriptionTypes).includes(type)) {
            throw new Error(`The type ${type} is invalid`);
        }

        let person = this.subscribers.find(p => p.name === name);

        if (person) {
            person.type = type;
        }
        else {
            person = { name, type, books: [] };
            this.subscribers.push(person);
        }

        return person;
    }

    unsubscribe(name) {
        let currPerson = this.subscribers.find(p => p.name === name);

        if (currPerson) {
            let index = this.subscribers.indexOf(currPerson);
            this.subscribers.splice(index, 1);
        }
        else {
            throw new Error(`There is no such subscriber as ${name}`);
        }

        return this.subscribers;
    }

    receiveBook(subscriberName, bookTitle, bookAuthor) {
        let currPerson = this.subscribers.find(p => p.name === subscriberName);

        if (!currPerson) {
            throw new Error(`There is no such subscriber as ${subscriberName}`);
        }

        if (currPerson.books.length === this.subscriptionTypes[currPerson.type]) {
            throw new Error(`You have reached your subscription limit ${this.subscriptionTypes[currPerson.type]}!`);
        }
        else {
            currPerson.books.push({ title: bookTitle, author: bookAuthor });
        }

        return currPerson;
    }

    showInfo() {
        if (this.subscribers.length === 0) {
            return `${this.libraryName} has no information about any subscribers`;
        }

        let result = '';

        this.subscribers.forEach(s => {
            result += `Subscriber: ${s.name}, Type: ${s.type}\n` +
                `Received books: ${s.books.map(b => `${b.title} by ${b.author}`).join(', ')}\n`;
        });

        return result;
    }
}