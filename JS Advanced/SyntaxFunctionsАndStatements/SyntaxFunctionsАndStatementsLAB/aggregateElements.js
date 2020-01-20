function solve(arr) {
    let arraySum = 0;
    let arrayInverseSum = 0;
    let arrayAsString = '';

    for (let i = 0; i < arr.length; i++) {
        arraySum += arr[i];
        arrayInverseSum += 1 / arr[i];
        arrayAsString += arr[i].toString();
    }

    console.log(arraySum);
    console.log(arrayInverseSum);
    console.log(arrayAsString);
}

solve([1, 2, 3]);
solve([2, 4, 8, 16]);