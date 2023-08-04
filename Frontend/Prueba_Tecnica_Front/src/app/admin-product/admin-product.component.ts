import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../services/Products.service';
import { PRODUCTS } from '../Models/Product.data';
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
openCreateModal(){
  this.editProduct={
    productId: null,
    productName: '',
    descript: '',
    precio: null,
    stock: null,
    categoria: '',
    imagen: ''
  };

}
 

CreateItem(){

  this.productService.createProduct(this.editProduct).subscribe(data=>{
    this.getproducts();
    window.alert("Producto Creado");
    console.log(data);
  },()=>{
    window.alert("Algo salio mal porfavor inicia sesion de nuevo")
  })
}

  saveChanges() {
    this.productService.UpdateProduct(this.editProduct).subscribe(data=>{
      
      console.log(data);
      this.getproducts();
      window.alert("Producto Modificado con exito!")
    }, ()=>{
      window.alert("Algo salio mal porfavor inicia sesion de nuevo")
    })
    
  }
  
  deleteProduct(product:any){

    this.productService.DeleteProduct(product).subscribe(data=>{
      window.alert("Producto eliminado!")
      this.getproducts();
    }, ()=>{
      window.alert("Algo salio mal porfavor inicia sesion de nuevo")
    })
  }
}
