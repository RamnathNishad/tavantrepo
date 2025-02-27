using EmployeesWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AccountController(IConfiguration config)
        {
            this._config = config;
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserDetails user)
        {   
            //validate user from database
            if(user.UserName=="admin" && user.Password=="admin123")
            {
                //generate token
                var secretKey = _config["jwt:secretKey"];
                var securityKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                var tokenParams = new JwtSecurityToken
                (
                    issuer: _config["jwt:issuer"],
                    audience: _config["jwt:audience"],
                    expires:DateTime.Now.AddMinutes(2),
                    signingCredentials:new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256),
                    claims:new List<Claim> 
                    {
                        new Claim(ClaimTypes.Role,"Guest")
                    }
                );

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.WriteToken(tokenParams);

                return Ok(token);
            }
            else
            {
                return BadRequest("invalid user credentials");
            }
        }
    }
}
