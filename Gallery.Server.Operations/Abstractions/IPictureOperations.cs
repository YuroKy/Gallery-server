using System.Threading.Tasks;

namespace Gallery.Server.Operations.Abstractions
{
	public interface IPictureOperations
	{
		Task Like(int userId, int pictureId);
	}
}
