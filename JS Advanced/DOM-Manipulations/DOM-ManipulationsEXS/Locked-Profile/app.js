function lockedProfile() {
    let buttons = document.getElementsByTagName('button');

    Array.from(buttons).forEach(b => b.addEventListener('click', function (e) {
        let buttonText = e.target.textContent;
        let unlock = e.target.parentElement.querySelectorAll("input[type='radio']")[1].checked;

        if (buttonText === 'Show more') {
            if (unlock) {
                e.target.previousElementSibling.style.display = 'block';
                e.target.textContent = 'Hide it';
            }
        }
        else if (buttonText === 'Hide it') {
            if (unlock) {
                e.target.previousElementSibling.style.display = 'none';
                e.target.textContent = 'Show more';
            }
        }
    }));
}