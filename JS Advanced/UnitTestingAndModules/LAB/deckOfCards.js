function printDeckOfCards(cards) {
    function factory(face, suit) {
        let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        let validSuits = {
            S: "\u2660",
            H: "\u2665",
            D: "\u2666",
            C: "\u2663"
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
                    throw new Error(`${face}${suit}`);
                }
                this._face = face;
            }

            get suit() {
                return this._suit;
            }

            set suit(suit) {
                if (!Object.keys(validSuits).includes(suit)) {
                    throw new Error(`${face}${suit}`);
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

    let checkedCards = [];
    for (const card of cards) {
        let face = '';
        let suit = '';

        if (card.length === 2) {
            face = card[0];
            suit = card[1];
        }
        else {
            face = card[0] + card[1];
            suit = card[2];
        }

        try {
            let card = factory(face, suit);
            checkedCards.push(card);
        }
        catch{
            console.log(`Invalid card: ${card}`);
            return;
        }
    }
    console.log(checkedCards.join(' '));
}

printDeckOfCards(['AS', '10D', 'KH', '2C']));
printDeckOfCards(['5S', '3D', 'QD', '1C']));