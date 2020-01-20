function solve(numbers) {

    let numbersAsString = numbers.toString();

    let areEqual = true;
    let sumOfNumbers = 0;
    let firstNumber = numbersAsString[0];

    for (let i = 0; i < numbersAsString.length; i++) {

        if (firstNumber !== numbersAsString[i]) {
            areEqual = false;
        }

        sumOfNumbers += +numbersAsString[i];
    }

    console.log(areEqual);
    console.log(sumOfNumbers);
}

solve(2222222);