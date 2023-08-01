using System;
using System.Collections.Generic;

namespace Prueba_Tecnica.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Passwo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Addres { get; set; } = null!;

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
