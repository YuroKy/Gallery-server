using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Gallery.Server.Data.Options
{
	public class AuthOptions
	{
		public const string ISSUER = "Yuroky-Server";
		public const string AUDIENCE = "YuroKy-User/";
		const string KEY = "yurii_secret_key-for-galery-very-very-strong!";
		public const int LIFETIME = 120;
		public static SymmetricSecurityKey GetSymmetricSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
		}
	}
}
