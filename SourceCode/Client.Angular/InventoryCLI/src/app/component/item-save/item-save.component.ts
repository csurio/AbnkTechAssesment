import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Item } from 'src/app/domain/item';
import { ItemDTO } from 'src/app/DTOs/item-dto';
import { ItemService } from 'src/app/service/item.service';

@Component({
  selector: 'app-item-save',
  templateUrl: './item-save.component.html',
  styleUrls: ['./item-save.component.css']
})
export class ItemSaveComponent implements OnInit {

  public item!: Item;
  public itemDto! : ItemDTO;
  public showMsg: boolean = false;
  public msg: string = "";
  public type: string = "";

  constructor(public service: ItemService,
    private router: Router) { }

  ngOnInit(): void {
    this.item = new Item(0, 0.00, 0);
    this.itemDto = new ItemDTO(0,0,0,0);
  }

  public mapItem()
  {
    this.itemDto.id = this.item.id;
    this.itemDto.productId = this.item.product.id;
    this.itemDto.quantity = this.item.quantity;
    this.itemDto.price = this.item.price;
  }

  public save() 
  {
    this.mapItem();
    this.service.save(this.itemDto).subscribe(
      data => {
        this.router.navigate(['/item/list']); 
      },
      error => {
        this.showMsg = true;
        this.msg = 'An error  has ocurred in the proccess';
        this.type = 'danger';
      }
    );
  }

}
