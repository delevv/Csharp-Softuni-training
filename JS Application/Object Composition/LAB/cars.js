function solve(arr) {
    function getCommands() {
        let objects = {};

        function create(name) {
            objects[name] = {};
        }
        function inherit(name, parentName) {
            objects[name] = Object.create(objects[parentName]);
        }
        function set(name, key, value) {
            objects[name][key] = value;
        }
        function print(name) {
            let result = [];

            Object.entries(objects[name])
                .forEach(([key, value]) => result.push(`${key}:${value}`));

            let obj = Object.getPrototypeOf(objects[name]);
            while (obj != null) {
                Object.entries(obj)
                    .forEach(([key, value]) => result.push(`${key}:${value}`));

                obj = Object.getPrototypeOf(obj);
            }

            console.log(result.join(', '));
        }

        return { create, inherit, set, print };
    }

    let commands = getCommands();

    for (let string of arr) {
        let [firstAction, firstValue, secondAction, secondValue] = string.split(' ');

        if (secondAction === 'inherit') {
            commands[secondAction](firstValue, secondValue);
        }
        else if (secondAction !== undefined) {
            commands[firstAction](firstValue, secondAction, secondValue);
        }
        else {
            commands[firstAction](firstValue);
        }
    }
}

solve(['create pesho',
    'create gosho inherit pesho',
    'create stamat inherit gosho',
    'set pesho rank number1',
    'set gosho nick goshko',
    'print stamat']
);