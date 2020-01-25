function solve(name, age, weight, heightInCm) {
    let person = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: heightInCm
        }
    };

    let bmi = Math.round(weight / (heightInCm / 100) ** 2);
    person.BMI = bmi;

    let status = '';

    if (bmi < 18.5) {
        status = 'underweight';
    }
    else if (bmi < 25) {
        status = 'normal';
    }
    else if (bmi < 30) {
        status = 'overweight';
    }
    else {
        status = 'obese';
        person.recommendation = 'admission required';
    }
    person.status = status;

    return person;
}

console.log(solve('Peter', 29, 75, 182));