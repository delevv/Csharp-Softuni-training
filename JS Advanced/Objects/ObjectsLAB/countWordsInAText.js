function solve(input) {
    let result = input[0].match(/\w+/g);

    result = result.reduce((acc, curr) => {

        if (!acc[curr]) {
            acc[curr] = 0;
        }
        acc[curr]++;

        return acc;
    }, {});

    return JSON.stringify(result);
}

console.log(solve(['Far too slow, you\'re far too slow.']));