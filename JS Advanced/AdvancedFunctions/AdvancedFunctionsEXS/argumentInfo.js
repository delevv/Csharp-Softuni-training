function solve(...args) {
    let types = {};

    args.forEach(e => {
        let currentType = typeof e;
        console.log(`${currentType}: ${e}`)

        if (!types[currentType]) {
            types[currentType] = 0;
        }

        types[currentType]++;
    });

    Object.entries(types)
        .sort((a, b) => b[1] - a[1])
        .forEach(e => console.log(`${e[0]} = ${e[1]}`));
}
solve('cat', 42, function () { console.log('Hello world!'); });