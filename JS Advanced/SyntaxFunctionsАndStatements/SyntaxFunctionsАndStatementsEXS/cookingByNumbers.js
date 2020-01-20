function solve(input) {

    let cooking = {
        'chop': (x) => x / 2,
        'dice': (x) => Math.sqrt(x),
        'spice': (x) => x + 1,
        'bake': (x) => x * 3,
        'fillet': (x) => x * 0.8
    };

    let number = +input[0];

    for (let i = 1; i < input.length; i++) {
        number = cooking[input[i]](number);

        console.log(number);
    }
}

solve(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);