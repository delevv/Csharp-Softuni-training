function solve(matrix) {
    let firstDiagonalSum = 0;
    let row = 0;
    let col = 0;

    while (row < matrix.length && col < matrix[row].length) {
        firstDiagonalSum += matrix[row++][col++];
    }

    let secondDiagonalSum = 0;
    row = 0;
    col = matrix[row].length - 1;

    while (row < matrix.length && col >= 0) {
        secondDiagonalSum += matrix[row++][col--];
    }

    return firstDiagonalSum + ' ' + secondDiagonalSum;
}

console.log(solve([[3, 5, 17],
[-1, 7, 14],
[1, -8, 89]]));
