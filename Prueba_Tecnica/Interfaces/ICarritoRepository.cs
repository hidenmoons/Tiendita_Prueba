using Prueba_Tecnica.Models;
namespace Prueba_Tecnica.Interfaces
{
    public interface ICarritoRepository
    {
        Task<Carrito> CreateCarrito(int userId);
        Task<CarritoDetail> ADDProductoAlCarrito(int carritoId, int productoId, int cantidad, decimal precioUnitario);
        Task<List<Carrito>> GetCarritosDeUsuario(int userId);
        Task<CarritoDetail> GetDetallesDeCarrito(int carritoId);
        Task UpdateDetallesDeCarrito(CarritoDetail carritoDetails);
        Task DeleteCarrito(int carritoId);
        Task DeleteProductoDeCarrito(int carritoDetailsId);
    }
}
