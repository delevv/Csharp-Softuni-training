function solve(input) {
    let result = input.reduce((acc, curr, i, arr) => {
        if (i % 2 == 0) {
            if (acc[curr] === undefined) {
                acc[curr] = 0;
            }
        }
        else {
            acc[arr[i - 1]] += +curr;
        }
        return acc;
    }, {});

    return JSON.stringify(result);
}

console.log(solve(['Sofia',
    '20',
    'Varna',
    '3',
    'sofia',
    '5',
    'varna',
    '4']
));