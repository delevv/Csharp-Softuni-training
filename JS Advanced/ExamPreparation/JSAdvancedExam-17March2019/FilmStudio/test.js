let FilmStudio = require('./filmStudio.js');
let assert = require('chai').assert;

describe('test FilmStudio class functionality', () => {
    it('constructor should initalize correct', () => {
        let filmStudio = new FilmStudio('studio');

        assert.equal(filmStudio.name, 'studio');
        assert.equal(JSON.stringify(filmStudio.films), '[]');
    });

    let filmStudio;
    beforeEach(() => filmStudio = new FilmStudio('studio'));

    describe('test FilmStudio.casting(actor, role) functionality', () => {
        it('should return There are no films yet in ${this.name}. with no films', () => {
            assert.equal(filmStudio.casting('gosho', 'tupoto'), `There are no films yet in ${filmStudio.name}.`)
        });

        it('should return You got the job! Mr. ${actor} you are next ${role} in the ${f.filmName}. Congratz!', () => {
            filmStudio.makeMovie('shrek', ['Fiona', 'Shrek']);
            assert.equal(filmStudio.casting('Funky', 'Shrek'), `You got the job! Mr. Funky you are next Shrek in the shrek. Congratz!`)
        });

        it('should return ${actor}, we cannot find a ${role} role...', () => {
            filmStudio.makeMovie('shrek', ['Fiona', 'Shrek']);
            assert.equal(filmStudio.casting('Funky', 'badAss'), `Funky, we cannot find a badAss role...`)
        });
    });

    describe('test FilmStudio.makeMovie(filmName, roles) functionality', () => {
        it('should throw "Invalid arguments count" with 1 or 0 arguments', () => {
            assert.throw(() => filmStudio.makeMovie(), 'Invalid arguments count');
            assert.throw(() => filmStudio.makeMovie('fast'), 'Invalid arguments count');
        });

        it('should throw "Invalid arguments" with unexpected types', () => {
            assert.throw(() => filmStudio.makeMovie('fast', {}), "Invalid arguments", 'second argument');
            assert.throw(() => filmStudio.makeMovie(123, []), "Invalid arguments", 'first argument');
        });

        it('makeMovie() should work correct with new movie', () => {
            let film = filmStudio.makeMovie('shrek', ['Fiona', 'Shrek']);
            assert.equal(JSON.stringify(film), '{"filmName":"shrek","filmRoles":[{"role":"Fiona","actor":false},{"role":"Shrek","actor":false}]}');
            assert.equal(filmStudio.films.length, 1);
        });

        it('makeMovie() should work correct with new series of movie', () => {
            let film = filmStudio.makeMovie('shrek', ['Fiona', 'Shrek']);
            let film2 = filmStudio.makeMovie('shrek', ['Fiona', 'Shrek']);
            assert.equal(JSON.stringify(film2), '{"filmName":"shrek 2","filmRoles":[{"role":"Fiona","actor":false},{"role":"Shrek","actor":false}]}');
            assert.equal(filmStudio.films.length, 2);
        });
    });

    describe('test FilmStudio.lookForProducer(film) functionality', () => {
        it('should throw Error ${film} do not exist yet, but we need the money...', () => {
            assert.throws(() => filmStudio.lookForProducer('shrek'), Error, 'shrek do not exist yet, but we need the money...')
        });

        it('should return correct result', () => {
            let film = filmStudio.makeMovie('shrek', ['Fiona', 'Shrek']);
            let actualResult = filmStudio.lookForProducer('shrek');

            let expectedResult = `Film name: ${film.filmName}\n`;
            expectedResult += 'Cast:\n';
            Object.keys(film.filmRoles).forEach((role) => {
                expectedResult += `${film.filmRoles[role].actor} as ${film.filmRoles[role].role}\n`;
            });

            assert.equal(actualResult, expectedResult);
        });
    });
});