import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Item } from '../domain/item';
import { ItemDTO } from '../DTOs/item-dto';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class ItemService {

  public url: string;

  constructor(private httpClient: HttpClient) {
    //this.url = 'http://localhost:58683/api/v1/item/';
    this.url = environment.apiUrl + 'item/';
   }

   public getAll(): Observable<any> {
    return this.httpClient.get(this.url);
  }

  public getById(id: Number): Observable<any> {
    return this.httpClient.get(this.url + id);
  }

  public save(itemDTO: ItemDTO): Observable<any>{
     return this.httpClient.post(this.url, itemDTO);
  }
  
  public edit(itemDTO: ItemDTO): Observable<any>{
    return this.httpClient.put(this.url + itemDTO.id, itemDTO);
  }

  public delete(id: Number){
    return this.httpClient.delete(this.url + id);
  }

}
