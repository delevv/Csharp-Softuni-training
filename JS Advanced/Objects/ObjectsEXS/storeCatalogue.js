function solve(input) {
    let startLetter = '';
    let catalogue = input
        .map(x => x.replace(' : ', ': '))
        .sort()
        .forEach(element => {
            if (element[0] !== startLetter) {
                startLetter = element[0].toUpperCase();
                console.log(startLetter);
            }
            console.log(`  ${element}`);
        });
}

solve(['Banana : 2',
    'Rubic\'s Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']
);