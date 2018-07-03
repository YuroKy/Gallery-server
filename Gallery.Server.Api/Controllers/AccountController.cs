using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Gallery.Server.Data;
using Gallery.Server.Data.Entities;
using Gallery.Server.Data.Enums;
using Gallery.Server.Data.Models;
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

		public AccountController(ApplicationContext context)
		{
			_context = context;
		}

		[HttpPost("Login")]
		public async Task Login([FromBody] LoginModel model)
		{

			var identity = await GetIdentity(model.UserName, model.Password);

			if (identity == null)
			{
				Response.StatusCode = 400;
				await Response.WriteAsync("Invalid username or password.");
				return;
			}

			var response = new
			{
				accessToken = TokenHelper.GenerateJWT(identity),
				userName = identity.Name
			};

			Response.ContentType = "application/json";
			await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
		}

		private async Task<ClaimsIdentity> GetIdentity(string username, string password)
		{
			var person = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

			if (person != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimsIdentity.DefaultNameClaimType, person.Username),
					new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role.ToString())
				};

				ClaimsIdentity claimsIdentity =
					new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

				return claimsIdentity;
			}
			return null;
		}

		[HttpPost("Register")]
		public async Task<IActionResult> Register([FromBody]RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				User user = new User
				{
					Username = model.UserName,
					Email = model.Email,
					Password = model.Password,
					Role = Roles.User
				};
				_context.Users.Add(user);
				await _context.SaveChangesAsync();
				return Ok();
			}
			return BadRequest("Incorrect model");
		}
	}
}