using Gallery.Server.Data.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Server.Operations.Helpers
{
    public class TokenHelper
    {
		public static string GenerateJWT(ClaimsIdentity identity)
		{
			var now = DateTime.UtcNow;
			var jwt = new JwtSecurityToken(
					issuer: AuthOptions.ISSUER,
					audience: AuthOptions.AUDIENCE,
					notBefore: now,
					claims: identity.Claims,
					expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
					signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

			return new JwtSecurityTokenHandler().WriteToken(jwt);
		}
    }
}
