function focus() {
    let divs = document.getElementsByTagName('div')[0].children;

    Array.from(divs).forEach(div => {
        div.lastElementChild.addEventListener('focus', function (e) {
            let currentDiv = e.target.parentElement;

            for (let i = 0; i < divs.length; i++) {
                divs[i].classList.remove('focused');
            }

            currentDiv.classList.add('focused');
        });
    });
}