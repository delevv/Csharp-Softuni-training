(() => {
    const townsInput = document.getElementById('towns');
    const loadBtn = document.getElementById('btnLoadTowns');
    const rootDiv = document.getElementById('root');

    loadBtn.addEventListener('click', loadTowns);

    async function loadTowns() {
        if (townsInput.value !== '') {
            const towns = townsInput.value.split(', ');

            let townsTemplate = await fetch('./townsTemplate.hbs').then((r) => r.text());
            let template = Handlebars.compile(townsTemplate);

            let listOfTowns = template({ towns });

            rootDiv.innerHTML = listOfTowns;
            townsInput.value = '';
        }
    }
})();