function solve(arr1, arr2, arr3) {
    let sumLenght;
    let averageLenght;

    let firstArrgument = arr1.length;
    let secondArgument = arr2.length;
    let thirdArgument = arr3.length

    sumLenght = firstArrgument + secondArgument + thirdArgument;
    averageLenght = Math.floor(sumLenght / 3);

    console.log(sumLenght);
    console.log(averageLenght);
}

solve('chocolate', 'ice cream', 'cake');