function solve(numbers) {
    var resultNumbers = numbers.sort((a, b) => a - b).slice(0, 2);

    return resultNumbers.join(' ');
}

console.log(solve([30, 15, 50, 5]));