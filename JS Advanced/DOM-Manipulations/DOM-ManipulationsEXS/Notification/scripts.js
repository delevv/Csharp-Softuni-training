function notify(message) {
    let targetDiv = document.getElementById("notification");
    targetDiv.textContent = message;

    setTimeout(() => targetDiv.style.display = "none", 2000);
    targetDiv.style.display = "block";
}