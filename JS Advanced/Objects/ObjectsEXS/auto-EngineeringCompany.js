function solve(input) {
    let register = input.reduce((acc, curr) => {
        let [carName, carModel, carQuantity] = curr.split(' | ');

        if (!acc[carName]) {
            acc[carName] = {};
        }
        if (!acc[carName][carModel]) {
            acc[carName][carModel] = 0;
        }
        acc[carName][carModel] += +carQuantity;

        return acc;
    }, {});

    for (let [carName, models] of Object.entries(register)) {
        console.log(carName);

        for (let [model, quantity] of Object.entries(models)) {
            console.log(`###${model} -> ${quantity}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
);