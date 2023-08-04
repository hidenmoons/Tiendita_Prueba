using Prueba_Tecnica.Models;
namespace Prueba_Tecnica.Interfaces
{
    public interface IPedidosRepository
    {
        Task<Pedido> AddPedido(NewPedido product);

    }
}
