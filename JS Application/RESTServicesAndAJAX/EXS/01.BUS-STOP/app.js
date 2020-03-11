function getInfo() {
    let inputId = document.getElementById('stopId');
    let stopName = document.getElementById('stopName');
    let buses = document.getElementById('buses');

    stopName.textContent = '';
    buses.innerHTML = '';

    fetch(`https://judgetests.firebaseio.com/businfo/${inputId.value}.json`)
        .then(r => r.json())
        .then(succesInputHandler)
        .catch(() => stopName.textContent = 'Error!');

    function succesInputHandler(object) {
        stopName.textContent = object.name;

        Object.entries(object.buses).forEach(([bus, time]) => {
            buses.innerHTML += `<li>Bus ${bus} arrives in ${time} minutes</li>`;
        });
    }
}