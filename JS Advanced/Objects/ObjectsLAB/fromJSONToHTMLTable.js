function solve(input) {

    let objects = JSON.parse(input);
    let html = "<table>\n   <tr>";

    for (let key of Object.keys(objects[0]))
        html += `<th>${key}</th>`

    html += "</tr>\n";

    for (let obj of objects) {
        html += '   <tr>';
        for (let value of Object.keys(obj)) {
            html += '<td>' + htmlEscape(obj[value]) + '</td>'
        }
        html += '</tr>\n';
    }
    return html + "</table>";

    function htmlEscape(text) {
        text = text.toString();
        let map = {
            '"': '&quot;', '&': '&amp;',
            "'": '&#39;', '<': '&lt;', '>': '&gt;'
        };
        return text.replace(/[\"&'<>]/g, ch => map[ch]);
    }
}

console.log(solve(['[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]']));