function solve(num1, num2) {
    
    while (num2 !== 0) {
        [num1, num2] = [num2, num1 % num2];
    }

    console.log(num1);
}

solve(2154, 458);