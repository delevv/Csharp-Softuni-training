function solve() {
    let userData = JSON.parse(document.getElementById('arr').value);
    let regex = /^([A-Z][a-z]* [A-Z][a-z]*) (\+359( |-)[0-9]\3[0-9]{3}\3[0-9]{3}) ([a-z0-9]+@[a-z]+.[a-z]{2,3})/;

    let result = [];

    userData.forEach(el => {
        let matches = el.match(regex);
        if (matches) {
            result.push(`Name: ${matches[1]}`)
            result.push(`Phone Number: ${matches[2]}`)
            result.push(`Email: ${matches[4]}`)
            result.push('- - -');
        }
        else {
            result.push("Invalid data");
            result.push('- - -');
        }
    });

    let span = document.getElementById('result');

    result.forEach(el => {
        let p = document.createElement('p');
        p.textContent = el;
        span.appendChild(p);
    });
}