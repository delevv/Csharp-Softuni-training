function solve(input, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = +price;
            this.status = status;
        }
    }

    let tickets = [];

    input.forEach(element => {
        let [destination, price, status] = element.split('|');
        tickets.push(new Ticket(destination, price, status));
    });

    return tickets.sort((a, b) => {
        let type = typeof a[criteria];

        if (type === 'string') {
            return a[criteria].localeCompare(b[criteria]);
        }
        else {
            return a[criteria] - b[criteria];
        }
    });
}