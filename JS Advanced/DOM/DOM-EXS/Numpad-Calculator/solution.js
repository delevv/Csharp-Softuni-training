function solve() {
    const expressionOutput = document.getElementById("expressionOutput");
    const resultOutput = document.getElementById("resultOutput");
    const operators = ["+", "-", "/", "*"];

    Array.from(document.getElementsByTagName("button")).forEach(b => {
        b.addEventListener("click", function (e) {
            let value = e.target.value;

            if (isNaN(value)) {
                if (operators.includes(value)) {
                    expressionOutput.innerHTML += ` ${value} `;
                }
                else if (value == '.') {
                    expressionOutput.innerHTML += '.';
                }
                else if (value === '=') {
                    let exspression = expressionOutput.innerHTML.split(' ').filter(x => x !== '');

                    if (exspression.length == 3 && !isNaN(exspression[exspression.length - 1])) {
                        resultOutput.innerHTML = eval(expressionOutput.innerHTML);
                    }
                    else {
                        resultOutput.innerHTML = 'NaN';
                    }
                }
                else if (value === 'Clear') {
                    expressionOutput.innerHTML = '';
                    resultOutput.innerHTML = '';
                }
            }
            else {
                expressionOutput.innerHTML += value;
            }
        });
    });
}