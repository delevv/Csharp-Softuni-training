function solve(array) {
    let number = 1;
    let result = [];

    for (let i = 0; i < array.length; i++) {

        if (array[i] === 'add') {
            result.push(number++);
        }
        else {
            result.pop();
            number++;
        }
    }

    console.log(result.length > 0 ? result.join('\n') : 'Empty');
}

solve(['add',
    'add',
    'remove',
    'add',
    'add']
);