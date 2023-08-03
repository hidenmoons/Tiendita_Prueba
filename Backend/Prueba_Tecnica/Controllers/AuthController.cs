using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica.Utilitys;
namespace Prueba_Tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string secretkey;
        private readonly StoreLowCostContext _dbcontext;
        CrifrarPassword cifrar = new CrifrarPassword();
        public AuthController(IConfiguration config, StoreLowCostContext _dbcontext)
        {
            secretkey = config.GetSection("settings").GetSection("secretkey").ToString();
            this._dbcontext = _dbcontext;
        }

        [HttpPost]
        [Route("auth")]
        public async Task<IActionResult> validarUser([FromBody] UserJWT request)
        {
           
           List<User> userlogin = new List<User>();

            userlogin = await _dbcontext.Users.Where(x => x.Email == request.email).ToListAsync();

            var user = userlogin.First();

            if (request.email == user.Email && cifrar.Cifrar_contrase_(request.password) ==  user.Passwo)
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretkey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.email));
                claims.AddClaim(new Claim("UserID", user.UserId.ToString()));
                claims.AddClaim(new Claim(ClaimTypes.Role, user.Roles));

                var tokenDesc = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)

                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenconfig = tokenHandler.CreateToken(tokenDesc);

                string tokencreado = tokenHandler.WriteToken(tokenconfig);

                return StatusCode(StatusCodes.Status200OK, new { token = tokencreado, user });
            }

            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });

            }

        }
    }
}
