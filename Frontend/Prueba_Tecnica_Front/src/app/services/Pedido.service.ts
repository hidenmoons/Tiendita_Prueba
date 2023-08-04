import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class PedidoService {
 private apiurlUsers='https://localhost:7237/api/'

  constructor(private http: HttpClient) { }

 


  PostPedido(data:any){
    
    return this.http.post(this.apiurlUsers+"Pedidos" , data)
  }
}
