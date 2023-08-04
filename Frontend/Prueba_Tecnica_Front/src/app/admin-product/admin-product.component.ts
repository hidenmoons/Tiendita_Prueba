import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../services/Products.service';
@Component({
  selector: 'app-admin-product',
  templateUrl: './admin-product.component.html',
  styleUrls: ['./admin-product.component.css']
})
export class AdminProductComponent implements OnInit {

  products: any[] = [];
  editProduct: any = {};
  showEditModal: boolean = false; 
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

  openEditModal(product: any) {
    this.editProduct = { ...product };
    this.showEditModal = true;
  }

  cancelEdit() {
    this.showEditModal = false;
  }

  saveChanges() {
    // Lógica para guardar los cambios en la base de datos o en la lista local de productos
    // ...
    this.cancelEdit(); // Cerrar el modal
  }
  
  deleteProduct(product:any){

  }
}
