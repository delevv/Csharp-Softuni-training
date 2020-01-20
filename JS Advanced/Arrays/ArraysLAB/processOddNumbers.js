function solve(numbers) {
    let result = numbers.filter((x, i) => i % 2 == 1).map(x => x * 2).reverse();
    return result.join(' ');
}

console.log(solve([10, 15, 20, 25]));