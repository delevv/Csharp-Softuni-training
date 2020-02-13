class Hotel {
    constructor(name, capacity) {
        this.name = name;
        this.capacity = capacity;
        this.bookings = [];
        this.currentBookingNumber = 1;
        this.roomsCapacity = {
            single: Math.floor(this.capacity * 0.5),
            double: Math.floor(this.capacity * 0.3),
            maisonette: Math.floor(this.capacity * 0.2)
        }
    }

    get roomsPricing() {
        return { single: 50, double: 90, maisonette: 135 }
    };

    get servicesPricing() {
        return { food: 10, drink: 15, housekeeping: 25 };
    };

    rentARoom(clientName, roomType, nights) {
        let message = "";
        if (this.roomsCapacity[roomType] > 0) {
            let clientHistory = {
                clientName,
                roomType,
                nights,
                roomNumber: this.currentBookingNumber === 1 ? 1 : this.currentBookingNumber
            };

            this.bookings.push(clientHistory);
            this.roomsCapacity[roomType]--;

            message = `Enjoy your time here Mr./Mrs. ${clientName}. Your booking is ${this.currentBookingNumber}.`

            this.currentBookingNumber++;
        }
        else {
            message = `No ${roomType} rooms available!`;
            Object.entries(this.roomsCapacity).filter(([type, count]) => count > 0).forEach(([type, count]) => {
                message += ` Available ${type} rooms: ${count}.`
            });
        }
        return message;
    }

    roomService(currentBookingNumber, serviceType) {
        let message = '';
        let currentBook = this.bookings.find(b => b.roomNumber === currentBookingNumber);

        if (currentBook) {
            if (Object.keys(this.servicesPricing).includes(serviceType)) {
                if (!currentBook.services) {
                    currentBook.services = [];
                }
                currentBook.services.push(serviceType);
                message = `Mr./Mrs. ${currentBook.clientName}, Your order for ${serviceType} service has been successful.`;
            }
            else {
                message = `We do not offer ${serviceType} service.`;
            }
        }
        else {
            message = `The booking ${currentBookingNumber} is invalid.`;
        }
        return message;
    }

    checkOut(currentBookingNumber) {
        let message = '';
        let currentBook = this.bookings.find(b => b.roomNumber === currentBookingNumber);

        if (currentBook) {
            this.roomsCapacity[currentBook.roomType]++;
            let index = this.bookings.indexOf(currentBook);
            this.bookings.splice(index, 1);

            let totalMoney = this.roomsPricing[currentBook.roomType] * currentBook.nights;

            message = `We hope you enjoyed your time here, Mr./Mrs. ${currentBook.clientName}. The total amount of money you have to pay is ${totalMoney} BGN.`;

            if (currentBook.services) {
                let totalServiceMoney = 0;
                currentBook.services.forEach(s => totalServiceMoney += this.servicesPricing[s]);

                message = `We hope you enjoyed your time here, Mr./Mrs. ${currentBook.clientName}. The total amount of money you have to pay is ${totalMoney + totalServiceMoney} BGN. You have used additional room services, costing ${totalServiceMoney} BGN.`;
            }
        }
        else {
            message = `The booking ${currentBookingNumber} is invalid.`;
        }

        return message;
    }

    report() {
        let result = `${this.name.toUpperCase()} DATABASE:` + '\n--------------------\n';
        let books = [];

        if (this.bookings.length > 0) {
            this.bookings.forEach(b => {
                let curr = `bookingNumber - ${b.roomNumber}\n` +
                    `clientName - ${b.clientName}\n` +
                    `roomType - ${b.roomType}\n` +
                    `nights - ${b.nights}`;

                if (b.services) {
                    curr += `\nservices: ${b.services.join(', ')}`;
                }

                books.push(curr);
            })
            result += books.join('\n----------\n');
        }
        else {
            result += 'There are currently no bookings.';
        }

        return result;
    }
}