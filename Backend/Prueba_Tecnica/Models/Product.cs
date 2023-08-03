using System;
using System.Collections.Generic;

namespace Prueba_Tecnica.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string Descript { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public string Categoria { get; set; } = null!;

    public string Imagen { get; set; } = null!;

    public virtual ICollection<CarritoDetail> CarritoDetails { get; set; } = new List<CarritoDetail>();

    public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();
}
