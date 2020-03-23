$(async () => {
    const singleMonkeyTemplate = await fetch('./singleMonkeyTemplate.hbs').then((r) => r.text());
    Handlebars.registerPartial('singleMonkey', singleMonkeyTemplate);

    const monkeysTemplate = await fetch('./monkeysTemplate.hbs').then((r) => r.text());
    const template = Handlebars.compile(monkeysTemplate);

    const monkeysList = template({ monkeys });

    document.querySelector('section').innerHTML = monkeysList;

    document.querySelectorAll('button').forEach(btn => {

        btn.addEventListener('click', (e) => {
            const monkeyDiv = e.target.parentElement;
            const monkeyP = monkeyDiv.querySelector('p');

            const dysplayStyle = monkeyP.style.display === 'none' ? 'block' : 'none';
            monkeyP.style.display = dysplayStyle;
        });
    });
});