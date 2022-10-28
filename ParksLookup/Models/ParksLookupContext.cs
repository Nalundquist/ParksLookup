using Microsoft.EntityFrameworkCore;
using System;

namespace ParksLookup.Models
{
	public class ParksLookupContext : DbContext
	{
		public ParksLookupContext(DbContextOptions<ParksLookupContext> options) : base(options)
		{

		}

		public DbSet<Park> Parks {get; set;}
		public DbSet<User> Users {get; set;}
		public DbSet<Tokens> Tokens {get; set;}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Park>()
				.HasData(
					new Park {
						ParkId = 1,
						Name = "Yosemite",
						Description = "Cool Rocks abounds",
						NatlOrState = "National"
					},

					new Park {
						ParkId = 2,
						Name = "Fake State Park",
						Description = "Theres a bridge made of naturally formed rock candy, wow",
						NatlOrState = "State"
					},

					new Park {
						ParkId = 3,
						Name = "False Falls",
						Description = "This majestic waterfall is actually a bigscreen tv",
						NatlOrState = "National"
					},

					new Park {
						ParkId = 4,
						Name = "Jean Genet Memorial State Park",
						Description = "It's on the ocean, nice breeze",
						NatlOrState = "State"
					},

					new Park {
						ParkId = 5,
						Name = "Floppy Canyon",
						Description = "All the rocks here are actually rubbery cushions, you can bounce around.  It rules.",
						NatlOrState = "National"
					}
				);
		}
	}
}