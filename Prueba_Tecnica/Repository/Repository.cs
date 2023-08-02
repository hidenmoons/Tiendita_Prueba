using Prueba_Tecnica.Interfaces;
using Prueba_Tecnica.Models;
using Microsoft.EntityFrameworkCore;
namespace Prueba_Tecnica.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly StoreLowCostContext _dbcontext;

        public ProductRepository(StoreLowCostContext _dbcontext)
        {
           this._dbcontext = _dbcontext;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _dbcontext.Products.ToListAsync();
        }

        public async Task AddProduct(NewProduct product)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateProduct(NewProduct product)
        {
            throw new NotImplementedException();
        }
    }
}
