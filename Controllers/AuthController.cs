using home.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using home.Models;
using home.DTOs;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System;

namespace home.Controllers
{
	[Route("auth/login")]
	public class AuthController : ControllerBase
	{
		private readonly UserRepo _usersRepo;
		private readonly IConfiguration _configuration;

		public AuthController(IConfiguration configuration, UserRepo usersRepo)
		{
			_usersRepo = usersRepo;
			_configuration = configuration;
		}

		[AllowAnonymous]
		[HttpPost]
		public ActionResult<AuthDto> Authenticate([FromBody] LoginDto login)
		{
			User dbUser = _usersRepo.GetUserByUsername(login.Username);
			if (dbUser == null)
				return NotFound(new { error = "Invalid username" });

			if (BCrypt.Net.BCrypt.Verify(login.Password, dbUser.Password))
			{
				AuthDto authDto = new AuthDto();
				authDto.Username = login.Username;
				authDto.Token = BuildToken(dbUser);

				return Ok(authDto);
			}

			return NotFound(new { error = "Invalid password" });
		}

		private string BuildToken(User user)
		{
			var claims = new[] {
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Issuer"],
				claims: claims,
				expires: DateTime.Now.AddDays(30),
				signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}