import { Component, Input, OnInit } from '@angular/core';
import { PRODUCTS } from '../Models/Product.data';
import { ProductsService } from '../services/Products.service'
@Component({
  selector: 'app-lista-products',
  templateUrl: './lista-products.component.html',
  styleUrls: ['./lista-products.component.css']
})
export class ListaProductsComponent implements OnInit {

  products: PRODUCTS[]=[];

  constructor(private producservice:ProductsService) { }

  ngOnInit(): void {
    console.log(this.products)
    this.getproducts();
  }

  getproducts(){

   this.producservice.GetProducts().subscribe((data: PRODUCTS[]) =>{

    this.products = data;
    console.log(data);
   })

  }
}
