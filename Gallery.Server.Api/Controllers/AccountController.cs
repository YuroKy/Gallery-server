using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Gallery.Server.Data;
using Gallery.Server.Data.Entities;
using Gallery.Server.Data.Enums;
using Gallery.Server.Data.Models;
using Gallery.Server.Operations.Abstractions;
using Gallery.Server.Operations.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Gallery.Server.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class AccountController : Controller
	{
		private readonly ApplicationContext _context;
		private readonly IAccountOperations _accountOperations;

		public AccountController(ApplicationContext context, IAccountOperations accountOperations)
		{
			_context = context;
			_accountOperations = accountOperations;
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginModel model)
		{
			return Ok(await _accountOperations.Login(model));
		}

		[HttpPost("Register")]
		public async Task<IActionResult> Register(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				await _accountOperations.Register(model);
				return Ok();
			}
			return BadRequest("Incorrect model");
		}
	}
}