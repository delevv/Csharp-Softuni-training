function solve(input) {
    let register = input.reduce((acc, curr) => {
        let args = curr.split(' / ');
        let [heroName, level] = args;

        acc.push({
            name: heroName,
            level: +level,
            items: args.length > 2 ? args[2].split(', ') : []
        });

        return acc;
    }, []);

    console.log(JSON.stringify(register));
}

solve(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
);