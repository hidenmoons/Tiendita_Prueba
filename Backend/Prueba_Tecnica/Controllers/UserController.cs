using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using Prueba_Tecnica.Utilitys;

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
            };

            var json = JsonSerializer.Serialize(usuariosConCarritos, options);
            return Content(json, "application/json");

        }

      
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

   
        [HttpPost]
        public async Task<IActionResult> Crear_usuario([FromBody] NewUser nuevousuario)
        {
            CrifrarPassword cifrarPassword = new CrifrarPassword();

            var user = new User
            {
                UserName = nuevousuario.UserName,
                Passwo = cifrarPassword.Cifrar_contrase_(nuevousuario.Passwo),
                Email = nuevousuario.Email,
                Addres = nuevousuario.Addres,
                Roles= nuevousuario.Roles
            };
            _dbcontext.Users.Add(user);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

        }
   
       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
