function addItem() {
    let items = document.getElementById("items");
    let input = document.getElementById("newItemText");

    let li = document.createElement("li");
    li.textContent = input.value;
    input.value = '';

    items.appendChild(li);
}