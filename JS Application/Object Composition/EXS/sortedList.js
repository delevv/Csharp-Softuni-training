function solve() {
    function checkIndex(arr, index) {
        if (index < 0 || index >= arr.length) {
            throw new Error('Invalid index!');
        }
    }

    let sortedList = {
        numbers: [],
        size: 0,
        add: function (number) {
            this.numbers.push(number);
            this.size++;
            this.numbers.sort((a, b) => a - b);
        },
        remove: function (index) {
            checkIndex(this.numbers, index);
            this.numbers.splice(index, 1);
            this.size--;
        },
        get: function (index) {
            checkIndex(this.numbers, index);
            return this.numbers[index];
        }
    }

    return sortedList;
}