import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProductListComponent } from './component/product-list/product-list.component';
import { ProductSaveComponent } from './component/product-save/product-save.component';
import { ProductEditComponent } from './component/product-edit/product-edit.component';
import { ProductDeleteComponent } from './component/product-delete/product-delete.component';
import { ItemListComponent } from './component/item-list/item-list.component';
import { ItemSaveComponent } from './component/item-save/item-save.component';
import { ItemEditComponent } from './component/item-edit/item-edit.component';
import { ItemDeleteComponent } from './component/item-delete/item-delete.component';

const routes: Routes = [
  { path: '', redirectTo: '/product/list', pathMatch: 'full' },
  { path: 'product/list', component: ProductListComponent },
  { path: 'product/save', component: ProductSaveComponent },
  { path: 'product/edit/:id', component: ProductEditComponent },
  { path: 'product/delete/:id', component: ProductDeleteComponent },
  { path: 'item/list', component: ItemListComponent },
  { path: 'item/save', component: ItemSaveComponent },
  { path: 'item/edit/:id', component: ItemEditComponent },
  { path: 'item/delete/:id', component: ItemDeleteComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
