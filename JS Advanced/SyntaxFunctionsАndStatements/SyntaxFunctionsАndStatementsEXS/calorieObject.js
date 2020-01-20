function solve(params) {

    let calorie = {};

    for (let i = 0; i < params.length; i += 2) {
        calorie[params[i]] = +params[i + 1];
    }

    console.log(calorie);
}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);