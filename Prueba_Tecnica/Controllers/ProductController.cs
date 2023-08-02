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
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this._productRepository= productRepository;
        }
        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetallProducts()
        {
            var products = await _productRepository.GetProducts();
            return StatusCode(StatusCodes.Status200OK, products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var products = await _productRepository.GetProductById(id);
            return StatusCode(StatusCodes.Status200OK,products);
        }
        [HttpPost]
        public async Task<IActionResult> NewProducto([FromBody]NewProduct product)
        {
            
            var newProduct = await _productRepository.AddProduct(product);
            return StatusCode(StatusCodes.Status201Created, newProduct);
        }

        [HttpPut]
        public async Task<ActionResult> ActionResult([FromBody] NewProduct product)
        {
            await _productRepository.UpdateProduct(product);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
