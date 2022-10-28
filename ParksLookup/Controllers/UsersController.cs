using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksLookup.Models;
using ParksLookup.Repositories;

namespace ParksLookup.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IJWTManagerRepository _jWTManager;

		public UsersController(IJWTManagerRepository jWTManager)
		{
			_jWTManager = jWTManager;
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("auth")]
		public IActionResult Auth(User userAuth)
		{
			var token = _jWTManager.Authenticate(userAuth);
			if (token == null)
			{
				return Unauthorized();
			}
			
			return Ok(token);
		}
	}
}