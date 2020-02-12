function solve() {
    let [key, ...line] = JSON.parse(document.getElementById('array').value);
    let resultElement = document.getElementById('result');

    let messageRgx = new RegExp(`${key}[ ]+([A-Z!%#\$]{8,})([\., ]|$)`, 'gmi');

    line.forEach(data => {
        let replacedLine = data;

        if (data.match(messageRgx)) {
            let matches = data.match(messageRgx)
                .map(x => x.split(' ')[1])
                .filter(x => x === x.toUpperCase())
                .map(x => {
                    let parsedWord = x
                        .replace(/!/g, 1)
                        .replace(/%/g, 2)
                        .replace(/#/g, 3)
                        .replace(/\$/g, 4)
                        .toLowerCase();

                    replacedLine = replacedLine.replace(x, parsedWord);
                });
        }
        let p = document.createElement('p');
        p.textContent = replacedLine;
        resultElement.appendChild(p);
    });
}