import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Item } from 'src/app/domain/item';
import { ItemService } from 'src/app/service/item.service';

@Component({
  selector: 'app-item-delete',
  templateUrl: './item-delete.component.html',
  styleUrls: ['./item-delete.component.css']
})
export class ItemDeleteComponent implements OnInit {

  public item!: Item;
  public showMsg: boolean = false;
  public msg: string = "";
  public type: string = "";
  public id: number = 0;

  constructor(public service: ItemService,
    private router: Router,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {

    this.getById();

  }

  public getById() 
  {
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

  public delete() {
    this.service.delete(this.item.id).subscribe(
      data => {
        this.router.navigate(['/item/list']);
      },
      error => {
        this.showMsg = true;
        this.msg = 'An error  has ocurred deleting product';
        this.type = 'danger';
      }
    );
  }

}
