using System;
using System.Collections.Generic;

namespace Prueba_Tecnica.Models;

public partial class CarritoDetail
{
    public int IddetalleCarrito { get; set; }

    public int? Idcarrito { get; set; }

    public int? Idproducto { get; set; }

    public int? CantidadProducto { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual Carrito? IdcarritoNavigation { get; set; }

    public virtual Product? IdproductoNavigation { get; set; }
}
