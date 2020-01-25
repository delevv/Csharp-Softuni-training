function solve(input) {
    let systems = input.reduce((acc, curr) => {
        let [name, component, subComponent] = curr.split(' | ');

        if (!acc[name]) {
            acc[name] = {};
        }
        if (!acc[name][component]) {
            acc[name][component] = [];
        }
        acc[name][component].push(subComponent);

        return acc;
    }, {});

    for (let [systemName, systemComponents] of Object.entries(systems).sort(compareSystems)) {
        console.log(systemName);

        for (let [componentName, subComponents] of Object.entries(systemComponents).sort(compareComponents)) {
            console.log(`|||${componentName}`);

            systems[systemName][componentName].forEach(subComponent => {
                console.log(`||||||${subComponent}`);
            });
        }

    }

    function compareSystems(first, second) {
        if (Object.keys(second[1]).length - Object.keys(first[1]).length) {
            return Object.keys(second[1]).length - Object.keys(first[1]).length;
        }
        else {
            return first[0].localeCompare(second[0]);
        }
    }
    function compareComponents(first, second) {
        return Object.keys(second[1]).length - Object.keys(first[1]).length;
    }

}

solve(['SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security']
);