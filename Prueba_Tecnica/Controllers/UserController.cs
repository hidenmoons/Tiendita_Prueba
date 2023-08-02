using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica.Models;

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
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ListadeUsuarios()
        {

            return Ok(await _dbcontext.Users.ToListAsync());

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
            };
            _dbcontext.Users.Add(user);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

        }

        // login api/<UserController>/5
   
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
