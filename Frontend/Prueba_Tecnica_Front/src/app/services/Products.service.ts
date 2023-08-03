import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ProductsService {
 private apiurlUsers='https://localhost:7237/api/Product'

  constructor(private http: HttpClient) { }

  GetProducts(): Observable<any>{
    return this.http.get(this.apiurlUsers)
  }


  register(data:any){
    
    return this.http.post(this.apiurlUsers +"User", data)

  }
}
