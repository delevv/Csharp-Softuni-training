function getFibonator() {
    let previous = 0;
    let current = 1;

    return function () {
        let result = current;

        [current, previous] = [previous + current, current];

        return result;
    }
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3