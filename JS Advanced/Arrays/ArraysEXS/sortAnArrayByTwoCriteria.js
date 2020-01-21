function solve(array) {

    let sortedArray = array.sort((firstName, SecondName) =>
        firstName.length - SecondName.length ||
        firstName.localeCompare(SecondName));

    console.log(sortedArray.join('\n'));
}

solve(['Isacc',
    'Theodor',
    'Jack',
    'Harrison',
    'George']
);