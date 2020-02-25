function solve() {
    let dropdownButton = document.getElementById('dropdown');
    let dropdownList = document.getElementById('dropdown-ul');
    let box = document.getElementById('box');

    dropdownButton.addEventListener('click', () => {
        if (dropdownList.style.display === 'none' || dropdownList.style.display === '') {
            dropdownList.style.display = 'block';

            Array.from(dropdownList.children).forEach(li => {
                li.addEventListener('click', () => {
                    box.style.backgroundColor = li.textContent;
                    box.style.color = "black";
                });
            });
        }
        else {
            dropdownList.style.display = "none";
            box.style.backgroundColor = "black";
            box.style.color = "white";
        }
    });
}