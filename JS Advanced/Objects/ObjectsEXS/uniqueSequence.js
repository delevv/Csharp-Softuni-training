function solve(input) {
    let set = new Set();

    for (let line of input) {
        let arr = JSON.parse(line);
        arr.sort((a, b) => b - a);
        set.add(JSON.stringify(arr));
    }
    Array.from(set)
        .map(x => JSON.parse(x))
        .sort((a, b) => a.length - b.length)
        .forEach(x => console.log(`[${x.join(', ')}]`));
}

solve(["[-3, -2, -1, 0, 1, 2, 3, 4]",
    "[10, 1, -17, 0, 2, 13]",
    "[4, -3, 3, -2, 2, -1, 1, 0]"]
);