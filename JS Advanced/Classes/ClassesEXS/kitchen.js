class Kitchen {
    constructor(budget) {
        this.budget = +budget;
        this.menu = {};
        this.productsInStock = {};
        this.actionsHistory = [];
    }

    loadProducts(products) {
        products.forEach(p => {
            let [name, quantity, totalPrice] = p.split(' ');

            if (+totalPrice <= this.budget) {
                this.budget -= +totalPrice;
                if (!this.productsInStock[name]) {
                    this.productsInStock[name] = 0;
                }
                this.productsInStock[name] += +quantity;
                this.actionsHistory.push(`Successfully loaded ${quantity} ${name}`);
            }
            else {
                this.actionsHistory.push(`There was not enough money to load ${quantity} ${name}`);
            }
        });
        return this.actionsHistory.join("\n");
    }

    addToMenu(mealName, products, price) {
        if (!this.menu[mealName]) {
            this.menu[mealName] = { price, products: products }

            return `Great idea! Now with the ${mealName} we have ${Object.keys(this.menu).length} meals on the menu, other ideas?`;
        }
        else {
            return `The ${mealName} is already in our menu, try something different.`;
        }
    }

    showTheMenu() {
        let menuKVP = Object.entries(this.menu);

        if (menuKVP.length !== 0) {
            return menuKVP.map(i => `${i[0]} - $ ${i[1].price}`).join('\n') + '\n';
        }
        else {
            return "Our menu is not ready yet, please come later...";
        }
    }

    makeTheOrder(mealName) {
        let currentMeal = this.menu[mealName];
        if (currentMeal) {
            let neededProducts = this.menu[mealName].products;

            for (const product of neededProducts) {
                let [name, quantity] = product.split(' ');
                if (!this.productsInStock[name] || this.productsInStock[name] < +quantity) {
                    return `For the time being, we cannot complete your order (${mealName}), we are very sorry...`;
                }
            }
            for (const product of neededProducts) {
                let [name, quantity] = product.split(' ');
                this.productsInStock[name] -= +quantity;
            }
            this.budget += +currentMeal.price;
            return `Your order (${mealName}) will be completed in the next 30 minutes and will cost you ${currentMeal.price}.`;
        }
        else {
            return `There is not ${mealName} yet in our menu, do you want to order something else?`;
        }
    }
}