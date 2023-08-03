import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistroLoginComponent } from './registro-login/registro-login.component';
import {ListaProductsComponent} from './lista-products/lista-products.component';
import { CarritoDetailsComponent } from './carrito-details/carrito-details.component';

const routes: Routes = [
  {path:'registro-login', component:RegistroLoginComponent},
  {path:'',component: ListaProductsComponent},
  {path:'Catalogo',component: ListaProductsComponent},
  {path:'Carrito',component: CarritoDetailsComponent}
];

@NgModule({ 
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
