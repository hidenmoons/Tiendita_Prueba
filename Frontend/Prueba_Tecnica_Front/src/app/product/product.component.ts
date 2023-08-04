import { Component, Input, OnInit } from '@angular/core';
import { CarritoService } from '../services/carrito.service';
import { ProductsService } from '../services/Products.service';
import { PRODUCTS } from '../Models/Product.data';
import { NewCarritoDetails } from '../Models/Carritodetails.data';
import { ApiServiceService } from '../services/api-service.service';
import { carrito } from '../Models/Carritodetails.data';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  products: PRODUCTS | any;
  //carrito: carrito| any;
  constructor(private carritoservice:CarritoService, private productservice:ProductsService , private apiservice:ApiServiceService) { }

  ngOnInit(): void {
  }

  @Input() product: any;

  addToCart(product: any) {
    console.log(product);
    //window.alert("producto agregado");
    this.carritoservice.CrearCarrito().subscribe((data: carrito)=>{

       console.log(data.carritoId);
        const idcarrito = data.carritoId;
        
        const CarritoDetails: NewCarritoDetails={
          iddetalleCarrito: product.productId,
          idcarrito: idcarrito,
          idproducto: product.productId,
          cantidadProducto: 1,
          precioUnitario: product.precio,
        }
       
        this.carritoservice.crearcarritodetails(CarritoDetails).subscribe(data2=>{
        
          console.log(data2)
        })
      
      //const tokencarrito =  localStorage.getItem('CarritoToken')?.toString();
      //console.log(tokencarrito)

    })

    
  }
}
