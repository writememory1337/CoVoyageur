using Microsoft.AspNetCore.Mvc;
using CoVoyageur.API.DTOs;
using CoVoyageur.Core.Models;
using CoVoyageur.API.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoVoyageur.API.Helpers;

namespace CoVoyageur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly AppSettings _settings;
        private readonly string _securityKey = "super secret key";
        public AuthenticationController(IRepository<User> userRepository,
            IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _settings = appSettings.Value;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (await _userRepository.Get(u => u.Email == user.Email) != null)
                return BadRequest("email already in use");

            user.Password = EncryptPassword(user.Password);

            return (await _userRepository.Add(user) != null) ? Ok(new { id = user.ID, Message = "user created!" }) : BadRequest("Something went wrong...");
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            User? user = await _userRepository.Get(u => u.ID == id);
            if (user == null)
                return BadRequest("User Not Found");

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO login)
        {
            login.PassWord = EncryptPassword(login.PassWord);

            var user = await _userRepository.Get(u => u.Email == login.Email && u.Password == login.PassWord);

            if (user == null) return BadRequest("Invalid Authentication !");

            var role = user.IsAdmin ? "Admin" : "User";

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, Constantes.RoleAdmin),
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
            };

            SigningCredentials signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.SecretKey!)),
                SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _settings.ValidIssuer,
                audience: _settings.ValidAudience,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddDays(7)
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new
            {
                Token = token,
                Message = "Valid Authentication !",
                User = user
            });
        }


        [HttpPost("login-url-encoded")]
        public async Task<IActionResult> LoginURL([FromForm] string email, [FromForm] string password)
        {
            string encryptedPassword = EncryptPassword(password);

            var user = await _userRepository.Get(u => u.Email == email && u.Password == password);

            if (user == null) return BadRequest("Invalid Authentication !");

            var role = user.IsAdmin ? "Admin" : "User";

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, Constantes.RoleAdmin),
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
            };

            SigningCredentials signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.SecretKey!)),
                SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _settings.ValidIssuer,
                audience: _settings.ValidAudience,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddDays(7)
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new
            {
                Token = token,
                Message = "Valid Authentication !",
                User = user
            });
        }

        [NonAction]
        private string EncryptPassword(string? password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password + _securityKey));
        }
    }
}
