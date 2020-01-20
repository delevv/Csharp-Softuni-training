function solve(matrix) {
    let biggestNumber = Number.MIN_SAFE_INTEGER;

    matrix.forEach(array => {
        array.forEach(element => {
            if (element > biggestNumber) {
                biggestNumber = element;
            }
        });
    });

    return biggestNumber;
}

console.log(solve([[20, 50, 10],
[8, 33, 145]]));