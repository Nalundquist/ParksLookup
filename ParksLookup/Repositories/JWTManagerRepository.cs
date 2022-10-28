using ParksLookup.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using System.Security.Claims;

namespace ParksLookup.Repositories
{
	public class JWTManagerRepository : IJWTManagerRepository
	{
		Dictionary<string, string> UsersDict = new Dictionary<string, string>
		{
			{"user1", "pass123"}
		};

		private readonly IConfiguration _iConfiguration;

		public JWTManagerRepository(IConfiguration iConfiguration)
		{
			_iConfiguration = iConfiguration;
		}

		public Tokens Authenticate (User user)
		{
			if (!UsersDict.Any(u => u.Key == user.Name && u.Value == user.Password))
			{
				return null;
			}

			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.UTF8.GetBytes(_iConfiguration["JWT:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Name)
				}),
				Expires = DateTime.UtcNow.AddMinutes(60),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return new Tokens {Token = tokenHandler.WriteToken(token)};
		}
	}
}