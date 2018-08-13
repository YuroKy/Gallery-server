using System.Threading.Tasks;
using Gallery.Server.Data.Models;
using Gallery.Server.Operations.Abstractions;
using Gallery.Server.Operations.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Gallery.Server.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/Account")]
	public class AccountController : Controller
	{
		private readonly IAccountOperations _accountOperations;

		public AccountController(IAccountOperations accountOperations)
		{
			_accountOperations = accountOperations;
		}

		[HttpPost("Login")]
		public IActionResult Login([FromBody] LoginModel model)
		{
			return Ok(_accountOperations.Login(model));
		}

		[HttpPost("Register")]
		public async Task<IActionResult> Register([FromBody] RegisterModel model)
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