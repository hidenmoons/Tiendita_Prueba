using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica.Interfaces;
using Prueba_Tecnica.Models;
namespace Prueba_Tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// Controlador para administrar productos.
        /// </summary>
        private readonly IProductRepository _productRepository;
        /// <summary>
        /// Constructor del controlador.
        /// </summary>
        /// <param name="productRepository">Repositorio de productos.</param>
        public ProductController(IProductRepository productRepository)
        {
            this._productRepository= productRepository;
        }
        /// <summary>
        /// Obtiene todos los productos.
        /// </summary>
        /// <returns>Lista de productos.</returns>
        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public async Task<IActionResult> GetallProducts()
        {
            var products = await _productRepository.GetProducts();
            return StatusCode(StatusCodes.Status200OK, products);
        }
        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        /// <param name="id">ID del producto.</param>
        /// <returns>Producto encontrado.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var products = await _productRepository.GetProductById(id);
            return StatusCode(StatusCodes.Status200OK,products);
        }

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="product">Datos del nuevo producto.</param>
        /// <returns>Producto creado.</returns>
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> NewProducto([FromBody]NewProduct product)
        {
            
            var newProduct = await _productRepository.AddProduct(product);
            return StatusCode(StatusCodes.Status201Created, newProduct);
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="product">Datos del producto actualizado.</param>
        /// <returns>Respuesta OK si se realizó la actualización.</returns>
        [Authorize(Policy = "AdminOnly")]
        [HttpPut]
        public async Task<ActionResult> ActionResult([FromBody] NewProduct product)
        {
            await _productRepository.UpdateProduct(product);
            return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        /// Elimina un producto por su ID.
        /// </summary>
        /// <param name="id">ID del producto a eliminar.</param>
        /// <returns>Respuesta Accepted si se eliminó el producto.</returns>
        [Authorize(Policy = "AdminOnly")]
        [Authorize(Policy = "ClienteOnly")]
        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
