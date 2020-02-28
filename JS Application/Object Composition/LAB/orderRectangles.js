function solve(arr) {
    return arr.reduce((acc, curr) => {
        let [width, height] = curr;

        let obj = {
            width,
            height,
            area: function () {
                return Number(width) * Number(height);
            },
            compareTo: function (other) {
                return other.area() - this.area() || other.width - this.width;
            }
        }

        acc.push(obj);
        return acc;
    }, [])
        .sort((a, b) => a.compareTo(b));
}

console.log(solve([[10, 5], [3, 20], [5, 12]]))