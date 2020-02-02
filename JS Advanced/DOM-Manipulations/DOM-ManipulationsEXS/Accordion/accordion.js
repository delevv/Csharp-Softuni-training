function toggle() {
    let wholeElement = document.getElementById("accordion");
    let button = wholeElement.getElementsByTagName("span")[0];
    let extraContent = wholeElement.children[1];

    if (button.textContent === 'More') {
        button.textContent = 'Less';
        extraContent.style.display = 'block';
    }
    else {
        button.textContent = 'More';
        extraContent.style.display = 'none';
    }
}