using System.Threading.Tasks;
using Gallery.Server.Data.Models;

namespace Gallery.Server.Operations.Abstractions
{
	public interface IPictureOperations
	{
		Task Like(int userId, int pictureId);
		PaginationInfoModel<PictureShortModel> GetPicturesWithPagination(PaginationModel paginationModel);
	}
}
