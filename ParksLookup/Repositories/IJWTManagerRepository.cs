using ParksLookup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParksLookup.Repositories
{
	public interface IJWTManagerRepository
	{
		Tokens Authenticate(User user);
	}
}