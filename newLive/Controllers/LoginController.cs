using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using newLive.DTOS;
using newLive.Interfaces;
using newLive.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace newLive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepo;
        private readonly IConfiguration _configuration;
        public LoginController(ILoginRepository loginRepo, IConfiguration configuration)
        {
            _loginRepo = loginRepo;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var login = await _loginRepo.FindByUsernameAndType(loginDto.Username, loginDto.Usertype);
            if (login == null) return NotFound("Incorrect Credentials");
            if (login.Password == loginDto.Password)
            {
                HttpContext.Response.Headers.Add("token", GenerateToken(login.Usertype));
                if (login.Usertype == "doctor")
                {
                    Doctorsinfo doctor = await _loginRepo.GetDoctor();
                    return Ok(doctor);
                }
                return Ok();
            }
            return NotFound("Incorrect Credentials");
        }


        private string GenerateToken(string type)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Role,type)
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                null,
                claims,
                expires: DateTime.UtcNow.AddDays(650),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
