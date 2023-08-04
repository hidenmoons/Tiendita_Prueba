import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ProductsService {
 private apiurlProducts='https://localhost:7237/api/Product'

  constructor(private http: HttpClient) { }

  GetProducts(): Observable<any>{
    const token = localStorage.getItem('jwtToken');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    const options = { headers: headers }; 
    return this.http.get(this.apiurlProducts,options)
  }

  createProduct(product:any): Observable<any>{
    const token = localStorage.getItem('jwtToken');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    const options = { headers: headers }; 

    return this.http.post(this.apiurlProducts,product,options)
  }

  UpdateProduct(product:any):Observable<any>{

    const token = localStorage.getItem('jwtToken');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    const options = { headers: headers }; 
    return this.http.put(this.apiurlProducts,product,options)
  }
 
  DeleteProduct(productid:any):Observable<any>{
    const token = localStorage.getItem('jwtToken');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    const options = { headers: headers }; 

    return this.http.delete(this.apiurlProducts+"?id="+productid,options)

  }


}
