﻿using Prueba_Tecnica.Interfaces;
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
        /// <summary>
        /// /
        /// </summary>
        /// <param name="carritoId"></param>
        /// <param name="productoId"></param>
        /// <param name="cantidad"></param>
        /// <param name="precioUnitario"></param>
        /// <returns></returns>
        public async Task<CarritoDetail> ADDProductoAlCarrito(NewCarritoDetails newcarritodetails)
        {
            
            if (newcarritodetails.CantidadProducto <= 0)
            {
                throw new("No se aceptan cantidades negativas");
            }

            var productos = await _dbcontext.Products.FindAsync(newcarritodetails.Idproducto);

            if (productos == null)
            {
                throw new("producto no existe");
            }

            if (productos.Stock < newcarritodetails.CantidadProducto)
            {
                throw new("no hay Suficiente Stock");
            }
           
                
            productos.Stock -= newcarritodetails.CantidadProducto;

            var newproductCarrito = new CarritoDetail 
            {
                Idcarrito= newcarritodetails.Idcarrito,
                Idproducto= newcarritodetails.Idproducto,
                CantidadProducto= newcarritodetails.CantidadProducto,
                PrecioUnitario= newcarritodetails.PrecioUnitario,
                Subtotal= newcarritodetails.PrecioUnitario * newcarritodetails.CantidadProducto,
            };

            _dbcontext.Add(newproductCarrito);
            await _dbcontext.SaveChangesAsync();

   

            return newproductCarrito;
        }

        public async Task<Carrito> CreateCarrito(int userId)
        {
            var statuscarrito = await _dbcontext.Carritos.Where(x => x.UserId == userId).ToListAsync();

            foreach (var item in statuscarrito)
            {
                if (item.CarritoStatus =="Activo")
                {

                    return statuscarrito.Find(x=> x.CarritoId==item.CarritoId);
                }
            }

            var newcarrito = new Carrito
            {
                UserId = userId,
                CarritoStatus = "Activo"
            };

            await _dbcontext.Carritos.AddAsync(newcarrito);
            await _dbcontext.SaveChangesAsync();
            return newcarrito;
        }

        public async Task DeleteCarrito(int carritoId)
        {
            var carrito = await _dbcontext.Carritos.FindAsync(carritoId);
            if (carrito != null)
            {
                _dbcontext.Carritos.Remove(carrito);
                await _dbcontext.SaveChangesAsync();
            }
        }

        public async Task DeleteProductoDeCarrito(int carritoDetailsId)
        {
            var ProductoCarrito = await _dbcontext.CarritoDetails.FindAsync(carritoDetailsId);
            if (ProductoCarrito != null)
            {
                _dbcontext.CarritoDetails.Remove(ProductoCarrito);
                await _dbcontext.SaveChangesAsync();
            }
        }

        public async Task<List<Carrito>> GetCarritosDeUsuario(int userId)
        {
            var carritosUsuario = await _dbcontext.Carritos.
                Where(x => x.UserId == userId).
                ToListAsync();
            return carritosUsuario;
        }

        public async Task<List<CarritoDetail>> GetDetallesDeCarrito(int carritoId)
        {
            var detallesCarrito = await _dbcontext.CarritoDetails
         .Include(cd => cd.IdproductoNavigation) 
         .Where(cd => cd.Idcarrito == carritoId) 
         .ToListAsync();

            return detallesCarrito;
        }

        public async Task UpdateDetallesDeCarrito(NewCarritoDetails carritoDetails)
        {
            var carritoDetailUpdate = await _dbcontext.CarritoDetails.FindAsync(carritoDetails.IddetalleCarrito);

            if (carritoDetailUpdate != null)
            {
                carritoDetailUpdate.CantidadProducto = carritoDetails.CantidadProducto;
                carritoDetailUpdate.Subtotal = carritoDetailUpdate.CantidadProducto * carritoDetailUpdate.PrecioUnitario;

                await _dbcontext.SaveChangesAsync();

            }

        }
    }


    public class PedidoRepository : IPedidosRepository
    {
        private readonly StoreLowCostContext _dbcontext;
        public PedidoRepository(StoreLowCostContext _dbContext)
        {
            this._dbcontext = _dbContext;
        }
        public async Task<Pedido> AddPedido(NewPedido pedido)
        {
            var newpedido = new Pedido
            {
                Idusuario = pedido.Idusuario,
                FechaHoraPedido = DateTime.Now,
                EstadoPedido = pedido.EstadoPedido,
                DireccionEnvio = pedido.DireccionEnvio,
                TotalPedido = pedido.TotalPedido,
                MetododePago = pedido.MetododePago,
            };

            await _dbcontext.Pedidos.AddAsync(newpedido);
            await _dbcontext.SaveChangesAsync();

            return newpedido;
        }
    }
}
