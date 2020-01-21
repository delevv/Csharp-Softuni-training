function solve(array) {
    let delimiter = array.pop();
    console.log(array.join(delimiter));
}

solve(['One',
    'Two',
    'Three',
    'Four',
    'Five',
    '-']
);