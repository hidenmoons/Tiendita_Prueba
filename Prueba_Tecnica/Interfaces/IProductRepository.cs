using Prueba_Tecnica.Models;
namespace Prueba_Tecnica.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<Product> AddProduct(NewProduct product);
        Task UpdateProduct(NewProduct product);
        Task DeleteProduct(int id);
    }
}
