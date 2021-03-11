using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WeatherForecast.Library.Models;

namespace WeatherForecast.API.Controllers
{
	[ApiController]
	[Route("api/auth")]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _config;

		public AuthController(IConfiguration config)
		{
			_config = config;
		}

		[HttpPost, Route("login")]
		public IActionResult Login([FromBody] LoginModel user)
		{
			if (user == null)
			{
				return BadRequest("Invalid client request");
			}

			// User credentials would be stored in a database - hardcoded username and password for demonstrative purposes
			if (user.UserName == "johndoe" && user.Password == "qwerty123")
			{
				var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("ApiKey").Value));

				var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

				var tokenOptions = new JwtSecurityToken(
					issuer: "https://localhost:44317",
					audience: "https://localhost:44317",
					claims: new List<Claim>(),
					expires: DateTime.Now.AddHours(1),
					signingCredentials: signingCredentials);

				var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

				return Ok(new { Token = tokenString });
			}

			return Unauthorized();
		}
	}
}
