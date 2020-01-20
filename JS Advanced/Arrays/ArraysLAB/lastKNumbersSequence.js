function solve(n, k) {
    let result = [1];

    for (let i = 1; i < n; i++) {
        let currentSum = 0;
        let currentIndex = i - 1;

        for (let j = 1; j <= k; j++) {

            if (currentIndex >= 0) {
                currentSum += result[currentIndex--];
            } else {
                break;
            }

        }
        result[i] = currentSum;
    }
    return result.join(' ');
}

console.log(solve(8, 2));