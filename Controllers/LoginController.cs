using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using biblioteca.Models;
using biblioteca.Services;

namespace biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IConfiguration _configuration;

        public AuthController(IUsuarioService usuarioService, IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _configuration = configuration;
        }
    
         
        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioLoginModel loginModel)
        {
            var usuario = _usuarioService.GetByUserNameAndPassword(loginModel.UserName, loginModel.Password);
            if (usuario == null)
            {
                return Unauthorized();
            }

            var key = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), "JWT key cannot be null or empty.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var keyBytes = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.PkUsuario.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var response = new AuthResponseModel
            {
                Token = tokenString,
                Usuario = usuario
            };

            return Ok(response);
        }
    }
    public class AuthResponseModel
    {
        public string Token { get; set; }
        public Usuario Usuario { get; set; }
    }
    public class UsuarioLoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}