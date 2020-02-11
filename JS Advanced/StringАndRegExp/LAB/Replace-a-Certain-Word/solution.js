function solve() {
    let word = document.getElementById('word').value;
    let inputArray = JSON.parse(document.getElementById('text').value);

    let resultArray = [];
    let wordToChange = inputArray[0].split(' ')[2];
    let regex = new RegExp(`${wordToChange}`, "gi");

    inputArray.forEach(string => {
        let curr = string.replace(regex, word);
        resultArray.push(curr);
    });

    let resultSpan = document.getElementById('result');

    resultArray.forEach(el => {
        let p = document.createElement('p');
        p.textContent = el;
        resultSpan.appendChild(p);
    });
}