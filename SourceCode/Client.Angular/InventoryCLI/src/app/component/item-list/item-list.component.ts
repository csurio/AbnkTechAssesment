import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Item } from 'src/app/domain/item';
import { ItemService } from 'src/app/service/item.service';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent implements OnInit, OnDestroy {

  public items: Item[] = [];
  public subItems: Subscription = new Subscription;

  constructor(public itemService: ItemService) { }

  ngOnDestroy(): void {
    this.subItems.unsubscribe();
  }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.subItems = this.itemService.getAll().subscribe(
      data => {
        this.items = data;
      }
    );
  }

}
