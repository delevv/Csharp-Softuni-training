function solve() {
    let text = '';

    function append(string) {
        text += string;
    }
    function removeStart(n) {
        text = text.substring(n);
    }
    function removeEnd(n) {
        text = text.substring(0, text.length - n);
    }
    function print() {
        console.log(text);
    }

    return {
        append,
        removeEnd,
        removeStart,
        print
    };
}
let secondZeroTest = solve();

secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print();