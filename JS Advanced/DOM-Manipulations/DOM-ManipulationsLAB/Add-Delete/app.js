function addItem() {
    const items = document.getElementById("items");
    const input = document.getElementById("newText");

    let li = document.createElement("li");
    li.textContent = input.value;

    let link = document.createElement("a");
    link.textContent = "[Delete]";
    link.href = "#";

    link.addEventListener("click", function (e) {
        e.target.parentElement.remove();
    })

    li.appendChild(link);
    items.appendChild(li);
    input.value = '';
}