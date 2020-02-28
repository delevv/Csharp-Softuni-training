function solve() {
    let selector1;
    let selector2;
    let resultSelector;

    return {
        init: function (selector1, selector2, resultSelector) {
            this.first = document.querySelector(selector1);
            this.second = document.querySelector(selector2);
            this.result = document.querySelector(resultSelector);
        },
        add: function () {
            this.result.value = +this.first.value + +this.second.value;
        },
        subtract: function () {
            this.result.value = +this.first.value - +this.second.value;
        }
    };
}