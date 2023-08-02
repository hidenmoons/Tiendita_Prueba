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
        [HttpPost("CarritoDetails")]
        public async Task<IActionResult> ADDProductoAlCarrito(int carritoId, int productoId, int cantidad, decimal precioUnitario)
        {
            var newProductocarrito = await _CarritoRepository.ADDProductoAlCarrito(carritoId, productoId, cantidad, precioUnitario);
            return StatusCode(StatusCodes.Status201Created, newProductocarrito);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarrito(int userId)
        {
            var newcarrito = await _CarritoRepository.CreateCarrito(userId);
            return StatusCode(StatusCodes.Status201Created, newcarrito);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCarrito(int carritoId)
        {
            await _CarritoRepository.DeleteCarrito(carritoId);

            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpDelete("CarritoDetails")]
        public async Task<IActionResult> DeleteProductoDeCarrito(int carritoDetailsId)
        {
            await _CarritoRepository.DeleteProductoDeCarrito(carritoDetailsId);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpGet]
        public async Task<IActionResult> GetCarritosDeUsuario(int userId)
        {
            var listaCarrito = await _CarritoRepository.GetCarritosDeUsuario(userId);

            return StatusCode(StatusCodes.Status200OK, listaCarrito);
        }
        [HttpGet("CarritoDetails")]
        public async Task<IActionResult> GetDetallesDeCarrito(int carritoId)
        {
            var detallecarrito = await _CarritoRepository.GetDetallesDeCarrito(carritoId);
            return StatusCode(StatusCodes.Status200OK, detallecarrito);

        }
        [HttpPut("CarritoDetails")]
        public async Task<IActionResult> UpdateDetallesDeCarrito(NewCarritoDetails carritoDetails)
        {
            await _CarritoRepository.UpdateDetallesDeCarrito(carritoDetails);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
