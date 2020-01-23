function solve(input) {
    let towns = input.reduce((acc, curr) => {
        let [town, product, quantityPrice] = curr.split(' -> ');
        let [quantity, price] = quantityPrice.split(' : ');

        if (!acc[town]) {
            acc[town] = {};
        }
        if (!acc[town][product]) {
            acc[town][product] = 0;
        }
        acc[town][product] += +quantity * +price;

        return acc;
    }, {});

    for (let [town, products] of Object.entries(towns)) {
        console.log(`Town - ${town}`);
        for (let [product, income] of Object.entries(products)) {
            console.log(`$$$${product} : ${income}`);
        }
    }
}

console.log(solve(['Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Raspberry -> 200000 : 1500',
    'Sofia -> Audi Q7 -> 200 : 100000',
    'Montana -> Portokals -> 200000 : 1',
    'Montana -> Qgodas -> 20000 : 0.2',
    'Montana -> Chereshas -> 1000 : 0.3']
));