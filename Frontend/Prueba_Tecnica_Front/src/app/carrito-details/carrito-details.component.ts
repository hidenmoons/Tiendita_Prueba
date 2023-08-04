import { Component, OnInit } from '@angular/core';
import { getcarritodetails } from '../Models/Carritodetails.data';
import { CarritoService } from '../services/carrito.service';
import { carrito } from '../Models/Carritodetails.data';
import { PedidoService } from '../services/Pedido.service';
import { Pedidos } from '../Models/Pedidos.data';
import { ApiServiceService } from '../services/api-service.service';
@Component({
  selector: 'app-carrito-details',
  templateUrl: './carrito-details.component.html',
  styleUrls: ['./carrito-details.component.css']
})
export class CarritoDetailsComponent implements OnInit {
  carritoid: carrito | any;
  newpedidos: Pedidos| any;
  currentuser: any;
  carrito: getcarritodetails[]=[];
  metodoPagoSeleccionado: string = '';
  constructor(private carritoservice:CarritoService, private pedidos:PedidoService, private apiservice:ApiServiceService) { }

  ngOnInit(): void {
    this.getCarritoDetails();
  }

  getCarritoDetails(){
    this.carritoservice.CrearCarrito().subscribe((data: carrito)=>{
      this.carritoid =data.carritoId;
      console.log(this.carritoid)
      if(this.carrito!=null){
      this.carritoservice.getDetallesDeCarrito(this.carritoid).subscribe(data=>{
        this.carrito = this.groupAndSumProducts(data)
        console.log(this.carrito)
      })
    }
    })
  }
  
  groupAndSumProducts(carrito: getcarritodetails[]): getcarritodetails[] {
    const groupedProducts: getcarritodetails[] = [];
    
    carrito.forEach(producto => {
      const existingProduct = groupedProducts.find(p => p.idproducto === producto.idproducto);
      if (existingProduct) {
        existingProduct.cantidadProducto += producto.cantidadProducto;
        existingProduct.subtotal += producto.subtotal;
      } else {
        groupedProducts.push({ ...producto });
      }
    });
  
    return groupedProducts;
  }
  
  calcularTotalCarrito(): number {
    let total = 0;
    for (const producto of this.carrito) {
      total += producto.subtotal;
    }
    return total;
  }

  Pagarpedido(){
    this.currentuser = this.apiservice.getCurrentUser()
    console.log(this.currentuser)

    const total= this.calcularTotalCarrito()

    console.log(total); 
    const pedidos: Pedidos={
      idpedido:1,
      idusuario: this.currentuser.userId,
      estadoPedido: 'Enviado',
      direccionEnvio: this.currentuser.addres,
      totalPedido: total,
      metododePago: this.metodoPagoSeleccionado,
    }

    console.log(pedidos)
    this.pedidos.PostPedido(pedidos).subscribe(data=>{
      console.log(data);
    }, error => {
      console.error('Error al realizar el pago:', error);
    })
  }
}
