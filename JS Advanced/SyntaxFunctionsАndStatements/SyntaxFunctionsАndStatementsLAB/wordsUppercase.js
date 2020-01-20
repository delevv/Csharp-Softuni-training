function solve(text) {
    let regex = /\w+/g;

    let matches = text.matchAll(regex);

    matches = Array.from(matches);

    console.log(matches.join(', ').toUpperCase());
}

solve('Hi, how are you?');