function solve(numbers, sortOrder) {
    numbers = numbers.sort((a, b) => a - b);

    if (sortOrder === 'asc') {
        return numbers;
    }
    else {
        return numbers.reverse();
    }
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));