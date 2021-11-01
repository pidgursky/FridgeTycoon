import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { BaseService } from "../shared/base.service";
import { ConfigService } from '../shared/config.service';
import { Fridge } from '../shared/models/fridge.model';
import { Product } from '../shared/models/product.model';

@Injectable({
  providedIn: 'root'
})

export class FridgeTycoonService extends BaseService {

  constructor(private http: HttpClient, private configService: ConfigService) {    
    super();      
  }

  fetchFridgeTycoonData(token: string) {   
    return this.http
      .get(this.configService.resourceApiURI + '/fridge/get', this.getHttpOptions(token))
      .pipe(catchError(this.handleError));
  }

  deleteFridge(token: string, id: string){
    return this.http
      .delete(this.configService.resourceApiURI + '/fridge/delete/' + id, this.getHttpOptions(token))
      .pipe(catchError(this.handleError)); 
  }

  createFridge(token: string, fridge: Fridge){
    return this.http
      .post<Fridge>(this.configService.resourceApiURI + '/fridge/create', fridge, this.getHttpOptions(token)); 
  }

  updateFridge(token: string, fridge: Fridge){
    return this.http
      .put<Fridge>(this.configService.resourceApiURI + '/fridge/update/' + fridge.id, fridge, this.getHttpOptions(token)); 
  }


  getFridge(token: string, id: string) {   
    return this.http
      .get(this.configService.resourceApiURI + '/fridge/get/' + id , this.getHttpOptions(token))
      .pipe(catchError(this.handleError));
  }

  getProduct(token: string, id: string) {   
    return this.http
      .get(this.configService.resourceApiURI + '/product/get/' + id , this.getHttpOptions(token))
      .pipe(catchError(this.handleError));
  }

  createProduct(token: string, product: Product){
    return this.http
      .post<Product>(this.configService.resourceApiURI + '/product/create', product, this.getHttpOptions(token))
      .pipe(catchError(this.handleError)); 
  }

  deleteProduct(token: string, id: string){
    return this.http
      .delete(this.configService.resourceApiURI + '/product/delete/' + id, this.getHttpOptions(token))
      .pipe(catchError(this.handleError)); 
  }

  updateProduct(token: string, product: Product){
    return this.http
    
      .put<Product>(this.configService.resourceApiURI + '/product/update/' + product.id, product, this.getHttpOptions(token))
      .pipe(catchError(this.handleError)); 
  }

  getProductsByFridge(token: string, fridgeId: string) {   
    return this.http
      .get(this.configService.resourceApiURI + '/product/get/fridge/' + fridgeId, this.getHttpOptions(token))
      .pipe(catchError(this.handleError));
  }

  
  private getHttpOptions(token: string): object {
    return {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Authorization': token
      })
    };
  }
}
