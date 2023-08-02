using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica.Interfaces;
using Prueba_Tecnica.Models;

namespace Prueba_Tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoRepository _CarritoRepository;
        public CarritoController(ICarritoRepository carritoRepository)
        {
            this._CarritoRepository = carritoRepository;
        }
        [HttpPost]
        public async Task<IActionResult> ADDProductoAlCarrito(int carritoId, int productoId, int cantidad, decimal precioUnitario)
        {
            var newProductocarrito = await _CarritoRepository.ADDProductoAlCarrito(carritoId, productoId, cantidad, precioUnitario);
            return StatusCode(StatusCodes.Status201Created,newProductocarrito);
        }
    }
}
