using Gallery.Server.Data.Models;
using System.Threading.Tasks;

namespace Gallery.Server.Operations.Abstractions
{
	public interface IAccountOperations
	{
		Task Register(RegisterModel model);
		AuthorizationResponseModel Login(LoginModel model);
	}
}
