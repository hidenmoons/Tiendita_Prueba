import { Component, Input, OnInit } from '@angular/core';
import { CarritoService } from '../services/carrito.service';
import { ProductsService } from '../services/Products.service';
import { PRODUCTS } from '../Models/Product.data';
import { NewCarritoDetails } from '../Models/Carritodetails.data';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  products: PRODUCTS | any;
 
  constructor(private carritoservice:CarritoService, private productservice:ProductsService) { }

  ngOnInit(): void {
  }

  @Input() product: any;

  addToCart(product: any) {

    
    const CarritoDetails: NewCarritoDetails={
      iddetalleCarrito: product.productId,
      idcarrito: 9,
      idproducto: product.productId,
      cantidadProducto: 1,
      precioUnitario: product.precio,
    }

    console.log(product);
    window.alert("producto agregado");
    this.carritoservice.CrearCarrito(product).subscribe(data=>{

      console.log(data)
      this.carritoservice.crearcarritodetails(CarritoDetails).subscribe(data2=>{
        console.log(data2)
      })
    })

    
  }
}
