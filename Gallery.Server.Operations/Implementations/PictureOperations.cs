using System.Linq;
using System.Threading.Tasks;
using Gallery.Server.Data;
using Gallery.Server.Data.Entities;
using Gallery.Server.Data.Models;
using Gallery.Server.Operations.Abstractions;

namespace Gallery.Server.Operations.Implementations
{
	public class PictureOperations : IPictureOperations
	{
		private readonly IUnitOfWork _uow;

		public PictureOperations(IUnitOfWork uow)
		{
			_uow = uow;
		}

		public async Task Like(int userId, int pictureId)
		{
			var like = _uow.LikesRepository.Get(x => x.User.Id == userId && x.Picture.Id == pictureId).FirstOrDefault();

			if (like != null)
			{
				_uow.LikesRepository.Remove(like);
			}
			else
			{
				_uow.LikesRepository.Insert(new LikeEntity
				{
					Picture = new PictureEntity { Id = pictureId },
					User = new UserEntity { Id = userId }
				});
			}

			await _uow.SaveChangesAsync();
		}

		public PaginationInfoModel<PictureShortModel> GetPicturesWithPagination(PaginationModel paginationModel)
		{
			var pictures = _uow.PicturesRepository
				.Get()
				.OrderByDescending(x => x.Id)
				.ToList();

			if (paginationModel.LastItemId.HasValue)
			{
				pictures = pictures.Where(x => x.Id < paginationModel.LastItemId).ToList();
			}

			var data = pictures
				.Take(paginationModel.Count)
				.Select(x => new PictureShortModel
				{
					Id = x.Id,
					Title = x.Title,
					FileName = x.FileName,
				})
				.ToList();

			return new PaginationInfoModel<PictureShortModel>
			{
				Data = data,
				IsLast = data.Count() == pictures.Count()
			};
		}
	}
}
