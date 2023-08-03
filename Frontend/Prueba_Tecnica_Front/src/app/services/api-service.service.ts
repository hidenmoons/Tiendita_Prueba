import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {
 private apiurlUsers='https://localhost:7237/api/'

  constructor(private http: HttpClient) { }

  Login(data:any){
    return this.http.post(this.apiurlUsers +"Auth/auth", data)
  }


  register(data:any){
    
    return this.http.post(this.apiurlUsers +"User", data)

  }
}
