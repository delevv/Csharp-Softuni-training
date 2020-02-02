function deleteByEmail() {
    let searchedEmail = document.getElementsByTagName("input")[0].value;
    let tableRows = document.getElementsByTagName("tbody")[0].children;
    let result = document.getElementById("result");

    let isFound = false;

    Array.from(tableRows).forEach(e => {
        if (e.children[1].textContent === searchedEmail) {
            e.remove();
            isFound = true;
        }
    });

    if (isFound) {
        result.textContent = "Deleted.";
    }
    else {
        result.textContent = "Not found.";
    }
}