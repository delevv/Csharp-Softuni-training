function solve(info) {

    let speed = info[0];
    let type = info[1];

    let limitSpeed = 0;

    switch (type) {

        case 'city': limitSpeed = 50; break;
        case 'motorway': limitSpeed = 130; break;
        case 'interstate': limitSpeed = 90; break;
        case 'residential': limitSpeed = 20; break;
    }

    let overLimit = speed - limitSpeed;

    if (overLimit <= 0) {
        console.log();
        return;
    }

    if (overLimit <= 20) {
        console.log('speeding');
    } else if (overLimit <= 40) {
        console.log('excessive speeding')
    } else {
        console.log('reckless driving');
    }

}

solve([21, 'residential']);