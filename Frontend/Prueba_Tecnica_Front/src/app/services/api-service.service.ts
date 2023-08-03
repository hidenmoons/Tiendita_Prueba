import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {
 private apiurlUsers='https://localhost:7237/api/'

  constructor(private http: HttpClient) { }

  Login(data:any): Observable<any>{
    return this.http.post(this.apiurlUsers +"Auth/auth", data)
  }


  register(data:any){
    
    return this.http.post(this.apiurlUsers +"User", data)

  }
  
  saveToken(token: string): void {
    localStorage.setItem('jwtToken', token);
  }

  getToken(): string | null {
    return localStorage.getItem('jwtToken');
  }

  removeToken(): void {
    localStorage.removeItem('jwtToken');
  }
}
