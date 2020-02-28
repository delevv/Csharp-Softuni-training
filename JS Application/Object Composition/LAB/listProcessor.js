function solve(arr) {
    function getCommands() {
        let collection = [];

        function add(string) {
            collection.push(string);
        }
        function remove(string) {
            collection = collection.filter(w => w !== string);
        }
        function print() {
            console.log(collection.join(','));
        }
        return {
            add,
            remove,
            print
        }
    }

    let commands = getCommands();

    arr.forEach((e) => {
        let [command, value] = e.split(' ');
        commands[command](value);
    });
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);