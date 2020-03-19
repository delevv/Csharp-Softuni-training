function attachEvents() {
    let addButton = document.querySelector('.add');
    let loadButton = document.querySelector('.load');
    let catches = document.getElementById('catches');

    loadButton.addEventListener('click', showAllCatches);
    addButton.addEventListener('click', addCatch);

    function showAllCatches() {
        catches.innerHTML = '';

        fetch('https://fisher-game.firebaseio.com/catches.json')
            .then(r => r.json())
            .then(data => {
                if (data !== null) {
                    Object.entries(data).forEach(([id, info]) => {
                        showSingleCatch(id, info);
                    });
                }
            });
    }

    function showSingleCatch(id, info) {
        let catchDiv = document.createElement('div');
        catchDiv.classList.add('catch');
        catchDiv.setAttribute('data-id', id);

        catchDiv.innerHTML = '<label>Angler</label>' +
            `<input type="text" class="angler" value="${info.angler}" />` +
            '<hr>' +
            '<label>Weight</label>' +
            `<input type="number" class="weight" value="${Number(info.weight)}" />` +
            '<hr>' +
            '<label>Species</label>' +
            `<input type="text" class="species" value="${info.species}" />` +
            '<hr>' +
            '<label>Location</label>' +
            `<input type="text" class="location" value="${info.location}" />` +
            '<hr>' +
            '<label>Bait</label>' +
            `<input type="text" class="bait" value="${info.bait}" />` +
            '<hr>' +
            '<label>Capture Time</label>' +
            `<input type="number" class="captureTime" value="${Number(info.captureTime)}" />` +
            '<hr>' +
            '<button class="update">Update</button>' +
            '<button class="delete">Delete</button>';

        let catchButtons = catchDiv.querySelectorAll('button');

        catchButtons[0].addEventListener('click', updateCatch);
        catchButtons[1].addEventListener('click', deleteCatch);

        catches.appendChild(catchDiv);
    }

    function addCatch() {
        let addForm = this.parentElement;

        fetch('https://fisher-game.firebaseio.com/catches.json', {
            method: 'POST',
            body: JSON.stringify(getCatchInfo(addForm))
        });

        Array.from(addForm.children)
            .filter(e => e.tagName === 'INPUT')
            .forEach(e => e.value = '');
    }

    function updateCatch() {
        let catchDiv = this.parentElement;
        let catchId = catchDiv.getAttribute("data-id");

        fetch(`https://fisher-game.firebaseio.com/catches/${catchId}.json`, {
            method: 'PUT',
            body: JSON.stringify(getCatchInfo(catchDiv))
        });
    }

    function deleteCatch() {
        let catchDiv = this.parentElement;
        let catchId = catchDiv.getAttribute("data-id");

        fetch(`https://fisher-game.firebaseio.com/catches/${catchId}.json`, {
            method: 'DELETE'
        });

        catchDiv.remove();
    }

    function getCatchInfo(element) {
        let catchValues = {};

        Array.from(element.children)
            .filter(e => e.tagName === 'INPUT')
            .forEach(e => catchValues[e.className] = e.value);

        return catchValues;
    }
}

attachEvents();