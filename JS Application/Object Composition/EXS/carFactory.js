function solve(order) {
    let engines = [
        { power: 90, volume: 1800 },
        { power: 120, volume: 2400 },
        { power: 200, volume: 3500 }
    ];

    return {
        model: order.model,
        engine: engines.find(e => order.power <= e.power),
        carriage: { type: order.carriage, color: order.color },
        wheels: Array(4).fill(order.wheelsize % 2 === 0 ? order.wheelsize - 1 : order.wheelsize)
    }
}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
));