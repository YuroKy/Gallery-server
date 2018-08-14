using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.Server.Data;
using Gallery.Server.Data.Entities;
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
	}
}
