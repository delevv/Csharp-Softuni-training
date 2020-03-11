function solve() {
    let infoSpan = document.getElementsByClassName('info')[0];
    let departButton = document.getElementById('depart');
    let arriveButton = document.getElementById('arrive');

    let nextStopId = 'depot';
    let currStopName = '';

    function depart() {
        fetch(`https://judgetests.firebaseio.com/schedule/${nextStopId}.json`)
            .then(r => r.json())
            .then(r => {
                currStopName = r.name;
                nextStopId = r.next;

                infoSpan.textContent = `Next stop ${currStopName}`;

                departButton.disabled = true;
                arriveButton.disabled = false;
            })
            .catch(() => {
                infoSpan.textContent = 'Error!';
                departButton.disabled = true;
                arriveButton.disabled = true;
            });
    }

    function arrive() {
        infoSpan.textContent = `Arriving at ${currStopName}`;

        departButton.disabled = false;
        arriveButton.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();