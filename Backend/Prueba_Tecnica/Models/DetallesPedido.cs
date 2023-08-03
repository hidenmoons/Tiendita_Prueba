using System;
using System.Collections.Generic;

namespace Prueba_Tecnica.Models;

public partial class DetallesPedido
{
    public int IddetallePedido { get; set; }

    public int? Idpedido { get; set; }

    public int? Idproducto { get; set; }

    public int? CantidadProducto { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual Pedido? IdpedidoNavigation { get; set; }

    public virtual Product? IdproductoNavigation { get; set; }
}
