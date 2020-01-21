function solve(matrix) {
    let isMagic = true;

    let firstRowSum = matrix[0].reduce((a, b) => a + b, 0);
    let colsSum = [];

    for (let row = 0; row < matrix.length; row++) {
        let currentRowSum = matrix[row].reduce((a, b) => a + b, 0);

        if (currentRowSum != firstRowSum) {
            isMagic = false;
            break;
        }

        for (let col = 0; col < matrix[row].length; col++) {

            if (colsSum[col] === undefined) {
                colsSum[col] = 0;
            }
            colsSum[col] += matrix[row][col];
        }
    }

    if (isMagic === false) {
        return false;
    }

    for (let col = 0; col < colsSum.length; col++) {
        if (firstRowSum !== colsSum[col]) {
            isMagic = false;
        }

    }

    return isMagic;
}

console.log(solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
));