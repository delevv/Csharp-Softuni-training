function solve(input) {
    function htmlEscape(text) {
        let map = {
            '"': '&quot;', '&': '&amp;',
            "'": '&#39;', '<': '&lt;', '>': '&gt;'
        };
        return text.replace(/[\"&'<>]/g, ch => map[ch]);
    }

    let result = "<table>\n  <tr><th>name</th><th>score</th></tr>\n";
    let table = JSON.parse(input);

    for (let record of table) {
        result += `  <tr><td>${htmlEscape(record.name)}</td><td>${record.score}</td></tr>\n`;
    }

    result += "</table>";

    console.log(result);
}

solve(['[{"name":"Pesho & Kiro","score":479},{"name":"Gosho, Maria & Viki","score":205}]']);