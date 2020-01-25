let solve = (function () {
    let result = 0;

    function sum(num) {
        result += num;
        return sum;
    }
    sum.toString = () => result.toString();

    return sum;
})();

console.log(solve(1)(6)(-3).toString());