import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';

//Components
import { AppComponent } from './app.component';
import { NavigationtComponent } from './component/navigationt/navigationt.component';
import { ProductListComponent } from './component/product-list/product-list.component';
import { ProductSaveComponent } from './component/product-save/product-save.component';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

//Services
import { ProductService } from './service/product.service';
import { ProductEditComponent } from './component/product-edit/product-edit.component';
import { ProductDeleteComponent } from './component/product-delete/product-delete.component';
import { ItemListComponent } from './component/item-list/item-list.component';
import { ItemSaveComponent } from './component/item-save/item-save.component';
import { ItemEditComponent } from './component/item-edit/item-edit.component';
import { ItemDeleteComponent } from './component/item-delete/item-delete.component';


@NgModule({
  declarations: [
    AppComponent,
    NavigationtComponent,
    ProductListComponent,
    ProductSaveComponent,
    ProductEditComponent,
    ProductDeleteComponent,
    ItemListComponent,
    ItemSaveComponent,
    ItemEditComponent,
    ItemDeleteComponent 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    ProductService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
