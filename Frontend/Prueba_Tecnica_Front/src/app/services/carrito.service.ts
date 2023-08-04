import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { getcarritodetails } from '../Models/Carritodetails.data';


@Injectable({
  providedIn: 'root'
})

export class CarritoService {

  private apiurlUsers='https://localhost:7237/api/'

  
  constructor(private http: HttpClient) { }

  CrearCarrito():Observable<any>{
    const token = localStorage.getItem('jwtToken');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    const options = { headers: headers }; 
    console.log(token);
    return this.http.post(this.apiurlUsers +"Carrito",{},options)

  }

  saveToken(token: string): void {
    localStorage.setItem('CarritoToken', token);
  }

  getToken(): string | null {
    return localStorage.getItem('CarritoToken');
  }

  removeToken(): void {
    localStorage.removeItem('CarritoToken');
  }

 crearcarritodetails(data:any){
  const token = localStorage.getItem('jwtToken');
  const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
  const options = { headers: headers }; 
  return this.http.post(this.apiurlUsers +"Carrito/CarritoDetails",data,options)

 }

 deleteitemcarrito(nume:any):Observable<any>{
  return this.http.delete<any>(this.apiurlUsers+"Carrito/CarritoDetails?carritoDetailsId="+nume)
 }

 getDetallesDeCarrito(carritoId: number): Observable<getcarritodetails[]> {
  return this.http.get<getcarritodetails[]>(`${this.apiurlUsers}Carrito/CarritoDetails?carritoId=${carritoId}`);
}
  
}
