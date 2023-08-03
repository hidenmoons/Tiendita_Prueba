export interface NewCarritoDetails {
    iddetalleCarrito: number;
    idcarrito: number | null;
    idproducto: number | null;
    cantidadProducto: number;
    precioUnitario: number | null; 
}

export interface getcarritodetails {
    iddetalleCarrito: number
    idcarrito: number
    idproducto: number
    cantidadProducto: number
    precioUnitario: number
    subtotal: number
    productoNombre: string
    productoDescrip: string
    productoIMG: string
  }
  
  export interface carrito{
    carritoId: number;
    userId: number;
    carritoStatus:string;
  }
  //carritoId: 9, userId: 20, carritoStatus: 'Activo'