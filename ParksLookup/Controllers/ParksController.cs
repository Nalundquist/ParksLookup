using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksLookup.Models;
using System.Linq;
using System;

namespace ParksLookup.Controllers
{
	[route("api/[controller]")]
	[ApiController]
	public class ParksController : ControllerBase 
}