(() => {
    renderCatTemplate();

    async function renderCatTemplate() {
        const singleCatTemplate = await fetch('./singleCatTemplate.hbs').then((r) => r.text());
        Handlebars.registerPartial('cat', singleCatTemplate);

        const catsListTemplate = await fetch('./catsListTemplate.hbs').then((r) => r.text());
        const template = Handlebars.compile(catsListTemplate);

        const listOfCats = template({ cats });

        document.querySelector('#allCats').innerHTML = listOfCats;

        document.querySelectorAll('button').forEach(btn => {

            btn.addEventListener('click', (e) => {
                const catInfoDiv = e.target.parentElement;
                const statusDiv = catInfoDiv.querySelector('div.status');

                if (statusDiv.style.display === 'none') {
                    statusDiv.style.display = 'block';
                    btn.textContent = 'Hide status code';
                }
                else {
                    statusDiv.style.display = 'none';
                    btn.textContent = 'Show status code';
                }
            });
        });
    }
})();
