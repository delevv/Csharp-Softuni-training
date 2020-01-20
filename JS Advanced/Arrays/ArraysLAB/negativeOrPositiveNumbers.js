function solve(numbers) {
    let result = [];

    numbers.forEach(element => {
        if (element < 0) {
            result.unshift(element);
        } else {
            result.push(element);
        }
    });

    return result.join('\n');
}

console.log(solve([3, -2, 0, -1]));