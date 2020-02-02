function validate() {
    let input = document.getElementById('email');
    let pattern = /[a-z]+@[a-z]+\.[a-z]+/;

    input.addEventListener('change', function (e) {
        if (!pattern.test(e.target.value)) {
            e.target.classList.add('error');
        } else {
            e.target.classList.remove('error');
        }
    });
}