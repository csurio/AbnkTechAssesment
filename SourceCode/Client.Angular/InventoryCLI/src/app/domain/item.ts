import { Product } from "./product";

export class Item 
{
    constructor(
        public id: number,
        public price: number,
        public quantity: number,
        public product: Product = new Product(0, "", "", "")
        ) { }
}
