function solve() {
    let orderedList = document.getElementsByTagName("li");

    document.getElementsByTagName("button")[0].addEventListener("click", () => {
        let input = document.getElementsByTagName("input")[0];

        let firstLetter = input.value[0].toUpperCase();
        let lineNumber = Number(firstLetter.charCodeAt()) - 65;

        let value = firstLetter + input.value.substring(1).toLowerCase();
        let currentRow = orderedList[lineNumber];

        if (!currentRow.innerHTML) {
            currentRow.innerHTML = value;
        }
        else {
            currentRow.innerHTML += ', ' + value;
        }

        input.value = '';
    });
}