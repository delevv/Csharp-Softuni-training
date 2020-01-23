function solve(input) {
    let html = '<table>\n';

    for (let line of input) {
        let employee = JSON.parse(line);

        html += '\t<tr>\n';
        html += `\t\t<td>${htmlEscape(employee.name)}</td>\n`;
        html += `\t\t<td>${htmlEscape(employee.position)}</td>\n`
        html += `\t\t<td>${employee.salary}</td>\n`;
        html += '\t</tr>\n';
    }
    html += '</table>';

    console.log(html);

    function htmlEscape(text) {
        let map = {
            '"': '&quot;', '&': '&amp;',
            "'": '&#39;', '<': '&lt;', '>': '&gt;'
        };
        return text.replace(/[\"&'<>]/g, ch => map[ch]);
    }
}

solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}']
);