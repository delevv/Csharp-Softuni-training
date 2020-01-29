function solve() {
    let selectMenu = document.getElementById("selectMenuTo");

    let binaryOption = document.createElement("option");
    binaryOption.innerText = "Binary";
    binaryOption.value = "binary";

    let hexadeicmalOption = document.createElement("option");
    hexadeicmalOption.innerText = "Hexadeicmal";
    hexadeicmalOption.value = "hexadecimal";

    selectMenu.appendChild(binaryOption);
    selectMenu.appendChild(hexadeicmalOption);

    document.getElementsByTagName("button")[0].addEventListener("click", () => {
        let number = +document.getElementById("input").value;
        let resultBox = document.getElementById("result");

        if (selectMenu.value === "binary") {
            resultBox.value = number.toString(2);
        }
        else if (selectMenu.value === "hexadecimal") {
            resultBox.value = number.toString(16).toUpperCase();
        }
    });
}