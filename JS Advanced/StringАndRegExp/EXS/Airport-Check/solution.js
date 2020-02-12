function solve() {
    let [input, type] = document.getElementById('string').value.split(', ');

    let namePattern = / [A-Z][A-Za-z]*-[A-Z][A-Za-z]*( |\.-[A-Z][A-Za-z]* )/;
    let airportPattern = / [A-Z]{3}\/[A-Z]{3} /;
    let numberPattern = / [A-Z]{1,3}[\d]{1,5} /;
    let companyPattern = /- [A-Z][A-Za-z]*\*[A-Z][A-Za-z]* /;

    let name = input.match(namePattern)[0].trim().replace(/-/g, " ");
    let [from, to] = input.match(airportPattern)[0].trim().split("/");
    let number = input.match(numberPattern)[0].trim();
    let company = input.match(companyPattern)[0].replace("- ", "").replace(/\*/g, " ").trim();

    let result;
    switch (type) {
        case "name": result = (`Mr/Ms, ${name}, have a nice flight!`);
            break;
        case "flight": result = (`Your flight number ${number} is from ${from} to ${to}.`);
            break;
        case "company": result = (`Have a nice flight with ${company}.`);
            break;
        case "all": result = (`Mr/Ms, ${name}, your flight number ${number} is from ${from} to ${to}. Have a nice flight with ${company}.`);
            break;
    }

    document.getElementById('result').textContent=result;
}