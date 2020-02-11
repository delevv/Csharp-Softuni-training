function solve() {
    let string = document.getElementById('text').value;
    let number = Number(document.getElementById('number').value);

    let neededLenght = string.length;
    let index = 0;
    let resultArr = [];

    while (neededLenght % number !== 0) {
        neededLenght++;
    }

    let symbols = '';
    for (let i = 1; i <= neededLenght; i++) {
        if (index === string.length) {
            index = 0;
        }
        symbols += string[index];

        if (i % number === 0) {
            resultArr.push(symbols);
            symbols = '';
        }
        index++;
    }

    document.getElementById('result').textContent = resultArr.join(' ');
}