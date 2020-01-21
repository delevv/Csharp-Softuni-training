function solve(array) {
    let biggestNum = Number.MIN_SAFE_INTEGER;

    let result = array.reduce((acc, curr) => {
        if (curr >= biggestNum) {
            biggestNum = curr;
            acc.push(curr);
        }
        return acc;
    }, []);

    console.log(result.join('\n'));
}

solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
);