function solve(matrix) {

    function isInside(matrix, row, col) {

        return row >= 0 && row < matrix.length &&
            col >= 0 && col < matrix[row].length;
    }

    function AreEqual(firstElement, secondElement) {
        if (firstElement === secondElement) {
            return 1;
        } else {
            return 0;
        }
    }

    let equalPairsCount = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            let currentElement = matrix[row][col];

            if (isInside(matrix, row + 1, col)) {
                equalPairsCount += AreEqual(currentElement, matrix[row + 1][col]);
            }
            if (isInside(matrix, row, col + 1)) {
                equalPairsCount += AreEqual(currentElement, matrix[row][col + 1]);
            }
        }
    }

    return equalPairsCount;
}

console.log(solve([[2, 2, 5, 7, 4],
[4, 0, 5, 3, 4],
[2, 5, 5, 4, 2]]));