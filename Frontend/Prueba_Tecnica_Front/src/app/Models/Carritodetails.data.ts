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
  