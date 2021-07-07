export class Pizza {
    id: number;
    totalCost: number;
    pizzaTypeId: number;
    Ingredients: string;

    constructor(pizza) {
        {
            this.id = pizza.id;
            this.totalCost = pizza.totalCost || '';
            this.pizzaTypeId = pizza.pizzaTypeId;
            this.Ingredients = pizza.Ingredients || '';
        }
    }
}