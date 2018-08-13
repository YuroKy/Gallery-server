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
		private readonly IUnitOfWork _uow;

		public AccountOperations(IUnitOfWork uow)
		{
			_uow = uow;
		}

		public AuthorizationResponseModel Login(LoginModel model)
		{
			var identity = GetIdentity(model.UserName, model.Password);

			if (identity == null)
			{
				throw new Exception("Invalid username or password.");
			}

			var userId = _uow.UsersRepository
				.Get(u => u.Username == model.UserName && u.Password == model.Password)
				.First().Id;

			return new AuthorizationResponseModel
			{
				UserId = userId,
				UserName = identity.Name,
				AccessToken = TokenHelper.GenerateJWT(identity)
			};
		}
		public async Task Register(RegisterModel model)
		{
			await _uow.UsersRepository.InsertAsync(new UserEntity
			{
				Username = model.UserName,
				Email = model.Email,
				Password = model.Password,
				Role = Roles.User
			});

			await _uow.SaveChangesAsync();
		}

		#region private
		private ClaimsIdentity GetIdentity(string username, string password)
		{
			var person = _uow
				.UsersRepository.Get(u => u.Username == username && u.Password == password)
				.FirstOrDefault();

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
