function attachGradientEvents() {
    let result = document.getElementById('result');
    let box = document.getElementById('gradient');

    box.addEventListener('mousemove', function (e) {
        result.textContent = Math.floor(e.offsetX / e.target.clientWidth * 100) + '%';
    });
    box.addEventListener('mouseout', () => {
        result.textContent = '';
    });
}