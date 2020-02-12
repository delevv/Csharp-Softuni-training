function solve() {
    let key = document.getElementById('string').value;
    let message = document.getElementById('text').value;
    let resultElement = document.getElementById('result');

    let saveMessage = message.match(`${key}(.+)${key}`)[1];
    let coordPattern = new RegExp(/(?<direction>east|north).*?(?<coordinate>\d{2})[^,]*,[^,]*?(?<decimals>\d{6})/gmi);

    let north;
    let east;
    let matches = coordPattern.exec(message)

    while (matches) {
        if (matches[1].toLowerCase() === 'east') {
            east = `${matches[2]}.${matches[3]}`;
        }
        else {
            north = `${matches[2]}.${matches[3]}`;
        }
        matches = coordPattern.exec(message);
    }

    resultElement.innerHTML = `
    <p>${north} N</p>
    <p>${east} E</p>
    <p>Message: ${saveMessage}</p>
    `;
}