using Prueba_Tecnica.Models;
namespace Prueba_Tecnica.Interfaces
{
    public interface ICarritoRepository
    {
        Task<Carrito> CreateCarrito(int userId);
        Task<CarritoDetail> ADDProductoAlCarrito(NewCarritoDetails newCarritoDetails);
        Task<List<Carrito>> GetCarritosDeUsuario(int userId);
        Task<List<CarritoDetail>> GetDetallesDeCarrito(int carritoId);
        Task UpdateDetallesDeCarrito(NewCarritoDetails carritoDetails);
        Task DeleteCarrito(int carritoId);
        Task DeleteProductoDeCarrito(int carritoDetailsId);
    }
}
