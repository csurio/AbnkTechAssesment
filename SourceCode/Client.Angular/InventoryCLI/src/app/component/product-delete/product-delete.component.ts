import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/domain/product';
import { ProductService } from 'src/app/service/product.service';

@Component({
  selector: 'app-product-delete',
  templateUrl: './product-delete.component.html',
  styleUrls: ['./product-delete.component.css']
})
export class ProductDeleteComponent implements OnInit 
{
  public product!: Product;
  public showMsg: boolean = false;
  public msg: string = "";
  public type: string = "";
  public id: number = 0;


  constructor(public productService : ProductService,
              private router : Router,
              private activatedRoute : ActivatedRoute) { }

  ngOnInit(): void {

    this.getById();

  }

  public getById() {
    let param = this.activatedRoute.snapshot.paramMap.get('id');
    this.id = Number(param);

    this.productService.getById(this.id).subscribe(
      data => {
        this.product = data;
      },
      error => {
        this.showMsg = true;
        this.msg = 'An error  has ocurred in get by id';
        this.type = 'danger';
      }
    );
  }

  public delete(){
    this.productService.delete(this.product.id).subscribe(
      data=>{
        this.router.navigate(['/product/list']);
      }, 
      error => {
        this.showMsg = true;
        this.msg = 'An error  has ocurred deleting product';
        this.type = 'danger';     
      }
    );
  }

}
