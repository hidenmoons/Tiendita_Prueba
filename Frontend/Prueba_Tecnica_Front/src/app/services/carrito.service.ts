import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { getcarritodetails } from '../Models/Carritodetails.data';
const token = localStorage.getItem('jwtToken');
const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
const options = { headers: headers }; 
@Injectable({
  providedIn: 'root'
})

export class CarritoService {

  private apiurlUsers='https://localhost:7237/api/'

  
  constructor(private http: HttpClient) { }

  CrearCarrito(data: any){
   

    return this.http.post(this.apiurlUsers +"Carrito",data,options)

  }

 crearcarritodetails(data:any){

  return this.http.post(this.apiurlUsers +"Carrito/CarritoDetails",data,options)

 }

 getDetallesDeCarrito(carritoId: number): Observable<getcarritodetails[]> {
  return this.http.get<getcarritodetails[]>(`${this.apiurlUsers}Carrito/CarritoDetails?carritoId=${carritoId}`);
}

  
}
