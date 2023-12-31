﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica.Interfaces;
using Prueba_Tecnica.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        //[Authorize(Policy = "AdminOnly")]
        [HttpPost("CarritoDetails")]
        public async Task<IActionResult> ADDProductoAlCarrito([FromBody] NewCarritoDetails newcarritodetails)
        {
           

            var newProductocarrito = await _CarritoRepository.ADDProductoAlCarrito(newcarritodetails);
            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var json = JsonSerializer.Serialize(newProductocarrito, jsonOptions);
            return new ContentResult
            {
                Content = json,
                ContentType = "application/json",
                StatusCode = StatusCodes.Status201Created
            };
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> CreateCarrito()
        {
            int userId = 0;
            var userlogin = User.Identity.Name;
            var userclaim = User.FindFirst("UserId");

            if (userclaim != null && int.TryParse(userclaim.Value, out int userid))
            {
                userId = userid;
                Console.WriteLine(userid);
            }

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
            var detallesConNombres = detallecarrito.Select(detalle => new
            {
                detalle.IddetalleCarrito,
                detalle.Idcarrito,
                detalle.Idproducto,
                detalle.CantidadProducto,
                detalle.PrecioUnitario,
                detalle.Subtotal,
                ProductoNombre = detalle.IdproductoNavigation.ProductName,
                ProductoDescrip= detalle.IdproductoNavigation.Descript,
                ProductoIMG= detalle.IdproductoNavigation.Imagen
            }).ToList();

            return StatusCode(StatusCodes.Status200OK, detallesConNombres);

        }

        [HttpPut("CarritoDetails")]
        public async Task<IActionResult> UpdateDetallesDeCarrito(NewCarritoDetails carritoDetails)
        {
            await _CarritoRepository.UpdateDetallesDeCarrito(carritoDetails);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
