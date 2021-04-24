import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/domain/product';
import { ProductService } from 'src/app/service/product.service';

@Component({
  selector: 'app-product-save',
  templateUrl: './product-save.component.html',
  styleUrls: ['./product-save.component.css']
})
export class ProductSaveComponent implements OnInit {
  public product!: Product;
  public showMsg: boolean = false;
  public msg: string = "";
  public type: string = "";

  constructor(public productService: ProductService,
    private router: Router) { }

  ngOnInit(): void {
    this.product = new Product(0, "", "", "");
  }

  public save() {
    this.productService.save(this.product).subscribe(
      data => {
        this.router.navigate(['/product/list']); 
      },
      error => {
        console.log(error);
        this.showMsg = true;
        this.msg = 'An error  has ocurred in the proccess';
        this.type = 'danger';
      });
  }

}
