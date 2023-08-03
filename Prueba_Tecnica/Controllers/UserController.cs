using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba_Tecnica.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly StoreLowCostContext _dbcontext;
        public UserController(StoreLowCostContext _dbcontext)
        {
            this._dbcontext = _dbcontext;
        }
        // GET: api/<UserController>
        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public async Task<IActionResult> ListadeUsuarios()
        {
            var usuariosConCarritos = await _dbcontext.Users
        .Include(u => u.Carritos)
        .ThenInclude(c => c.CarritoDetails)
        .ToListAsync();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                // ... otras opciones ...
            };

            var json = JsonSerializer.Serialize(usuariosConCarritos, options);
            return Content(json, "application/json");

        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Crear_usuario([FromBody] NewUser nuevousuario)
        {
            var user = new User
            {
                UserName = nuevousuario.UserName,
                Passwo = nuevousuario.Passwo,
                Email = nuevousuario.Email,
                Addres = nuevousuario.Addres,
                Roles= nuevousuario.Roles
            };
            _dbcontext.Users.Add(user);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

        }
   
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
