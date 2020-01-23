function solve(input) {
    let result = input.reduce((acc, curr) => {
        let args = curr.split(' <-> ');
        let townName = args[0];
        let townPopulation = +args[1];

        if (!acc[townName]) {
            acc[townName] = 0;
        }
        acc[townName] += townPopulation;

        return acc;
    }, {});

    for (let [key, value] of Object.entries(result)) {
        console.log(`${key} : ${value}`);
    }
}

solve(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']
);