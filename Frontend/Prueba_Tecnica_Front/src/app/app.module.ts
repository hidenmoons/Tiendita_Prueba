import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistroLoginComponent } from './registro-login/registro-login.component';
import { FormsModule } from '@angular/forms';
import { ListaProductsComponent } from './lista-products/lista-products.component';
import { ProductComponent } from './product/product.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CarritoDetailsComponent } from './carrito-details/carrito-details.component';
import { AdminProductComponent } from './admin-product/admin-product.component';

@NgModule({
  declarations: [
    AppComponent,
    RegistroLoginComponent,
    ListaProductsComponent,
    ProductComponent,
    NavbarComponent,
    CarritoDetailsComponent,
    AdminProductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
