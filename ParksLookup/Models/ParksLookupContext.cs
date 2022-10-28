using Microsoft.EntityFrameworkCore;
using System;

namespace ParksLookup.Models
{
	public class ParksLookupContext : DbContext
	{
		public DbSet<Park> Parks {get; set;}
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<Park>()
			.HasData(
				
			)
	}
}