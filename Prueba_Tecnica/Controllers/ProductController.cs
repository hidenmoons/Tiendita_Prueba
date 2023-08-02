using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica.Interfaces;

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
        [HttpGet]
        public async Task<IActionResult> GetallProducts()
        {
            var products = await _productRepository.GetProducts();
            return StatusCode(StatusCodes.Status200OK, products);
        }
    }
}
