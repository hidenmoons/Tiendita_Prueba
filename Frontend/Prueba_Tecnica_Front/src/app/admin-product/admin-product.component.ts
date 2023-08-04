import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../services/Products.service';
@Component({
  selector: 'app-admin-product',
  templateUrl: './admin-product.component.html',
  styleUrls: ['./admin-product.component.css']
})
export class AdminProductComponent implements OnInit {

  products: any[] = []; // Declarar el arreglo de productos

  constructor(private productService: ProductsService) { }

  ngOnInit(): void {
   this.getproducts();
  }

  getproducts(){
    this.productService.GetProducts().subscribe(data=>{
      this.products=data;
      console.log(data)
    });
  }
  editProduct(product:any){

  }
  deleteProduct(product:any){

  }
}
