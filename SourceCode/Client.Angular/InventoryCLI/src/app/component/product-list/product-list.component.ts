import { Component, OnInit, OnDestroy } from '@angular/core';
import { Product } from 'src/app/domain/product';
import { ProductService } from 'src/app/service/product.service';
import { Subscription } from 'rxjs'

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit, OnDestroy 
{
  public products : Product[] = [];
  public subProducts: Subscription = new Subscription;

  constructor( public productService: ProductService) { }

  ngOnDestroy(): void {
    this.subProducts.unsubscribe();
  }

  ngOnInit(): void 
  {
    this.getAll();
    console.log(this.products);
  }

  getAll(){
    this.subProducts = this.productService.getAll().subscribe(data => {
      this.products = data;
      
    });
  }

}
