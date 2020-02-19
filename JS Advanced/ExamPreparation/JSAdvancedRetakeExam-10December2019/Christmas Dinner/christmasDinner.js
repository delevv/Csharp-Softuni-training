class ChristmasDinner {
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    get budget() {
        return this._budget;
    }
    set budget(value) {
        if (Number(value) < 0) {
            throw new Error("The budget cannot be a negative number");
        }
        this._budget = value;
    }

    shopping(product) {
        let type = product[0];
        let price = Number(product[1]);

        if (this.budget < price) {
            throw new Error("Not enough money to buy this product");
        }

        this.products.push(type);
        this.budget -= price;

        return `You have successfully bought ${type}!`;
    }

    recipes(recipe) {
        recipe.productsList.forEach(p => {
            if (!this.products.includes(p)) {
                throw new Error("We do not have this product");
            }
        });

        this.dishes.push(recipe);

        return `${recipe.recipeName} has been successfully cooked!`
    }

    inviteGuests(name, dish) {
        let currDish = this.dishes.find(d => d.recipeName === dish);

        if (!currDish) {
            throw new Error("We do not have this dish");
        }

        if (Object.keys(this.guests).includes(name)) {
            throw new Error("This guest has already been invited");
        }

        this.guests[name] = dish;

        return `You have successfully invited ${name}!`;
    }

    showAttendance() {
        let result = '';

        Object.entries(this.guests).forEach(([name, dish]) => {
            let recipe = this.dishes.find(r => r.recipeName === dish);
            result += `${name} will eat ${dish}, which consists of ${recipe.productsList.join(', ')}\n`;
        });

        return result.trim();
    }
}