function solve(array) {
    let rotations = +array.pop() % array.length;

    for (let i = 0; i < rotations; i++) {
        array.unshift(array.pop());
    }

    console.log(array.join(' '));
}

solve(['Banana',
    'Orange',
    'Coconut',
    'Apple',
    '15']
);