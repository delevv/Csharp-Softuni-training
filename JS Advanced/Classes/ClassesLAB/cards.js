(() => {
    let suits = {
        CLUBS: '♠',
        DIAMONDS: '♥',
        HEARTS: '♦',
        SPADES: '♣'
    };

    let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }

        get face() {
            return this.Face;
        }
        set face(face) {
            if (!faces.includes(face)) {
                throw new Error();
            }
            this.Face = face;
        }

        get suit() {
            return this.Suit;
        }
        set suit(suit) {
            if (!Object.values(suits).includes(suit)) {
                throw new Error();
            }
            this.Suit = suit;
        }

        toString() {
            return `${this.face}${this.suit}`;
        }
    }
    return {
        Suits: suits,
        Card
    };
})();