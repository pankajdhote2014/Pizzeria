export class Order {
    id: number;
    pizzaId: number;
    orderStatus: string;

    constructor(order) {
        {
            this.id = order.id;
            this.pizzaId = order.pizzaId;
            this.orderStatus = order.orderStatus || '';
        }
    }
}