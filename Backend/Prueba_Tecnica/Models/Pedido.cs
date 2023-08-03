using System;
using System.Collections.Generic;

namespace Prueba_Tecnica.Models;

public partial class Pedido
{
    public int Idpedido { get; set; }

    public int? Idusuario { get; set; }

    public DateTime? FechaHoraPedido { get; set; }

    public string? EstadoPedido { get; set; }

    public string? DireccionEnvio { get; set; }

    public decimal? TotalPedido { get; set; }
    public string MetododePago { get; set; }
    public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();

    public virtual User? IdusuarioNavigation { get; set; }
}
