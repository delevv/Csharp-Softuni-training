class List {
    numbers = [];
    size = 0;;

    add(number) {
        this.numbers.push(number);
        this.numbers.sort((a, b) => a - b);
        this.size++;
    }

    remove(index) {
        if (this.checkIndex(index)) {
            this.numbers.splice(index, 1);
            this.numbers.sort((a, b) => a - b);
            this.size--;
        }
    }

    get(index) {
        if (this.checkIndex(index)) {
            return this.numbers[index];
        }
    }

    checkIndex(index) {
        return index >= 0 && index < this.numbers.length;
    }
}