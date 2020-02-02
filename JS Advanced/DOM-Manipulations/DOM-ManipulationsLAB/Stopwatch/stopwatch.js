function stopwatch() {
    let start = document.getElementById('startBtn');
    let stop = document.getElementById('stopBtn');
    let result = document.getElementById('time');

    let timer = null;

    start.addEventListener('click', () => {
        start.disabled = true;
        stop.disabled = false;

        let currSeconds = 0;

        timer = setInterval(addSecond, 1000);

        result.textContent = '00:00';

        function addSecond() {
            currSeconds++;

            let minutes = ('0' + Math.floor(currSeconds / 60)).slice(-2);
            let seconds = ('0' + currSeconds % 60).slice(-2);

            result.textContent = `${minutes}:${seconds}`;
        }
    });

    stop.addEventListener('click', () => {
        stop.disabled = true;
        start.disabled = false;

        clearInterval(timer);
    });
}