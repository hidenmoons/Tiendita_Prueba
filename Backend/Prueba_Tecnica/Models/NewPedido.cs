using System;
using System.Collections.Generic;

namespace Prueba_Tecnica.Models;

public partial class NewPedido
{
    public int Idpedido { get; set; }

    public int? Idusuario { get; set; }

    public string? EstadoPedido { get; set; }

    public string? DireccionEnvio { get; set; }

    public decimal? TotalPedido { get; set; }
    public string MetododePago { get; set; }

}
