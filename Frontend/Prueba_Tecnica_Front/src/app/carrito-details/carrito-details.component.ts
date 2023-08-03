import { Component, OnInit } from '@angular/core';
import { getcarritodetails } from '../Models/Carritodetails.data';
import { CarritoService } from '../services/carrito.service';
import { carrito } from '../Models/Carritodetails.data';
@Component({
  selector: 'app-carrito-details',
  templateUrl: './carrito-details.component.html',
  styleUrls: ['./carrito-details.component.css']
})
export class CarritoDetailsComponent implements OnInit {
  carritoid: carrito | any;
  carrito: getcarritodetails[]=[];
  constructor(private carritoservice:CarritoService) { }

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
}
