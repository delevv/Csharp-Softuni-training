function solve(input) {
    let products = input.reduce((acc, curr) => {
        let [town, product, price] = curr.split(' | ');

        if (!acc[product]) {
            acc[product] = {};
        }
        if (!acc[product][town]) {
            acc[product][town] = 0;
        }
        acc[product][town] = +price;

        return acc;
    }, {});

    for (let [product, townsAndPrices] of Object.entries(products)) {
        let lowestPrice = Number.POSITIVE_INFINITY;
        let townWithLowestPrice = "";

        for (let [town, price] of Object.entries(townsAndPrices)) {
            if (price < lowestPrice) {
                lowestPrice = price;
                townWithLowestPrice = town;
            }
        }
        console.log(`${product} -> ${lowestPrice} (${townWithLowestPrice})`);
    }
}
solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
);