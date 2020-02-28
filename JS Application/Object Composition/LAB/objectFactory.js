function solve(string) {
    return JSON.parse(string)
        .reduce((acc, curr) => {
            return Object.assign(acc, curr);
        }, {});
}

console.log(solve(`[{"canFly": true},{"canMove":true, "doors": 4},{"capacity": 255},{"canFly":true, "canLand": true}]`));