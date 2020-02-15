let SoftUniFy = require('./softunify.js');
let assert = require('chai').assert;

describe('test SoftUniFy class functionality', () => {
    let soft;
    beforeEach(() => soft = new SoftUniFy());

    describe('contructor test', () => {
        it('should initialize allSongs with empty object', () => {
            assert.equal(JSON.stringify(soft.allSongs), '{}');
        });
    });

    describe('test downloadSong(artist, song, lyrics)', () => {
        it('should add song correct with new artis', () => {
            soft.downloadSong('Eminem', 'Venom', 'Knock, KnocK');
            assert.equal(JSON.stringify(soft.allSongs), '{"Eminem":{"rate":0,"votes":0,"songs":["Venom - Knock, KnocK"]}}');
        });

        it('should add song correct with existing artis', () => {
            soft.downloadSong('Eminem', 'Venom', 'Knock, KnocK');
            soft.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
            assert.equal(JSON.stringify(soft.allSongs), '{"Eminem":{"rate":0,"votes":0,"songs":["Venom - Knock, KnocK","Phenomenal - IM PHENOMENAL..."]}}');
        });

        it('should return correct value', () => {
            assert.equal(JSON.stringify(soft.downloadSong('Eminem', 'Venom', 'Knock, KnocK')), '{"allSongs":{"Eminem":{"rate":0,"votes":0,"songs":["Venom - Knock, KnocK"]}}}');
        });
    });

    describe('test playSong(song)', () => {
        it('shoul return correct message without songs in list', () => {
            assert.equal(soft.playSong('old town road'), `You have not downloaded a old town road song yet. Use SoftUniFy's function downloadSong() to change that!`);
        });

        beforeEach(() => {
            soft.downloadSong('Eminem', 'Venom', 'Knock, KnocK');
            soft.downloadSong('Valdes', 'Ribna fiesta', 'i lovec sum i ribar sum');
        });

        it('should return correct message if song is not found', () => {
            assert.equal(soft.playSong('blue jeans'), `You have not downloaded a blue jeans song yet. Use SoftUniFy's function downloadSong() to change that!`);
        });

        it('should return correct message if song is found', () => {
            assert.equal(soft.playSong('Venom'), 'Eminem:\nVenom - Knock, KnocK\n');
        });

        it('should return correct message if song is found', () => {
            soft.downloadSong('SpiderMan', 'Venom', 'Knock, KnocK');
            assert.equal(soft.playSong('Venom'), 'Eminem:\nVenom - Knock, KnocK\nSpiderMan:\nVenom - Knock, KnocK\n');
        });
    });

    describe('test songsList', () => {
        it('should return correct message without songs', () => {
            assert.equal(soft.songsList, 'Your song list is empty');
        });

        it('should return correct messag with songs', () => {
            soft.downloadSong('Eminem', 'Venom', 'Knock, KnocK');
            soft.downloadSong('Valdes', 'Ribna fiesta', 'i lovec sum i ribar sum');

            assert.equal(soft.songsList, 'Venom - Knock, KnocK\nRibna fiesta - i lovec sum i ribar sum')
        })
    });

    describe('test rateArtist()', () => {
        beforeEach(() => {
            soft.downloadSong('Eminem', 'Venom', 'Knock, KnocK');
            soft.rateArtist('Eminem', 10);
        });

        it('should return correct message when artist in not found', () => {
            assert.equal(soft.rateArtist('Valdes'), `The Valdes is not on your artist list.`)
        });

        it('should return correct message with 1 argument', () => {
            assert.equal(soft.rateArtist('Eminem'), 10.00)
        });

        it('should return correct message with 2 arguments', () => {
            assert.equal(soft.rateArtist('Eminem', 5), 7.50)
        });

        it('should return correct message if arguments[1] is not a Number', () => {
            assert.equal(soft.rateArtist('Eminem', 'asf'), 0)
        });
    });
});