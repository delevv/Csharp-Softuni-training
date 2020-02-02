function solve() {
    let tableRows = document.getElementsByTagName("tbody")[0].children;
    let buttons = document.querySelector("#exercise > table > tfoot > tr > td");
    let table = document.querySelector("#exercise > table");
    let check = document.querySelector("#check > p");

    const sudomuMaxNumber = 3;

    buttons.addEventListener('click', function (e) {
        if (e.target.innerHTML === 'Quick Check') {
            let numbersMatrix = [];
            let isSudomu = true;

            for (let row = 0; row < tableRows.length; row++) {
                numbersMatrix[row] = [];
                for (let col = 0; col < tableRows[row].children.length; col++) {
                    let currNumber = tableRows[row].children[col].children[0].value;

                    if (Number(currNumber) > sudomuMaxNumber || Number(currNumber) < 1) {
                        isSudomu = false;
                        sudomuCheck(isSudomu);
                        return;
                    }
                    numbersMatrix[row].push(currNumber);
                }
            }

            for (let row = 0; row < numbersMatrix.length; row++) {
                let currentRow = numbersMatrix[row];
                isSudomu = chekArray(currentRow);

                if (!isSudomu) {
                    sudomuCheck(isSudomu);
                    return;
                }
            }

            for (let col = 0; col < numbersMatrix[0].length; col++) {
                let currentCol = [];
                for (let row = 0; row < numbersMatrix.length; row++) {
                    currentCol.push(numbersMatrix[row][col]);
                }

                isSudomu = chekArray(currentCol);

                if (!isSudomu) {
                    break;
                }
            }
            sudomuCheck(isSudomu);

            function chekArray(array) {
                return (new Set(array).size) === array.length;
            }

            function sudomuCheck(isSudomu) {
                if (isSudomu) {
                    table.style.border = "2px solid green";
                    check.textContent = "You solve it! Congratulations!";
                    check.parentElement.style.color = "green";
                }
                else {
                    table.style.border = "2px solid red";
                    check.textContent = "NOP! You are not done yet...";
                    check.parentElement.style.color = "red";
                }
            }
        }
        else if (e.target.innerHTML === 'Clear') {
            table.style.border = "none";
            check.textContent = "";

            Array.from(document.getElementsByTagName("input")).forEach(e => e.value = '');
        }
    })
}