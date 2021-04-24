import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Item } from 'src/app/domain/item';
import { ItemDTO } from 'src/app/DTOs/item-dto';
import { ItemService } from 'src/app/service/item.service';

@Component({
  selector: 'app-item-edit',
  templateUrl: './item-edit.component.html',
  styleUrls: ['./item-edit.component.css']
})
export class ItemEditComponent implements OnInit {

  public item!: Item;
  public itemDto! : ItemDTO;
  public showMsg: boolean = false;
  public msg: string = "";
  public type: string = "";
  public id: number = 0;

  constructor(public service: ItemService,
              private router: Router,
              private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.getById();
    this.itemDto = new ItemDTO(0,0,0,0);
  }

  public mapItem()
  {
    this.itemDto.id = this.item.id;
    this.itemDto.productId = this.item.product.id;
    this.itemDto.quantity = this.item.quantity;
    this.itemDto.price = this.item.price;
  }

  public getById() {
    let param = this.activatedRoute.snapshot.paramMap.get('id');
    this.id = Number(param);

    this.service.getById(this.id).subscribe(
      data => {
        this.item = data;
      },
      error => {
        this.showMsg = true;
        this.msg = 'An error  has ocurred in get by id';
        this.type = 'danger';
      }
    );
  }

  public edit() {
    this.mapItem();
    console.log(this.itemDto);
    this.service.edit(this.itemDto).subscribe(
      data => {
        this.router.navigate(['/item/list']);
      },
      error => {
        this.showMsg = true;
        this.msg = 'An error  has ocurred updating product';
        this.type = 'danger';
      }
    );
}

}
