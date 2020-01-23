function solve(input) {
    let juiceStore = input.reduce((acc, curr) => {
        let [name, quantity] = curr.split(' => ');

        if (!acc.prepared[name]) {
            acc.prepared[name] = 0;
        }
        acc.prepared[name] += +quantity;

        if (acc.prepared[name] >= 1000) {
            if (!acc.completed[name]) {
                acc.completed[name] = 0;
            }
            acc.completed[name] += Math.floor(acc.prepared[name] / 1000);
            acc.prepared[name] %= 1000;
        }

        return acc;
    }, { completed: {}, prepared: {} });

    for (let [name, quantity] of Object.entries(juiceStore.completed)) {
        console.log(`${name} => ${quantity}`);
    }
}

solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
);