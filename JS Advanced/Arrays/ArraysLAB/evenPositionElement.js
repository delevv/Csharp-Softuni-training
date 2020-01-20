function solve(elements) {
    let evenIndexElements = elements.filter((x, i) => i % 2 == 0);
    return evenIndexElements.join(' ');
}

console.log(solve(['20', '30', '40']));