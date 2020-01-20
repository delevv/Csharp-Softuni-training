function solve(input) {
    let days = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];

    let result = 0;

    switch (input) {
        case days[0]: result = 1; break;
        case days[1]: result = 2; break;
        case days[2]: result = 3; break;
        case days[3]: result = 4; break;
        case days[4]: result = 5; break;
        case days[5]: result = 6; break;
        case days[6]: result = 7; break;
        default: result = 'error'; break;
    }

    console.log(result);
}

solve('Monday');
solve('invalid');