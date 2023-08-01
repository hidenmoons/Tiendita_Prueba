using System;
using System.Collections.Generic;

namespace Prueba_Tecnica.Models;

public partial class Carrito
{
    public int CarritoId { get; set; }

    public int? UserId { get; set; }

    public string? CarritoStatus { get; set; }

    public virtual ICollection<CarritoDetail> CarritoDetails { get; set; } = new List<CarritoDetail>();

    public virtual User? User { get; set; }
}
