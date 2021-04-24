import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../domain/product';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class ProductService 
{
  public url: string;

  constructor(public httpClient: HttpClient) {
    //this.url = './assets/mock/MOCK_DATA.json';
    //this.url = 'http://localhost:58683/api/v1/product/';
    this.url = environment.apiUrl + 'product/';
  }

  public getAll(): Observable<any> {
    return this.httpClient.get(this.url);
  }

  public getById(id: Number): Observable<any> {
    return this.httpClient.get(this.url + id);
  }

  public save(product: Product): Observable<any>{
     return this.httpClient.post(this.url, product);
  }
  
  public edit(product: Product): Observable<any>{
    return this.httpClient.put(this.url + product.id, product);
  }

  public delete(id: Number){
    return this.httpClient.delete(this.url + id);
  }

}
