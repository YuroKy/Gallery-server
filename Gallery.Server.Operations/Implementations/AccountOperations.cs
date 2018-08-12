using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Gallery.Server.Data;
using Gallery.Server.Data.Entities;
using Gallery.Server.Data.Enums;
using Gallery.Server.Data.Models;
using Gallery.Server.Operations.Abstractions;
using Gallery.Server.Operations.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Server.Operations.Implementations
{
	public class AccountOperations : IAccountOperations
	{
		private readonly ApplicationContext _context;

		public AccountOperations(ApplicationContext context)
		{
			_context = context;
		}

		public async Task<AuthorizationResponseModel> Login(LoginModel model)
		{
			var identity = await GetIdentity(model.UserName, model.Password);

			if (identity == null)
			{
				throw new Exception("Invalid username or password.");
			}

			return new AuthorizationResponseModel
			{
				UserId = _context.Users.FirstOrDefault(u => u.Username == model.UserName && u.Password == model.Password).Id,
				UserName = identity.Name,
				AccessToken = TokenHelper.GenerateJWT(identity)
			};
		}
		public async Task Register(RegisterModel model)
		{
			await _context.Users.AddAsync(new UserEntity
			{
				Username = model.UserName,
				Email = model.Email,
				Password = model.Password,
				Role = Roles.User
			});

			await _context.SaveChangesAsync();
		}

		#region private
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
		#endregion
	}
}
