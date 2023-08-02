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

        public async Task<Product> AddProduct(NewProduct product)
        {
            var new_producto = new Product
            {
                ProductName = product.ProductName,
                Precio = product.Precio,
                Categoria = product.Categoria,
                Stock = product.Stock,
                Imagen = product.Imagen,
                Descript = product.Descript
            };

             await _dbcontext.Products.AddAsync(new_producto);
             await _dbcontext.SaveChangesAsync();

            return new_producto;
        }

        public async Task DeleteProduct(int id)
        {
           var producto = await _dbcontext.Products.FindAsync(id);
            if (producto != null)
            {
                _dbcontext.Products.Remove(producto);
                await _dbcontext.SaveChangesAsync();

            }
            
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _dbcontext.Products.FindAsync(id);
        }

        public async Task UpdateProduct(NewProduct product)
        {

            var producto = await _dbcontext.Products.FindAsync(product.ProductId);
            if (producto != null)
            {


                producto.Stock = product.Stock;
                producto.Categoria = product.Categoria;
                producto.Precio = product.Precio;
                producto.Imagen = product.Imagen;
                producto.ProductName = product.ProductName;
                producto.Descript = product.Descript;
                
                
                await _dbcontext.SaveChangesAsync();

            }

        }
    }
    public class CarritoRepository : ICarritoRepository
    {
        private readonly StoreLowCostContext _dbcontext;
        public CarritoRepository(StoreLowCostContext _dbcontext)
        {
            this._dbcontext = _dbcontext;
        }
        public async Task<CarritoDetail> ADDProductoAlCarrito(int carritoId, int productoId, int cantidad, decimal precioUnitario)
        {
            var newproductCarrito = new CarritoDetail 
            {
                Idcarrito= carritoId,
                Idproducto= productoId,
                CantidadProducto= cantidad,
                PrecioUnitario= precioUnitario,
                Subtotal= precioUnitario*cantidad,
            };
            _dbcontext.Add(newproductCarrito);
            await _dbcontext.SaveChangesAsync();
            
            return newproductCarrito;
        }

        public Task<Carrito> CreateCarrito(int userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCarrito(int carritoId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductoDeCarrito(int carritoDetailsId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Carrito>> GetCarritosDeUsuario(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<CarritoDetail> GetDetallesDeCarrito(int carritoId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDetallesDeCarrito(CarritoDetail carritoDetails)
        {
            throw new NotImplementedException();
        }
    }

}
