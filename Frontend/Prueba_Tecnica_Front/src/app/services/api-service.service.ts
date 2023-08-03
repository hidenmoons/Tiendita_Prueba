import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {
 private apiurlUsers='https://localhost:7237/api/Auth/auth'

  constructor(private http: HttpClient) { }

  Login(data:any){
    return this.http.post(this.apiurlUsers, data)
  }
  
}
