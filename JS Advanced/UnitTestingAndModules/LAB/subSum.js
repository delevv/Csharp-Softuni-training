function solve(array, startIndex, endIndex) {
    if (!Array.isArray(array) || !array.every(num => typeof (num) === "number")) {
        return NaN;
    }
    else if (startIndex < 0) {
        startIndex = 0;
    }
    else if (endIndex > array.length - 1) {
        endIndex = array.length - 1;
    }

    let sum = 0;
    for (let i = startIndex; i <= endIndex; i++) {
        sum += array[i];
    }

    return sum;
}
console.log(solve([],0,0))