using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica.Interfaces;
using Prueba_Tecnica.Models;

namespace Prueba_Tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosRepository _pedidosRepository;

        public PedidosController(IPedidosRepository _pedidosRepository)
        {
            this._pedidosRepository = _pedidosRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CrearPedido([FromBody] NewPedido pedido)
        {
            var newpedido = await _pedidosRepository.AddPedido(pedido);

            return StatusCode(StatusCodes.Status200OK, newpedido);

        }
    }
}
