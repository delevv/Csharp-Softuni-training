function factory(face, suit) {
    let validFaces = [2, 3, 4, 5, 6, 7, 8, 9, 10, 'J', 'Q', 'K', 'A'];
    let validSuits = {
        S: "\u2660 ",
        H: "\u2665",
        D: "\u2666 ",
        C: "\u2663 "
    };

    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }

        get face() {
            return this._face;
        }

        set face(face) {
            if (!validFaces.includes(face)) {
                throw new Error();
            }
            this._face = face;
        }

        get suit() {
            return this._suit;
        }

        set suit(suit) {
            if (!Object.keys(validSuits).includes(suit)) {
                throw new Error();
            }
            this._suit = validSuits[suit];
        }

        toString() {
            return `${this.face}${this.suit}`;
        }
    }

    let card = new Card(face, suit);
    return card.toString();
}

let card = factory(10, 'H');
console.log(card)