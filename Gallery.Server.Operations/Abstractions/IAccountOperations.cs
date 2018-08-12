using Gallery.Server.Data.Models;
using System.Threading.Tasks;

namespace Gallery.Server.Operations.Abstractions
{
	public interface IAccountOperations
	{
		Task Register(RegisterModel model);
		Task<AuthorizationResponseModel> Login(LoginModel model);
	}
}
