using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParksLookup.Models;
using ParksLookup.Repositories;

namespace ParksLookup.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ParksController : ControllerBase 
	{
		private readonly ParksLookupContext _db;
		private readonly IJWTManagerRepository _jWTManager;

		public ParksController(ParksLookupContext db, IJWTManagerRepository jWTManager)
		{
			_db = db;
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

		[HttpGet] 
		public async Task<ActionResult<IEnumerable<Park>>> Get(string natlOrState)
		{
			IQueryable<Park> query = _db.Parks.AsQueryable();

			if (natlOrState != null)
			{
				query = query.Where(q => q.NatlOrState == natlOrState);
			}

			return await query.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<Park>> Post(Park park)
		{
			_db.Parks.Add(park);
			await _db.SaveChangesAsync();
			return CreatedAtAction("Post", new{id = park.ParkId}, park);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Park>> GetPark(int id)
		{
			Park park = await _db.Parks.FindAsync(id);
			if (park == null)
			{
				return NotFound();
			}
			return CreatedAtAction(nameof(GetPark), new {id = park.ParkId}, park);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, Park park)
		{
			if (id != park.ParkId)
			{
				return BadRequest();
			}
			_db.Entry(park).State = EntityState.Modified;

			try
			{
				await _db.SaveChangesAsync();
			}
			catch(DbUpdateConcurrencyException)
			{
				if(!ParkExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var park = await _db.Parks.FindAsync(id);
			if (park == null)
			{
				return NotFound();
			}

			_db.Parks.Remove(park);
			await _db.SaveChangesAsync();

			return NoContent();
		}

		private bool ParkExists(int id)
		{
			return _db.Parks.Any(p => p.ParkId == id);
		}
	}
}